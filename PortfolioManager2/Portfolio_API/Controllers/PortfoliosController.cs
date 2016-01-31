using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using ExpenseTracker.Repository;
using PortfolioManager.DTO;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Entities;
using PortfolioManager.Repository.Factories;

namespace Portfolio_API.Controllers
{
    public class PortfoliosController : ApiController
    {
        const int MaxPageSize = 1;

        IPortfolioManagerRepository _repository;

        public PortfoliosController()
        {
            _repository = new PortfolioManagerEfRepository(new PortfolioManagerContext());
        }


        [Route("api/portfolios", Name = "PortfoliosList")]
        public IHttpActionResult Get(int page = 1, int pageSize = MaxPageSize)
        {
            try
            {
                // ensure the page size isn't larger than the maximum.
                if (pageSize > MaxPageSize)
                {
                    pageSize = MaxPageSize;
                }

                IQueryable<Portfolio> portfolios = _repository.GetPortfolios();

                // calculate data for metadata
                var totalCount = portfolios.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);
                var prevLink = page > 1 ? urlHelper.Link("PortfoliosList",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                    }) : "";
                var nextLink = page < totalPages ? urlHelper.Link("PortfoliosList",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                    }) : "";

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

                //return Ok(
                //    portfolios
                //    .Skip(pageSize * (page - 1))
                //    .Take(pageSize)
                //    );

                return Ok(
                    portfolios
                    );

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(int portfolioId, string fields = null)
        {
            try
            {
                bool includeAccounts = false;
                List<string> lstOfFields = new List<string>();

                // we should include expenses when the fields-string contains "expenses"
                if (fields != null)
                {
                    lstOfFields = fields.ToLower().Split(',').ToList();
                    includeAccounts = lstOfFields.Any(f => f.Contains("accounts"));
                }


                Portfolio portfolio = null;

                if (includeAccounts)
                {
                    portfolio = _repository.GetPortfolioWithAccounts(portfolioId);
                }
                else
                {
                    portfolio = _repository.GetPortfolio(portfolioId);
                }

                var result = _repository.GetPortfolios().SingleOrDefault(r => r.PortfolioId == portfolioId);

                if (result != null)
                {
                    return Ok(ShapedData.CreateDataShapedObject(portfolio, lstOfFields));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [System.Web.Http.HttpPost]
        [Route("api/portfolios")]
        public IHttpActionResult Post([FromBody] PortfolioRequest portfolio)
        {
            try
            {
                if (portfolio == null)
                {
                    return BadRequest();
                }

                var entityPortfolio = new PortfolioFactory().CreatePortfolio(portfolio);
                if (entityPortfolio == null)
                {
                    return BadRequest();
                }

                /*
                {
                    "userId": "https://expensetrackeridsrv3/embedded_1",
                    "title": "STV",
                    "description": "STV",
                    "expenseGroupStatusId": 1,
                }
                */

                var result = _repository.InsertPortfolio(entityPortfolio);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    var dtoPortfolio = EntityToDtoMap.MapPortfolioToDto(result.Entity);
                    return Created(Request.RequestUri + "/" + dtoPortfolio.PortfolioId, dtoPortfolio);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return InternalServerError();
            }
        }



    }

    public class ErrorLog
    {
        public static void LogError(Exception exception)
        {
            Console.Write(exception.Message);
        }
    }
}