using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Domain;

namespace Template.Models
{
    public class AdminModel
    {

		public IList<ParentItemModel> ParentItems;

        public AdminModel()
        {
			ParentItems = new List<ParentItemModel>();
        }

    }

    public class AdminCreateModel {

        public ParentItemModel Parent { get; set; }
        public IList<ChildItemModel> ChildItems { get; set; }

        public AdminCreateModel()
        {
            ChildItems = new List<ChildItemModel>();
        }
    
    }


}