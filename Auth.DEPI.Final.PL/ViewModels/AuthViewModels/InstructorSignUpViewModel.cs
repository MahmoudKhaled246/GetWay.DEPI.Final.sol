using System.ComponentModel.DataAnnotations;

namespace Auth.DEPI.Final.PL.ViewModels.AuthViewModels
{
	public class InstructorSignUpViewModel : SignUpViewModel
	{
		public string Bio { get; set; }
		//[Required (ErrorMessage = "Please The Road Map Is Required !!")]
		//public string Roadmap { get; set; }
	}
}
