using Mvc.Mailer;

namespace Template.Controllers.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome();
	}
}