using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Controllers.Actionfilters;
using Template.Domain;
using Template.Models;
using Template.Services.Interfaces;

namespace Template.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private IParentItemService _ParentItemService;

				public AdminController(IParentItemService standardItemService)
        {
					_ParentItemService = standardItemService;
        }
            
        public ActionResult Index()
        {

            AdminModel adminModel = PopulateAdminModel();

            return View(adminModel);
        }

        private AdminModel PopulateAdminModel()
        {
            var adminModel = new AdminModel();

            adminModel.ParentItems = _ParentItemService.GetAllParentItem();

            return adminModel;

        }

        [HttpGet]
        public ActionResult CreateNew()
        {
            var parentItem = new ParentItemModel();
						return View(parentItem);
        }

        [HttpPost]
        public ActionResult CreateNew(ParentItemModel item) {

            if (ModelState.IsValid) {

            // needs to assign correct enum for expense type.
							var parentItem = new ParentItem();
							parentItem.Name = item.Name;

							_ParentItemService.CreateParent(parentItem);
							

            return RedirectToAction("Index");

            }

            return View(item);
        }

        [HttpGet]
        public ActionResult EditStandardItem(int id)
        {
					var parentItem = _ParentItemService.GetParentItem(id);
					var parentItemModel = new ParentItemModel();

					parentItemModel.Name = parentItem.Name;

					return View(parentItemModel);
        }

        [Transaction]
        [HttpPost]
        public ActionResult EditStandardItem(ParentItemModel item)
        {
            if (ModelState.IsValid)
            {

							var parentItem = new ParentItem();
							parentItem.Name = item.Name;
							parentItem.ParentItemid = item.ParentItemid;

							_ParentItemService.SaveParentItem(parentItem);

              return RedirectToAction("Index");
            }

            return View(item);
        }

        [Transaction]
        [HttpGet]
        public ActionResult DeleteStandardItem(int id) {

					_ParentItemService.DeleteParentItem(id);

          return RedirectToAction("Index");
        }

    }
}
