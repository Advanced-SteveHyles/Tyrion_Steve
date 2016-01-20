using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PortfolioManagerWeb.Helpers;
using PortfolioManagerWeb.Models;

namespace PortfolioManagerWeb.Controllers
{
    public class InvestmentsController : Controller
    {
        public async Task<ActionResult> Index(int? page = 1)
        {
            var client = PortfolioManagerHttpClient.GetClient();
            var model = new InvestmentsViewModel();

            HttpResponseMessage response = await client.GetAsync("api/Investments");
            //"?sort=expensegroupstatusid"+ ",title&page=" + page + "&pagesize=5");


            if (response.IsSuccessStatusCode)
            {
                var pagingInfo = HeaderParser.FindAndParsePagingInfo(response.Headers);

                //model.Investments = pagedExpenseGroupsList;
                model.PagingInfo = pagingInfo;
            }
            else
            {
                return Content("An error occurred.");
    }

            return View(model);
        }
    }
}
