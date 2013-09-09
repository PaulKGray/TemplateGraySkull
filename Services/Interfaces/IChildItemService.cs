using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain;

namespace Template.Services.Interfaces
{
    public interface IChildItemService
    {
        ChildItem AddChildItem(ChildItem childItem);
        ChildItem GetChildItem(int childItemId);
        void SaveChildItem(ChildItem childItem);
        void SaveChildItems(IList<ChildItem> childItems);

    }
}
