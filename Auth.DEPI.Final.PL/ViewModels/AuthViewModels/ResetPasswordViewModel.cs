using System.ComponentModel.DataAnnotations;

namespace Auth.DEPI.Final.PL.ViewModels.AuthViewModels
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "Please Password Is Required !!")]
		[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{5,}$", ErrorMessage = "Password must be Minimum Five characters, at least one uppercase letter, one lowercase letter, one number and one special character:")]

		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = "Please Confirm Password Is Required !!")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Confirm Password doesn't match Password !!")]
		public string ConfirmPassword { get; set; }

	}
}
