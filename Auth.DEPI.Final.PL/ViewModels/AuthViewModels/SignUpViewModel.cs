using System.ComponentModel.DataAnnotations;

namespace Auth.DEPI.Final.PL.ViewModels.AuthViewModels
{
	public class SignUpViewModel
	{
		[Required(ErrorMessage = "Please Enter Your Username !!")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Please Enter Your Name !!")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please Email Is Required !!")]
		[EmailAddress(ErrorMessage = "Invalid Email Address!!")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please Password Is Required !!")]
		[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{5,}$", ErrorMessage = "Password must be Minimum Five characters, at least one uppercase letter, one lowercase letter, one number and one special character:")]
																																			
		[DataType(DataType.Password)]																										
		public string Password { get; set; }																								
		[Required(ErrorMessage = "Please Confirm Password Is Required !!")]																	
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Confirm Password doesn't match Password !!")]
		public string ConfirmPassword { get; set; }
		public IFormFile? Image { get; set; }
		public string? ImageName { get; set; }
	}
}
