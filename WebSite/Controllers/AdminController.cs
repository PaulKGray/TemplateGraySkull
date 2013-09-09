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
        private IChildItemService _ChildItemService;

		public AdminController(IParentItemService parentItemService, IChildItemService childItemService)
        {
			  _ParentItemService = parentItemService;
              _ChildItemService = childItemService;
		}
            
        public ActionResult Index()
        {

            AdminModel adminModel = PopulateAdminModel();

            return View(adminModel);
        }

        private AdminModel PopulateAdminModel()
        {
            var adminModel = new AdminModel();

            var parentitems = _ParentItemService.GetAllParentItem();
            IList<ParentItemModel> parentModelItems = new List<ParentItemModel>();
            
            foreach (var item in parentitems)
	        {
                var parentItem =  new ParentItemModel();
                parentItem.Name = item.Name;
                parentItem.ParentItemid = item.ParentItemid;

                foreach (var childItem in item.ChildItems)
                {
                    var childItemModel = new ChildItemModel();
                    childItemModel.Name = childItem.Name;
                    childItemModel.ChildItemId = childItem.ChildItemId;
                    childItemModel.ParentItem = parentItem;

                    parentItem.ChildItems.Add(childItemModel);
                }
                

		        parentModelItems.Add(parentItem);
	        }

            adminModel.ParentItems = parentModelItems;

            return adminModel;

        }

        [HttpGet]
		public ActionResult CreateParentItem()
        {

            var model = new AdminCreateModel();
            var parentItem = new ParentItemModel();

            model.Parent = parentItem;
             
            for (int i = 0; i < 6; i++)
            {
                var childitem = new ChildItemModel();

                model.ChildItems.Add(childitem);
                 
            }
			return View(model);
        }

        [HttpPost]
        public ActionResult CreateParentItem(AdminCreateModel model) {

            if (ModelState.IsValid) {

                var parentItem = new ParentItem(model.Parent.Name);
                parentItem.Name = model.Parent.Name;

			    TempData["Message"] = string.Format("{0} has been added to your cart!", model.Parent.Name);


               foreach (var item in model.ChildItems)
               {
                   if (item.Name != null){

                       var childItem = new ChildItem(parentItem);
                       childItem.Name = item.Name;
                       parentItem.AddChildItem(childItem);

                   }
               }


               parentItem = _ParentItemService.CreateParent(parentItem);

                return RedirectToAction("Index");

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditParentItem(int id)
        {
			var parentItem = _ParentItemService.GetParentItem(id);
			var parentItemModel = new ParentItemModel();

			parentItemModel.Name = parentItem.Name;

			return View(parentItemModel);
        }

        [Transaction]
        [HttpPost]
        public ActionResult EditParentItem(ParentItemModel item)
        {
            if (ModelState.IsValid)
            {

							var parentItem = new ParentItem(item.Name);
							parentItem.Name = item.Name;
							parentItem.ParentItemid = item.ParentItemid;

							_ParentItemService.SaveParentItem(parentItem);

              return RedirectToAction("Index");
            }

            return View(item);
        }

        [Transaction]
        [HttpGet]
        public ActionResult DeleteParentItem(int id) {

					_ParentItemService.DeleteParentItem(id);

          return RedirectToAction("Index");
        }

    }
}
