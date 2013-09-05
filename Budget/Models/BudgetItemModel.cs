using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Template.Models
{
    public class BudgetItemModel
    {
        public ParentItemModel standardItem;

        public int StandardItemId { get; set; }

        [DisplayName("Item")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Amount")]
        public decimal DefaultValue { get; set; }

        public BudgetItemModel()
        {

        }

        public BudgetItemModel(ParentItemModel item)
        {
            this.standardItem = item;
        }
    }
}