using Template.Controllers.Actionfilters;
using Template.Domain;
using Template.Models;
using Template.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Template.Controllers
{
    public class HomeController : Controller
    {

        private IParentItemService _ParentItemService;
				private IChildItemService _ChildItemService;

        public HomeController(IParentItemService parentItemService, IChildItemService childItemService)
        {
					_ParentItemService = parentItemService;
					_ChildItemService = childItemService;
        }
            
        [HttpGet]
        public ActionResult Index()
        {


            // Lets see if the main site role exists
            if (!Roles.RoleExists("Administration"))
            {
                return RedirectToAction("SetUpSite", "Account");
            }


            var model = new HomeModel();

						var parentItems = _ParentItemService.GetAllParentItem();

						foreach (var item in parentItems)
            {
                var parentItem = new ParentItemModel();
								parentItem.ParentItemid = item.ParentItemid;
								parentItem.Name = item.Name;

								foreach (var childItem in item.ChildItems)
								{
									
									var newChildItem = new ChildItemModel();
									newChildItem.ChildItemId = childItem.ChildItemId;
									newChildItem.Name = childItem.Name;

									parentItem.ChildItems.Add(newChildItem);

								}

							  model.ParentItems.Add(parentItem);
  
            }

            return View(model);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Index(HomeModel model) {

            if (ModelState.IsValid)
            {

  

            }
 
            return View(model);
        }

        public ActionResult NextSteps() {


            return View();
            
        }


    }
}
