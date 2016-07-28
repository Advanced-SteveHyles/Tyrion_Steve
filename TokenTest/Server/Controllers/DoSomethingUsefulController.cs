using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Server.Controllers
{
    public class DoSomethingUsefulController : ApiController
    {

        public DoSomethingUsefulController()
        {
            int i = 0;
        }

        // GET: api/DoSomethingUseful
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DoSomethingUseful/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DoSomethingUseful
        //[HttpPost]
        //public void Post([FromBody]string id, object thing)
        //{
        //    return;
        //}

       // [Authorize]
        [HttpPost]
        public void PostB([FromBody]string id)
        {
            return;
        }

    }
}
