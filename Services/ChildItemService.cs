using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Services.Interfaces;
using Template.Domain;
using Template.Repository.Interfaces;
using Template.Repository;
using NHibernate;

namespace Template.Services
{
    public class ChildItemService : IChildItemService
    {

        private IRepository<ChildItem> _ChildItemRepository;


        public ChildItem AddChildItem(ChildItem childItem)
        {
           childItem = _ChildItemRepository.Add(childItem);
           return childItem;
        }

        public ChildItem GetChildItem(int childItemId)
        {
            var childItem = _ChildItemRepository.FindBy(childItemId);
            return childItem;
        }

        public void SaveChildItem(ChildItem childItem)
        {
            _ChildItemRepository.Update(childItem);
        }

        public void SaveChildItems(IList<ChildItem> childItems)
        {
            foreach (var item in childItems)
            {
                _ChildItemRepository.Update(item);
            }
        }
    }

}
