using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Server.Providers;

namespace Server.Controllers
{
    [Authorize]
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
       
        [HttpPost]
        public string PostB([FromBody]string id)
        {

            var identity = (OAuthIdentity)RequestContext.Principal.Identity;
            
            //FacadeSecurity.TokenStore(id)

            return identity.Name;
        }

    }
}
