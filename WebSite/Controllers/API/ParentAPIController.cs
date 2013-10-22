using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Template.Helpers.Converters;
using Template.Models;
using Template.Services.Interfaces;

namespace Template.Controllers
{
    public class ParentAPIController : ApiController
    {
        
        private IParentItemService _ParentItemService;


        public ParentAPIController(IParentItemService parentItemService)
        {
            _ParentItemService = parentItemService;
        }

 
        public IList<ParentItemModel> GetAllParents()
        {
            var converter = new ParentItemConverter();  
            var parentItems = converter.convertParentItemDomainObject(_ParentItemService.GetAllParentItem());
            return parentItems;
        }

    }
}
