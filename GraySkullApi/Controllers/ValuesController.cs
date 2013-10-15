using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Template.Domain;
using Template.Services.Interfaces;

namespace GraySkullApi.Controllers
{
    public class ValuesController : ApiController
    {

        private IParentItemService _ParentItemService;

        public ValuesController(IParentItemService parentItemService)
        {
            _ParentItemService = parentItemService;
        }

        // GET api/values
        public IList<ParentItem> Get()
        {

            var dataset = _ParentItemService.GetAllParentItem();
            
            return dataset;


        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}