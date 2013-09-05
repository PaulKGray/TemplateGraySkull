using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Services.Interfaces;
using Template.Repository.Interfaces;
using Template.Domain;

namespace Template.Services
{
    public class ParentItemService : IParentItemService
    {

        private IRepository<ParentItem> _ParentRepository;


        public ParentItemService(IRepository<ParentItem> repository)
        {
            _ParentRepository = repository;
        }

        public ParentItem CreateParent()
        {
            var parent = new ParentItem();

            _ParentRepository.Add(parent);

            return parent;
        }

        public ParentItem GetParentItem(int parentItemId)
        {
            var parentItem = _ParentRepository.FindBy(parentItemId);
            return parentItem;
        }

        public bool SaveParentItem(ParentItem parentitem)
        {
            var result = _ParentRepository.Update(parentitem);
            return result;
        }


        public void  SaveParentItem(ParentItem budget)
        {
            throw new NotImplementedException();
        }
    }
}