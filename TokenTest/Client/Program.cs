using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

            //Console.WriteLine("**** CONSUME FAKE *****");
            //Consume("http://SteveLocal:31282/api/DoSomethingUseful", true);

            //Time Out
            Thread.Sleep(10000);

            Console.WriteLine("**** CONSUME REAL *****");
            Consume("http://localhost:31282/api/DoSomethingUseful", true);

            //Console.WriteLine("**** CONSUME NOT AUTHORISED *****");
            //Consume("http://localhost:31282/api/DoSomethingUseful", false);
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

        private static void Consume(string url, bool isSecure)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress =  new Uri(url);
                var auth = $"Bearer {_token}";

                if (isSecure)                    
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
