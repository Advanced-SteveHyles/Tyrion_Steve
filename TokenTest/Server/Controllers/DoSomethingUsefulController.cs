using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Security;
using Server.Providers;

namespace Server.Controllers
{
    [Authorize]
    public class DoSomethingUsefulController : ApiController
    {

        [HttpPost]
        //[Authorize (Roles = "Fish")]
        [Authorize]
        public string Post([FromBody]object id)
        {
            var identity = (OAuthIdentity)RequestContext.Principal.Identity;
            
            return identity.Name;
        }
    }
}
