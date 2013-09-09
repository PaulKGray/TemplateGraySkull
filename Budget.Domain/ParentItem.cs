﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain
{
    public class ParentItem
    {
        public virtual int ParentItemid { get; set; }

				public virtual string Name { get; set; }

        public virtual IList<ChildItem> ChildItems { get; set; }

        protected ParentItem(){

            
        }

        public ParentItem()
        {
					ChildItems = new List<ChildItem>();
        }


        public void AddChildItem(ChildItem childitem) {

					this.ChildItems.Add(childitem);
					
				}


      

    }
}
