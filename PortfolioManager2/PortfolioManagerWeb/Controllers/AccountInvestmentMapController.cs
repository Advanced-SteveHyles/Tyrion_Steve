using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Interfaces;
using Newtonsoft.Json;
using PortfolioManager.DTO;
using PortfolioManagerWeb.Models;

namespace PortfolioManagerWeb.Controllers
{
    public class AccountInvestmentMapController : Controller
    {
        public async Task<ActionResult> LinkInvestment(int accountId)
        {
            var client = PortfolioManagerHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync(ApiPaths.InvestmentMap + "/" + accountId);

            string content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var accountInvestmentMap = JsonConvert.DeserializeObject<AccountInvestmentMapDto>(content);
                return View(accountInvestmentMap);
            }

            return Content("An error occurred");
        }


        public async Task<ActionResult> LinkAccountToInvestment(int accountId, int investmentId)
        {
            throw new System.NotImplementedException();
        }
        
    }
}