using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Interfaces;
using Newtonsoft.Json;
using PortfolioManager.DTO;

namespace PortfolioManagerWeb.Controllers
{
    public class AccountInvestmentMapController : Controller
    {
        public async Task<ActionResult> LinkInvestment(int accountId)
        {
            var client = PortfolioManagerHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync(ApiPaths.InvestmentMapper+ "/" + accountId);

            string content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var model = JsonConvert.DeserializeObject<AccountInvestmentMapDto>(content);
                return View(model);
            }

            return Content("An error occurred");            
        }

        public async Task<ActionResult> LinkInvestment()
        {
            throw new System.NotImplementedException();
        }
    }
}