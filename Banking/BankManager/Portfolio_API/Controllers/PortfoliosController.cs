
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using PortfolioManager.DTO;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Entities;

namespace Portfolio_API.Controllers
{
    public class PortfoliosController : ApiController
    {
        const int maxPageSize = 1;

        IPortfolioManagerRepository _repository;

        public PortfoliosController()
        {
            _repository = new PortfolioManagerEfRepository(new PortfolioManagerContext());
        }
        

        [Route("api/portfolios", Name = "PortfoliosList")]
        public IHttpActionResult Get(int page = 1, int pageSize = maxPageSize)
        {
            try
            {                
                // ensure the page size isn't larger than the maximum.
                if (pageSize > maxPageSize)
                {
                    pageSize = maxPageSize;
                }

                IQueryable<Portfolio> portfolios = _repository.GetPortfolios();

                // calculate data for metadata
                var totalCount = portfolios.Count() ;
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
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //public IHttpActionResult Get(int id, string fields = null)
        //{
        //    try
        //    {
        //        bool includeAccounts = false;
        //        List<string> lstOfFields = new List<string>();

        //        // we should include expenses when the fields-string contains "expenses"
        //        if (fields != null)
        //        {
        //            lstOfFields = fields.ToLower().Split(',').ToList();
        //            includeAccounts = lstOfFields.Any(f => f.Contains("accounts"));
        //        }


        //        IQueryable<Portfolio> portfolios = _repository.GetPortfolio();
                
        //        if (includeAccounts)
        //        {
        //            //_repository.GetPortfolioWithAccounts();
        //        }
        //        else
        //        {
        //            portfolios = _repository.GetPortfolios();
        //        }

        //        var result = FakeData.GetPortfolios().SingleOrDefault(r => r.Id == id);
              
        //        if (result != null)
        //        {

        //            return Ok(ShapedData.CreateDataShapedObject(portfolioEnt, lstOfFields));                    
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError();
        //    }
        //}
    }
}



