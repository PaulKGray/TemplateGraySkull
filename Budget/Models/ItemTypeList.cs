using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.Models
{
    public class ItemTypeList
    {
        public string name { get; set; }
        public Template.Domain.ItemType Type { get; set; }

        public ItemTypeList(string typeName, Template.Domain.ItemType type)
        {
            this.name = typeName;
            this.Type = type;
        }

        public static IEnumerable<ItemTypeList> ItemTypes = new List<ItemTypeList>
        {
            new ItemTypeList("Expense", Domain.ItemType.Expense),
            new ItemTypeList("Income", Domain.ItemType.Income)

        };

    }
}