using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
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
    public class PortfoliosController : Controller
    {
        public async Task<ActionResult> Index(int? page = 1)
        {

            var client = PortfolioManagerHttpClient.GetClient();

            var model = new PortfoliosViewModel();

            //HttpResponseMessage egsResponse = await client.GetAsync("api/expensegroupstatusses");

            //if (egsResponse.IsSuccessStatusCode)
            //{
            //    string egsContent = await egsResponse.Content.ReadAsStringAsync();
            //    var lstExpenseGroupStatusses = JsonConvert.DeserializeObject<IEnumerable<ExpenseGroupStatus>>(egsContent);
            //    model.ExpenseGroupStatusses = lstExpenseGroupStatusses;
            //}
            //else
            //{
            //    return System.Web.UI.WebControls.Content("An error occurred.");
            //}

            //string userId = (this.User.Identity as ClaimsIdentity).FindFirst("unique_user_key").Value;

            //HttpResponseMessage response = await client.GetAsync("api/expensegroups?sort=expensegroupstatusid"
            //    + ",title&page=" + page + "&pagesize=5&userid=" + userId);

            HttpResponseMessage response = await client.GetAsync("api/Portfolio");
                //"?sort=expensegroupstatusid"+ ",title&page=" + page + "&pagesize=5");


            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                // get the paging info from the header
                var pagingInfo = HeaderParser.FindAndParsePagingInfo(response.Headers);

                var portfolios = JsonConvert.DeserializeObject<IEnumerable<PortfolioDTO>>(content);

                var pagedExpenseGroupsList = new StaticPagedList<PortfolioDTO>(portfolios, pagingInfo.CurrentPage,
                    pagingInfo.PageSize, pagingInfo.TotalCount);

                model.Portfolios = pagedExpenseGroupsList;
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
