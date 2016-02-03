using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Interfaces;
using PortfolioManager.DTO.DTOs.Transactions;
using PortfolioManager.Repository;

namespace Portfolio_API.Controllers.Transactions
{
    public class TransactionSummaryController : ApiController
    {
        readonly IPortfolioManagerRepository _repository;
        

        public TransactionSummaryController()
        {
            _repository = new PortfolioManagerEfRepository(new PortfolioManagerContext());
        }

        [Route(ApiPaths.AccountTransactions)]
        //public IHttpActionResult Get(int accountId, int page = 1, int  pageSize = ApiConstants.MaxPageSize)
        public IHttpActionResult Get(int accountId) //, int page = 1, int pageSize = ApiConstants.MaxPageSize)
        {
            try
            {
               var transactionEnt = _repository.GetAccountTransactions(accountId);
                
                var result = _repository.GetAccount(accountId);

                if (result != null)
                {

                    return Ok(ShapedData.CreateDataShapedObject(accountId, transactionEnt));
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
    }

    public class ApiConstants
    {
        public const int MaxPageSize = 10;
    }
}
