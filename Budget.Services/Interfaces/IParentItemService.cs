using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain;

namespace Template.Services.Interfaces
{
    public interface IParentItemService
    {
        ParentItem CreateParent();
        ParentItem GetParentItem(int ParentItemId);
        void SaveParentItem(ParentItem budget);
    }
}
