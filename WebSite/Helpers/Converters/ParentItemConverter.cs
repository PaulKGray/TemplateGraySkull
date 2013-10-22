using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Domain;
using Template.Models;

namespace Template.Helpers.Converters
{
    public class ParentItemConverter
    {
        /// <summary>
        /// Convert a list of parent items to parent item models
        /// </summary>
        /// <param name="parentItems">the list of parent items to convert</param>
        /// <returns>The list of parent item models</returns>
        public IList<ParentItemModel> convertParentItemDomainObject(IList<ParentItem> parentItems) {
            var parentItemModels = new List<ParentItemModel>();

            foreach (var parentItem in parentItems)
            {
                parentItemModels.Add(convertParentItemDomainObject(parentItem));
            }

            return parentItemModels;
        }

        /// <summary>
        /// Convert a parent item to a patent item model
        /// </summary>
        /// <param name="parentItem">The parent item to convert</param>
        /// <returns>The parent item model</returns>
        public ParentItemModel convertParentItemDomainObject(ParentItem parentItem)
        {

            var parentItemModel = new ParentItemModel();
            parentItemModel.ParentItemid = parentItem.ParentItemid;
            parentItemModel.Name = parentItem.Name;
            parentItemModel.Description = parentItem.Description;

            foreach (var childItem in parentItem.ChildItems)
            {

                var newChildItem = new ChildItemModel();
                newChildItem.ChildItemId = childItem.ChildItemId;
                newChildItem.Name = childItem.Name;

                parentItemModel.ChildItems.Add(newChildItem);

            }

            return parentItemModel;

        }
    }
}