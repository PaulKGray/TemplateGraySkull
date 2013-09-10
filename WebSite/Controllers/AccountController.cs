using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Template.Models;

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


        

    }
}
