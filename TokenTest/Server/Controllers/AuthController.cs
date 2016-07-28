using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Server.Controllers
{
    public class AuthController : ApiController
    {
        // POST: api/Authenticate
        public HttpResponseMessage Post([FromBody]int id)
        {            
            ClientToken token = CreateToken(id);
            var jsonToken = new JavaScriptSerializer().Serialize(token);
            
            var httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, jsonToken);
                        
            return httpResponseMessage;
        }
        
        public class ClientToken
        {
            public string access_token { get; set; }
            public string refresh_token { get; set; }
            public string token_type { get; set; }

            public int tokenIntData { get; set; }

            public long TokenCreated { get; set; }
        }

        ClientToken CreateToken(int id)
        {
            ClientToken token = null;
            if (id > 0)
            {
                token = new ClientToken
                {
                    access_token = Guid.NewGuid().ToString(),
                    refresh_token = Guid.NewGuid().ToString(),
                    token_type = "bearer",
                    TokenCreated = DateTime.Now.Ticks,
                    tokenIntData = id
                };
            }
            return token;
        }
    }
}
