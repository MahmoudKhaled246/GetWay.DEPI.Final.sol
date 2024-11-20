using Auth.DEPI.Final.DAL.Entities;
using System.Net;
using System.Net.Mail;

namespace Auth.DEPI.Final.PL.Helpers
{
	public class SendEmailHelper
	{
		public static void SendEmail(Email email)
		{
			var client = new SmtpClient("smtp.gmail.com" , 587);

			client.EnableSsl = true;

			client.Credentials = new NetworkCredential("mahmoudkhaled4812@gmail.com", "xybavjagziutpzjd");

			client.Send("mahmoudkhaled4812@gmail.com", email.To, email.Subject, email.Body);
		}

	}
}
