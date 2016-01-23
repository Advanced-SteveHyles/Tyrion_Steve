using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using PortfolioManager.DTO;
using PortfolioManagerWeb.Models;

namespace PortfolioManagerWeb.Controllers
{
    public class AccountsController : Controller
    {
        public async Task<ActionResult> Edit(int id)
        {
            return null;
        }

        public async Task<ActionResult> Details(int id)
        {
            var client = PortfolioManagerHttpClient.GetClient();

            HttpResponseMessage response = await client.GetAsync("api/accounts/" + id
                                + "?fields=name,investments");

            string content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var model = JsonConvert.DeserializeObject<AccountDto>(content);
                return View(model);
            }

            return Content("An error occurred");
        }
    }
}