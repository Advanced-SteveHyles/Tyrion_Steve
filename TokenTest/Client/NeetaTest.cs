using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Client
{
    class NeetaTest
    {
        private static void Neeta()
        {
            try
            {
            
                HttpClient client = new HttpClient();

                //client.BaseAddress = new Uri("https://uat-api.laserform.co.uk/users/authenticate");
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://uat-api.laserform.co.uk/users/authenticate");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent("{\"username\":\"neeta.achharsingh@oneadvanced.com\"," +
                                                    "\"password\":\"Passw0rd1\"}",
                    Encoding.UTF8,
                    "application/json");
                var result = client.PostAsync(request.RequestUri, request.Content);
                result.Wait();
                HttpResponseMessage response = result.Result;

                var jsonAuth = response.Content.ReadAsStringAsync().Result;

                //Label1.Text = "Auth String: " + jsonAuth.ToString();
                //Label2.Text = "StatusCode: " + response.StatusCode;
                //Label3.Text = "Authorization response: " + response.ToString();


                if (response.StatusCode.ToString() == "OK")
                {
                    //HttpClient client1 = new HttpClient();
                    //client1.DefaultRequestHeaders
                    //      .Accept
                    //      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer " + jsonAuth);

                    //HttpRequestMessage request1 = new HttpRequestMessage(HttpMethod.Post, "https://uat-api.laserform.co.uk/forms/opennewform");
                    //request1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //request1.Headers.Authorization = new AuthenticationHeaderValue("Bearer " + jsonAuth);

                    //request1.Content = new StringContent("{\"id\":\"" + Guid.NewGuid().ToString() + "\"," +
                    //                              "\"formType\":\"SDLT\"," +
                    //                              "\"clientReference\":\"CMR-123-456\"}",
                    //                                    Encoding.UTF8,
                    //                                    "application/json");

                    //var result1 = client.PostAsync(request1.RequestUri, request1.Content);
                    //result1.Wait();
                    //HttpResponseMessage response1 = result1.Result;


                    //Label4.Text = "OpenForm response: " + response1.ToString();

                    HttpClient client1 = new HttpClient();
                    client1.DefaultRequestHeaders
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var encoded = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(jsonAuth));
                    client1.DefaultRequestHeaders.Add("Authorization", "Bearer " + jsonAuth);
                    
                    HttpRequestMessage request1 = new HttpRequestMessage(HttpMethod.Post, "https://uat-api.laserform.co.uk/forms/opennewform");
                    //HttpRequestMessage request1 = new HttpRequestMessage(HttpMethod.Post, "http://stevelocal:31282/api/auth");
                    request1.Headers.Clear();
                    request1.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    //request1.Headers.Authorization = new AuthenticationHeaderValue("Bearer", encoded);
                    //request1.Headers.Add(HttpRequestHeader.Authorization.ToString(), "Bearer " + encoded);



                    var content = new StringContent("{\"id\":\"" + Guid.NewGuid().ToString() + "\"," +
                                                    "\"formType\": \"SDLT\"," +
                                                    "\"clientReference\": \"CMR-123-456\"}",
                        Encoding.UTF8,
                        "application/json");


                    content.Headers.Add("accept-type", "application/json");

                    request1.Content = content;

                    var result1 = client1.PostAsync(request1.RequestUri, request1.Content);
                    result1.Wait();
                    HttpResponseMessage response1 = result1.Result;


                    //Label4.Text = "OpenForm response: " + response1.ToString();

                }

            }
            catch (Exception Expt)
            {
                //    Label4.Text = Expt.Message + "     :-((((     ";
                //+ Expt.ToString();
            }
        }
    }
}