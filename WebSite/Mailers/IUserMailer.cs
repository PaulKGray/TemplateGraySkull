using Mvc.Mailer;

namespace Template.Domain.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
			MvcMailMessage PasswordReset();
	}
}