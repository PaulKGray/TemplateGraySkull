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

	 

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, true);

                    return RedirectToAction("");
                }
            }

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

					if (!ModelState.IsValid)
					{

						if (Roles.RoleExists("Administrator"))
						{

							var userException = Membership.CreateUser(model.AdminUsername, model.AdminPassword, model.AdminUsername);
							Roles.CreateRole("Administrator"); // could swap this out to config
							Roles.AddUserToRole(model.AdminUsername, model.AdminPassword);

							FormsAuthentication.SetAuthCookie(model.AdminUsername, true);

							return RedirectToAction("ShowAllUsers");

						}

						return RedirectToAction("Index", "Home");

					}

					else {

						return View(model);
					
					}
			
				
				}


				public ActionResult UserManagement() {
										
				
					var users = Membership.GetAllUsers().Cast<MembershipUser>().OrderBy(x=>x.Email).ToList();

					var userManagementModel = new UserManagementModel();

					foreach (var user in users)
					{
						userManagementModel.users.Add(getUserDetails(user));
					}
					
					return View(userManagementModel);

				}


				public UserModel getUserDetails(MembershipUser membershipuser) {

					var user = new UserModel();
					user.Email = membershipuser.Email;
					user.Username = membershipuser.UserName;


					
					return user;

				}





        

    }
}
