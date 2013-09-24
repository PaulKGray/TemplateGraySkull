using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Template.Models.Account;

namespace Template.Controllers
{
    public class UserController : Controller
    {

			[Authorize(Roles = "Administrator")]
			[HttpGet]
			public ActionResult UserManagement()
			{


				var users = Membership.GetAllUsers().Cast<MembershipUser>().OrderBy(x => x.Email).ToList();
		
				var userManagementModel = new UserManagementModel();

				foreach (var user in users)
				{

					var usermodel = getUserDetails(user);


					userManagementModel.users.Add(usermodel);

				}

				return View(userManagementModel);

			}


			public UserModel getUserDetails(MembershipUser membershipuser)
			{

				var user = new UserModel();
				user.Email = membershipuser.Email;
				user.Username = membershipuser.UserName;

				var roles = Roles.GetRolesForUser(user.Username);

				foreach (var role in roles)
				{

					var roleModel = new RolesModel();
					roleModel.Role = role;
					user.Roles.Add(roleModel);

				}

				return user;

			}


    }
}
