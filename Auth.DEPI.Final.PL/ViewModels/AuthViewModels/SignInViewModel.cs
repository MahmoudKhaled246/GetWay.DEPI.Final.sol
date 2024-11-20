using System.ComponentModel.DataAnnotations;

namespace Auth.DEPI.Final.PL.ViewModels.AuthViewModels
{
	public class SignInViewModel
	{
		[Required(ErrorMessage ="Please Email Is Required !!")]
		[EmailAddress]
        public string Email { get; set; }

		[Required(ErrorMessage ="Please Password Is Required !!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool  RememberMe { get; set; }
    }
}
