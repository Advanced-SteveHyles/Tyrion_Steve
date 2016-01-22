using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using PortfolioManager.DTO;

namespace Portfolio_API.Controllers
{
    public class InvestmentsController : ApiController
    {
        const int maxPageSize = 2;

        [Route("api/investments", Name = "InvestmentsList")]
        public IHttpActionResult Get(int page = 1, int pageSize = maxPageSize)
        {
            try
            {
                var results = FakeData.GetInvestments();
                // ensure the page size isn't larger than the maximum.
                if (pageSize > maxPageSize)
                {
                    pageSize = maxPageSize;
                }

                // calculate data for metadata
                var totalCount = results.Count;
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);
                var prevLink = page > 1
                    ? urlHelper.Link("InvestmentsList",
                        new
                        {
                            page = page - 1,
                            pageSize = pageSize,
                        })
                    : "";
                var nextLink = page < totalPages
                    ? urlHelper.Link("InvestmentsList",
                        new
                        {
                            page = page + 1,
                            pageSize = pageSize,
                        })
                    : "";

                var paginationHeader = new
                {
                    currentPage = page,
                    pageSize = pageSize,
                    totalCount = totalCount,
                    totalPages = totalPages,
                    previousPageLink = prevLink,
                    nextPageLink = nextLink
                };


                HttpContext.Current.Response.Headers.Add("X-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));


                return Ok(
                        results
                        .Skip(pageSize * (page - 1))
                        .Take(pageSize)
                        );

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}