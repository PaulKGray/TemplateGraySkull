using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Template.Models
{
	public class ChildItemModel
	{

		public int ChildItemId { get; set; }

    [DisplayName("Child Item Name")]
		public string Name { get; set; }

		public ParentItemModel ParentItem { get; set; }


	}
}