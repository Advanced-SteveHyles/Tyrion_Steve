using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using FacadeAPI.Helpers;
using Newtonsoft.Json;

namespace Legal.PortalFacade.Controllers
{
    //[EnableCorsForFacade]
    public class AuthenticationController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody] ClientLoginCredentials id)
        {
            HttpResponseMessage results;
            //using (var client = new HttpClient(new HttpClientHandler {AllowAutoRedirect = false}))
            //{
            //    //var uri = new Uri(ConfigurationManager.AppSettings["AuthenticationApi"]);
            //    //client.BaseAddress = uri;
            //    //client.DefaultRequestHeaders.Clear();

            //    var credentials = new AuthenticationLoginCredentials()
            //    {
            //        Password = id.password,
            //        Username = id.username
            //    };

            //    var content = new StringContent(JsonConvert.SerializeObject(credentials));
            //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //    results = await client.PostAsync(uri, content);
            //}

            //if (results.IsSuccessStatusCode)
            //{
            //var user = JsonConvert.DeserializeObject<User>(await results.Content.ReadAsStringAsync());
            var user = new User();
                var accessToken = new ClientUser();

                var serverToken = new ServerToken
                {
                    TokenType = "Bearer",
                    UserId = user.Id.ToString()
                };

                var encryptedToken = JsonAuthorization.Encrypt(serverToken);
                accessToken.Name = user.Name;
                accessToken.Token = encryptedToken;

            //return Request.CreateResponse(results.StatusCode, accessToken);
            return Request.CreateResponse(HttpStatusCode.OK, accessToken);
            //}

            return new HttpResponseMessage(results.StatusCode) {Content = results.Content};
        }

        //private static async Task<string> ResolveFirmName()
        //{
        //    var query =
        //            @"{
        //                firmdetail
	       //             {    
        //                    name  
        //                }
        //            }";

        //    return await GetFirmData(query);
        //}

        //private static async Task<string> GetFirmData(string query)
        //{
        //    var httpResponseMessage = await GraphQlPortal.ReturnData(query);
        //    var result = await httpResponseMessage.Content.ReadAsStringAsync();
        //    var content = JsonConvert.DeserializeObject<FirmnameDtoObjects.JsonObject>(result);
        //    return content.data.firmdetail.name;
        //}
    }

    public class ServerToken
    {
        public string TokenType { get; set; }
        public string UserId { get; set; }
    }

    public class ClientUser
    {
        public string Name { get; set; }
        public string Token { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; } =new Guid();
        public string Name { get; set; } = "Steve";
    }

    public class AuthenticationLoginCredentials
    {
    }

    public class ClientLoginCredentials
    {
        public string password;
        public string username;
    }
}