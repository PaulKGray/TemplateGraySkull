using Template.Controllers.Actionfilters;
using Template.Domain;
using Template.Models;
using Template.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Template.Controllers
{
    public class HomeController : Controller
    {

        private IParentItemService _BudgetService;
        private IChildItemService _BudgetItemService;

        public HomeController(IParentItemService parentItemService, IChildItemService childItemService)
        {
            _BudgetService = budgetService;
            _BudgetItemService = budgetItemService;
        }
            
        [HttpGet]
        public ActionResult Index()
        {

            var model = new HomeModel();

            var standarditems = _StandardItemService.GetAllStandardITems();

            foreach (var item in standarditems)
            {
                var modelitem = new ParentItemModel();
                modelitem.Name = item.Name;
                modelitem.Type = item.Type;
                modelitem.Description = item.Description;
                modelitem.id = item.StandardItemId;


                var budgetItemModel = new BudgetItemModel(modelitem);

                budgetItemModel.Name = item.Name;
                budgetItemModel.StandardItemId = item.StandardItemId;

                if (item.Type == Domain.ItemType.Expense)
                {
                    model.ExpenseItems.Add(budgetItemModel);
                }
                else
                {
                    model.IncomeItems.Add(budgetItemModel);
                }
            }


            return View(model);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Index(HomeModel model) {

            if (ModelState.IsValid)
            {

                var budget=_BudgetService.CreateBudget("Temp");

                IList<BudgetItem> itemsToAdd = new List<BudgetItem>();

                foreach (var item in model.ExpenseItems)
                {
                    var theStandardItem = _StandardItemService.GetStandardItem(item.StandardItemId);
                    var newItem = new BudgetItem(budget, theStandardItem, item.DefaultValue, item.Name, ItemType.Expense);
                    budget.AddItem(newItem);
                }

                foreach (var incomeItems in model.IncomeItems) 
                {
                    var theIncomeStandardItem = _StandardItemService.GetStandardItem(incomeItems.StandardItemId);
                    var newIncomeItem = new BudgetItem(budget, theIncomeStandardItem, incomeItems.DefaultValue, incomeItems.Name, ItemType.Income);
                    budget.AddItem(newIncomeItem);
                }


                _BudgetService.SaveBudget(budget);

                //Look at passing the budget tp the next view via temp data

                return RedirectToAction("NextSteps");

            }
 
            return View(model);
        }

        public ActionResult NextSteps() {


            return View();
            
        }


    }
}
