using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Template.Domain;

namespace Template.Models
{
    public class ParentItemModel
    {
	    public int ParentItemid { get; set; }

        [DisplayName("Parent Item Name")]
        [StringLength(160)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }


		public IList<ChildItemModel> ChildItems;

        public ParentItemModel()
        {
			ChildItems = new List<ChildItemModel>();
        }

      
    }
}