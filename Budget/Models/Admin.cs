using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Domain;

namespace Template.Models
{
    public class AdminModel
    {

			public IList<ParentItem> ParentItems;

        public AdminModel()
        {
					ParentItems = new List<ParentItem>();
        }




    }
}