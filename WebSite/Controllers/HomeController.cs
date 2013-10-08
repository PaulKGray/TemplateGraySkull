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
            if (!Roles.RoleExists("Administrator"))
            {
                return RedirectToAction("SetUpSite", "Account");
            }


            var model = new HomeModel();

            var parentItems = _ParentItemService.GetAllParentItem();

            foreach (var item in parentItems)
            {
                var parentItem = new ParentItemModel();

                parentItem = convertParentItemDomainObject(item);

                model.ParentItems.Add(parentItem);

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            var item = _ParentItemService.GetParentItem(id);

            var viewmodel = convertParentItemDomainObject(item);

            return View(viewmodel);
            
        }

        ParentItemModel convertParentItemDomainObject(ParentItem parentItem)
        {

            var parentItemModel = new ParentItemModel();
            parentItemModel.ParentItemid = parentItem.ParentItemid;
            parentItemModel.Name = parentItem.Name;
            parentItemModel.Description = parentItem.Description;

            foreach (var childItem in parentItem.ChildItems)
            {

                var newChildItem = new ChildItemModel();
                newChildItem.ChildItemId = childItem.ChildItemId;
                newChildItem.Name = childItem.Name;

                parentItemModel.ChildItems.Add(newChildItem);

            }

            return parentItemModel;

        }


    }

    
}
