using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using DebtsModel.DTO;

namespace DebtsModel.DataAccess
{
    public class DebtDataSource
    {
        private readonly string _fieldsApiUrl;
        private readonly APICredentials _apiCredentials;

        public DebtDataSource(string fieldsApiUrl, APICredentials apiCredentials)
        {
            _fieldsApiUrl = fieldsApiUrl;
            _apiCredentials = apiCredentials;
        }

        public Debt FindDebtByMatterId(Guid matterId, List<string> fqnList)
        {
            var fqnTypemappings = fqnList;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_fieldsApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", _apiCredentials.Username, _apiCredentials.Password)))); //TODO


                var response =
                    client.GetAsync($"fields/matter/{matterId}?fqns=" + string.Join(",", fqnTypemappings)).Result;

                var jsonMatter = response.Content.ReadAsStringAsync().Result;

                var fields = Newtonsoft.Json.JsonConvert.DeserializeObject<ReadFqnResult>(jsonMatter);

                Func<ReadFqnResult, string, object> map = (fieldresult, s) =>
                {
                    return (fieldresult.Values.ContainsKey(s) ? fieldresult.Values.FirstOrDefault(f => f.Key == s).Value : null);
                };

                return new Debt {
                    ClaimNumber = (string)map(fields, "Matter.debt_claim_number_ud"),
                    OriginalDebt = (double?)map(fields, "Matter.debt_orig_debt_bal_ud"),
                    //CurrentMilestone = (string)map(fields, "Matter.debt_HeaderCurrentposition_ud"),
                    DateOfService = (DateTime?)map(fields, "Matter.debt_n1_date_of_service_ud"),
                    TotalCosts = (double?)map(fields, "Matter.debt_tot_enf_costs_ud"),
                    Interest = (double?)map(fields, "Matter.debt_Totalinterestappliedtothismatter_ud"),
                    Disbursements = (double?)map(fields, "Matter.debt_Totalfeesforthematter_ud"),
                    PaidToDate = (double?)map(fields, "Matter.debt_Totalpaymentsforthismatter_ud"),
                    CurrentBalance = (double?)map(fields, "Matter.debt_summary_balance_ud")
                };
            }
        }
    }

    public class APICredentials 
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public APICredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}