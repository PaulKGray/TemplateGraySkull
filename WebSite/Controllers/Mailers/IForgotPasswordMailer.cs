using Mvc.Mailer;
using Template.Models.Account;

namespace Template.Controllers.Mailers
{
	interface IForgotPasswordMailer
	{
		MvcMailMessage ForgotPasswordMail(ForgotPasswordViewModel model);
	}
}
