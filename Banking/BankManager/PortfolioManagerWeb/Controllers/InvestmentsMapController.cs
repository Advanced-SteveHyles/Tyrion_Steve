using System.Threading.Tasks;
using System.Web.Mvc;

namespace PortfolioManagerWeb.Controllers
{
    public class InvestmentsMapController : Controller
    {

        public async Task<ActionResult> Buy(int id)
        {
            return View();
        }


        public async Task<ActionResult> Sell(int id)
        {
            return null;
        }


        public async Task<ActionResult> Dividend(int id)
        {
            return null;
        }

    }
}