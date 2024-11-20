using System.ComponentModel.DataAnnotations;

namespace Auth.DEPI.Final.PL.ViewModels.AuthViewModels
{
	public class ForgetPasswordViewModel
	{

		[Required(ErrorMessage = "Please Email Is Required !!")]
		[EmailAddress(ErrorMessage = "Invalid Email Address!!")]
		public string Email { get; set; }
	}
}
