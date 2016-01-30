using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using PagedList;
using PortfolioManager.DTO;
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

            HttpResponseMessage response = await client.GetAsync("api/Investments?page=" + page + "&pagesize=5");
            //"?sort=expensegroupstatusid"+ ",title&page=" + page + "&pagesize=5");


            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                var pagingInfo = HeaderParser.FindAndParsePagingInfo(response.Headers);

                var investments = JsonConvert.DeserializeObject<IEnumerable<InvestmentDto>>(content);

                var pagedInvestmentsList = new StaticPagedList<InvestmentDto>(investments, pagingInfo.CurrentPage,
                pagingInfo.PageSize, pagingInfo.TotalCount);

                model.Investments = pagedInvestmentsList;
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
