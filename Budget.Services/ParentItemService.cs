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

        public ParentItem CreateParent(ParentItem parent)
        {
            parent = new ParentItem();

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


        public void  SaveParentItem(ParentItem parent)
        {
					_ParentRepository.Update(parent);
        }


				public IList<ParentItem> GetAllParentItem()
				{
					return _ParentRepository.FindAll();
				}


				public void DeleteParentItem(int id)
				{
					var parentItem = _ParentRepository.FindBy(id);
					_ParentRepository.Delete(parentItem);
				}
		}
}