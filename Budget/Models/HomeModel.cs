using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.Models
{
    public class HomeModel
    {

        public string Notes { get; set; }

        public IList<BudgetItemModel> IncomeItems { get; set; }
        public IList<BudgetItemModel> ExpenseItems { get; set; }

        public HomeModel()
        {
            IncomeItems = new List<BudgetItemModel>();
            ExpenseItems = new List<BudgetItemModel>();

        }
    }
}