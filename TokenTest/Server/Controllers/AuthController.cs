using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using Server.Providers;

namespace Server.Controllers
{
    public class AuthController : ApiController
    {
        // POST: api/Authenticate
        public HttpResponseMessage Post([FromBody]int id)
        {            
            var token = CreateToken(id);
            var jsonToken = new JavaScriptSerializer().Serialize(token);
            
            var httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, jsonToken);                        
            return httpResponseMessage;
        }

        ClientToken CreateToken(int id)
        {
            ClientToken token = null;
            if (id > 0)
            {
                token = new ClientToken
                {
                    UserId = Guid.NewGuid().ToString(),
                    TokenType = "bearer",
                    TokenCreated = (int)DateTime.Now.TimeOfDay.TotalSeconds,
                    IsClient = id ==1,
                    FullName = "Mr " + id.ToString()
                };
            }
            return token;
        }
    }
}
