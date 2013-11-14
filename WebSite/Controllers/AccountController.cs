using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Template.Models;
using Template.Models.Account;

namespace Template.Controllers
{
    public class AccountController : Controller
    {


			[HttpGet]
			public ActionResult Logout()
			{

				FormsAuthentication.SignOut();
				Roles.DeleteCookie();
				return RedirectToAction("Index","home");


			}


			[HttpGet]
			public ActionResult Login()
			{

				return View();

			
			}
	 

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, true);

                    return RedirectToAction("Index","Home");
                }
            }

            return View();
        }

				[HttpGet]
				public ActionResult ForgotPassword() {

					return View();
				
				}


				public ActionResult ForgotPassword(ForgotPasswordViewModel model)
				{


					if (ModelState.IsValid)
					{

						MembershipUser user = Membership.GetUser(User.Identity);
						string newpassword = "RandomString";
						user.ChangePassword(user.ResetPassword(), newpassword);

						// Send the link

						//https://github.com/NickJosevski/mailzor

						// Reset the login

						return RedirectToAction("Index", "Home");

					}
					else
					{

						return View(model);

					}





				}


        [HttpGet]
                public ActionResult Register() {

                    return View();
                
                }



        [HttpGet]
        public ActionResult SetUpSite()
        {

            if (Roles.RoleExists("Administration")) {

                RedirectToAction("index", "Home");

            }
            
            return View();

        }

				[HttpPost]
				public ActionResult SetUpSite(SetUpSiteModel model) {

					if (model.AdminPassword != model.ConfirmAdminPassword) {

						ModelState.AddModelError("AdminPassword", "Your passwords do not match");
						
					}

					if (ModelState.IsValid)
					{

						if (!Roles.RoleExists("Administrator"))
						{

							var userException = Membership.CreateUser(model.AdminUsername, model.AdminPassword, model.AdminUsername);
							Roles.CreateRole("Administrator"); // could swap this out to config
							Roles.AddUserToRole(model.AdminUsername, "Administrator");

							FormsAuthentication.SetAuthCookie(model.AdminUsername, true);

                            return RedirectToAction("UserManagement");

						}

						return RedirectToAction("Index", "Home");

					}

					else {

						return View(model);
					
					}
			
				
				}







        

    }
}
