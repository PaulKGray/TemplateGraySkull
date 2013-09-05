using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain
{
    public class ChildItem
    {
        public virtual int ChildItemId { get; set; }
        public ParentItem Parent { get; set; }

        protected ChildItem()
        {

        }

        public ChildItem(ParentItem parent)
        {
            Parent = parent; 
        }

      
        


      
    }


}
