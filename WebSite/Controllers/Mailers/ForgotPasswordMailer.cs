using System.Web.Mvc;
using Mvc.Mailer;
using Template.Models.Account;

namespace Template.Controllers.Mailers
{

	/// <summary>
	/// Sends a forgot password mail
	/// </summary>
	/// <remarks>
	/// See this:
	/// http://stackoverflow.com/questions/6641502/mvcmailer-taking-user-input-in-view-through-model-and-then-inserting-it-into-ma
	/// </remarks>
	public class ForgotPasswordMailer : MailerBase, IForgotPasswordMailer
	{

		public ForgotPasswordMailer() : base()
		{
			MasterName = "_Layout";
		}
		
		public virtual MvcMailMessage ForgotPasswordMail(ForgotPasswordViewModel model)
		{
			var mailMessage = new MvcMailMessage
			{
				Subject="Template Password Reset"
			};

			mailMessage.To.Add(model.Email);

			ViewData = new ViewDataDictionary(model);
			PopulateBody(mailMessage, "ForgotPassword", null);
			
			return mailMessage;
		}
	}
}