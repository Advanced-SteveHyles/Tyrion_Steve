using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Interfaces;
using Newtonsoft.Json;
using PortfolioManager.DTO.Requests.Transactions;

namespace PortfolioManagerWeb.Controllers
{
    public class InvestmentsMapController : Controller
    {
public ActionResult Sell(int id)
        {
            return View();
        }


        public async Task<ActionResult> Dividend(int id)
        {
            return View();
        }


        public ActionResult CorporateAction(int? investmentMapId)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CorporateAction(InvestmentCorporateActionRequest request)
        {
            try
            {
                var response = await ProcessCorporateActionTransaction(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Accounts", new { id = 1 });
                }
                else
                {
                    return Content("An error occurred");
                }
            }
            catch
            {
                return Content("An error occurred");
            }
        }

        public async Task<ActionResult> Resolves()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult> Resolve(object id)
        {
            throw new System.NotImplementedException();
        }
    
        
    private static async Task<HttpResponseMessage> ProcessCorporateActionTransaction(InvestmentCorporateActionRequest    corporateActionRequest)
    {
        var client = PortfolioManagerHttpClient.GetClient();

        var serializedItemToCreate = JsonConvert.SerializeObject(corporateActionRequest);

        var response = await client.PostAsync(ApiPaths.CorporateAction,
            new StringContent(serializedItemToCreate,
                System.Text.Encoding.Unicode, "application/json"));
        return response;
    }

    }
}