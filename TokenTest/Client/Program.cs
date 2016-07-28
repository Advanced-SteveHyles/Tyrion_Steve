using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static string _token;

        static void Main(string[] args)
        {

            //Neeta();

            Console.WriteLine("**** AUTH *****");
            Authenticate();

            Console.WriteLine("**** CONSUME *****");
            Consume();
            
        }
        
        private static async Task Authenticate()
        {
            using (var Client = new HttpClient())
            {
                var uri = "http://localhost:31282/api/Auth";
                HttpContent content;
                content = new StringContent("1", Encoding.UTF8);

                Client.DefaultRequestHeaders.Add("accept", "application/json");

                content.Headers.Clear();
                content.Headers.Add("content-type", "application/json");

                var result = Client.PostAsync(uri, content);
                result.Wait();
                HttpResponseMessage response = result.Result;
                
                _token = response.Content.ReadAsStringAsync().Result;                                
            }
        }

        private static void Consume()
        {
            using (var Client = new HttpClient())
            {
                //var uri = "http://SteveLocal:31282/api/DoSomethingUseful";
                var uri = "http://localhost:31282/api/DoSomethingUseful";

                Client.BaseAddress =  new Uri(uri);
                var auth = $"Bearer {_token}";
                //Client.DefaultRequestHeaders.Add("Authorization", auth);

                HttpContent content = new StringContent("{\"id\": \"Bannana\"}", Encoding.UTF8);
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/json" );
                
                var response = Client.PostAsync(uri, content);

                Console.WriteLine(response.Status);
                Console.WriteLine(response.Result);
            }
        }
    }
}
