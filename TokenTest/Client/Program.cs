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

            Console.WriteLine("**** CONSUME FAKE *****");
            Consume("http://SteveLocal:31282/api/DoSomethingUseful");

            Console.WriteLine("**** CONSUME REAL *****");
            Consume("http://localhost:31282/api/DoSomethingUseful");
        }

        private static async Task Authenticate()
        {
            using (var Client = new HttpClient())
            {
                var uri = "http://localhost:31282/api/Auth";
                HttpContent content;
                content = new StringContent("2", Encoding.UTF8);

                Client.DefaultRequestHeaders.Add("accept", "application/json");

                content.Headers.Clear();
                content.Headers.Add("content-type", "application/json");

                var result = Client.PostAsync(uri, content);
                result.Wait();
                HttpResponseMessage response = result.Result;
                
                _token = response.Content.ReadAsStringAsync().Result;                                
            }
        }

        private static void Consume(string url)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress =  new Uri(url);
                var auth = $"Bearer {_token}";
                Client.DefaultRequestHeaders.Add("Authorization", auth);

                HttpContent content = new StringContent("{\"id\": \"Bannana\"}", Encoding.UTF8);
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/json" );
                
                var response = Client.PostAsync(url, content);
                Task<string> inboundContent = response.Result.Content.ReadAsStringAsync();

                Console.WriteLine(response.Status);
                //Console.WriteLine(response.Result);
                Console.WriteLine(inboundContent.Result);
            }
        }
    }
}
