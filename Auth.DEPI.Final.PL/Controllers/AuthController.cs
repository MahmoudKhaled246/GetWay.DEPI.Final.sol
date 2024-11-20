using Auth.DEPI.Final.DAL.Data.Context;
using Auth.DEPI.Final.DAL.Entities;
using Auth.DEPI.Final.PL.Helpers;
using Auth.DEPI.Final.PL.ViewModels.AuthViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Models;
using System.Reflection.Metadata;
using System.Security.Policy;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Auth.DEPI.Final.PL.Controllers
{
    public class AuthController : Controller
    {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AuthController(
            UserManager<User> userManager,
			SignInManager<User> signInManager,
			RoleManager<IdentityRole> roleManager            
            )
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		#region SignUp
		[HttpGet]
		public IActionResult StudentSignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> StudentSignUp(SignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					
					var role = await _roleManager.FindByIdAsync("student");

					var user = await _userManager.FindByEmailAsync(model.Email);
					if (user is null)
					{
						if (model.Image is not null)
						{
							model.ImageName = DocumentSettings.UploadFile(model.Image, "images");
						}
						else
						{
							model.ImageName = "default-image.jpg";
						}

						user = new Student()
						{
							UserName = model.UserName,
							Name = model.Name,
							Email = model.Email,
							Image = model.ImageName

						};

						var result = await _userManager.CreateAsync(user,model.Password);
						if (result.Succeeded)
						{
							await _userManager.AddToRoleAsync(user, role.Name);
							return RedirectToAction(nameof(SignIn));
						}
					}
					ModelState.AddModelError(string.Empty, "Email Already Exist !!");
					return View(model);

				}
				catch (Exception)
				{

					ModelState.AddModelError(string.Empty, "An Error Has Been Happened during SignUp Process");
				}
			}

			return View();
		}


		[HttpGet]
		public IActionResult InstructorSignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> InstructorSignUp(InstructorSignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					
					var role = await _roleManager.FindByIdAsync("instructor");

					var user = await _userManager.FindByEmailAsync(model.Email);

					if (user is null)
					{
						user = await _userManager.FindByNameAsync(model.UserName);
						if (user is null)
						{
							if (model.Image is not null)
							{
								model.ImageName = DocumentSettings.UploadFile(model.Image, "images");
							}
							else
							{
								model.ImageName = "default-image.jpg";
							}
							user = new Instructor()
							{
								UserName = model.UserName,
								Name = model.Name,
								Email = model.Email,
								Image = model.ImageName,
								Bio = model.Bio,
								//Roadmap = model.Roadmap,


							};

							var result = await _userManager.CreateAsync(user, model.Password);
							if (result.Succeeded)
							{
								await _userManager.AddToRoleAsync(user, role.Name);
								return RedirectToAction(nameof(SignIn));
							}
						}
						ModelState.AddModelError(string.Empty, "UserName is Already Exist !!");
						return View(model);

					}
					ModelState.AddModelError(string.Empty, "Email Already Exist !!");
					return View(model);

				}
				catch (Exception)
				{

					ModelState.AddModelError(string.Empty, "An Error Has Been Happened during SignUp Process");
				}
			}

			return View();
		}

		#endregion

		#region SignIn
		[HttpGet]
		public IActionResult SignIn()
		
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var user = await _userManager.FindByEmailAsync(model.Email);
					if (user is not null)
					{
						var flag = await _userManager.CheckPasswordAsync(user, model.Password);
						if (flag)
						{
                                // Get user roles
                                var userRoles = await _userManager.GetRolesAsync(user);
                         
                            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                            if (result.Succeeded)
                            {
                                
                                if (userRoles is not null)
                                {
                                    var userRole = userRoles.FirstOrDefault();
									if (userRole is not null) 
									{
										if (userRole == "Admin")
										{
											return RedirectToAction("Index", "Admin");
										}
										else if (userRole == "Instructor")
										{
                                            return RedirectToAction("Index", "Instructor");

                                        }
										else if (userRole == "Student")
										{
                                            
                                            return RedirectToAction("Index", "Home");
                                        }
                                    }

                                }
							}
							ModelState.AddModelError(string.Empty, "Invalid Login !!");
						}
						ModelState.AddModelError(string.Empty, "Invalid Email Or Password !!");
						return View();

					}
					ModelState.AddModelError(string.Empty, "Invalid Email Or Password !!");
					return View();

				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			}
            ModelState.AddModelError(string.Empty, "Invalid Email Or Password !!");
            return View();

		}
		#endregion

		#region SignOut
		public new async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index","Home");
		}
		#endregion

		#region ForgetPassword
		[HttpGet]
		public IActionResult ForgetPassword()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
		{
			if (ModelState.IsValid) 
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user is not null) 
				{
					//Create Token
					var token = await  _userManager.GeneratePasswordResetTokenAsync(user);


					//Create URL
					var URL = Url.Action("ResetPassword" , "Auth" , new {email = model.Email , token = token},Request.Scheme);

					var email = new Email()
					{
						To = model.Email,
						Subject = "Reset Password",
						Body = URL
					};

					SendEmailHelper.SendEmail(email);
					return RedirectToAction(nameof(CheckYourInbox));

				}
				ModelState.AddModelError(string.Empty, "Email is Not Found !");
				return View();

			}
			ModelState.AddModelError(string.Empty, "Operation Failed !");


			return View();
		}

		public IActionResult CheckYourInbox()
		{
			return View();
		}
		#endregion

		#region ResetPassword

		[HttpGet]
		public IActionResult ResetPassword(string email , string token)
		{
			TempData["token"] = token;
			TempData["email"] = email;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (ModelState.IsValid) 
			{
				var email = TempData["email"] as string;
				var token = TempData["token"] as string;

				var user = await _userManager.FindByEmailAsync(email);
				if(user is not null)
				{
					var result = await _userManager.ResetPasswordAsync(user,token,model.Password);
					if (result.Succeeded) 
					{
						return RedirectToAction(nameof(SignIn));
					}
				}
				ModelState.AddModelError(string.Empty, "Operation Failed Try again !");

			}
			ModelState.AddModelError(string.Empty, "Operation Failed Try again !");
			return View();
		}
        #endregion
        public IActionResult AccesDenied() {  return View(); }
    }
}
