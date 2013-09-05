using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Controllers.Actionfilters;
using Template.Models;
using Template.Services.Interfaces;

namespace Template.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private IStandardItemService _StandardItemService;

        public AdminController(IStandardItemService standardItemService)
        {
            _StandardItemService = standardItemService;
        }
            
        public ActionResult Index()
        {

            AdminModel adminModel = PopulateAdminModel();

            return View(adminModel);
        }

        private AdminModel PopulateAdminModel()
        {
            var adminModel = new AdminModel();

            adminModel.StandardItems = _StandardItemService.GetAllStandardITems();


            return adminModel;

        }

        [HttpGet]
        public ActionResult CreateNew()
        {
            var StandardItem = new Template.Models.ParentItemModel();
            return View(StandardItem);
        }

        [HttpPost]
        public ActionResult CreateNew(ParentItemModel item) {

            if (ModelState.IsValid) {

            // needs to assign correct enum for expense type.
            var theNewStandardItem = new Template.Domain.BudgetStandardItem(item.Name, item.Type, item.Description);
            _StandardItemService.AddNewStandardItem(theNewStandardItem);

            return RedirectToAction("Index");

            }

            return View(item);
        }

        [HttpGet]
        public ActionResult EditStandardItem(int id)
        {
            var theStandardItem = _StandardItemService.GetStandardItem(id);
            var theModelStandardItem = new ParentItemModel();
           
            theModelStandardItem.Name = theStandardItem.Name;
            theModelStandardItem.id = theStandardItem.StandardItemId;
            theModelStandardItem.Description = theStandardItem.Description;
            // to deal with
            theModelStandardItem.Type = Domain.ItemType.Expense;
            return View(theModelStandardItem);
        }

        [Transaction]
        [HttpPost]
        public ActionResult EditStandardItem(ParentItemModel item)
        {
            if (ModelState.IsValid)
            {

                var DomStandardItem = new Template.Domain.BudgetStandardItem(item.Name, item.Type, item.Description);
                DomStandardItem.StandardItemId = item.id;

                _StandardItemService.EditStandardItem(DomStandardItem);

                return RedirectToAction("Index");
            }

            return View(item);
        }

        [Transaction]
        [HttpGet]
        public ActionResult DeleteStandardItem(int id) {

            _StandardItemService.DeleteStandardItem(id);

            return RedirectToAction("Index");
        }

    }
}
