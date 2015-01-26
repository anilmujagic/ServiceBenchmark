using ServiceBenchmark.Common;
using System;
using System.Web.Http;

namespace ServiceBenchmark.WebApi.Controllers
{
    public class ItemController : ApiController
    {
        public Item Get(Guid id)
        {
            //System.Diagnostics.Debug.WriteLine("Request for item " + id.ToString());
            return new Item(id, "Made in Web API");
        }
    }
}
