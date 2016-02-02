using System;
using System.Web.Http;
using System.Web.Http.Routing;
using BusinessLogic.Transactions;
using BusinessLogicTests;
using Interfaces;
using PortfolioManager.DTO;
using PortfolioManager.DTO.DTOs.Transactions;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.Repository;
using Portfolio_API.Controllers.Transactions;

namespace Portfolio_API.Controllers
{

    public class CashdepositController : ApiController
    {
        readonly IPortfolioManagerRepository _repository;
       

        public CashdepositController()
        {
            _repository = new PortfolioManagerEfRepository(new PortfolioManagerContext());       
        }

        [Route(ApiPaths.CashDeposit)]//, Name = "PortfoliosList")]
        public IHttpActionResult Get(int page = 1)
        {
            return null;
        }

        [System.Web.Http.HttpPost]
        [Route(ApiPaths.CashDeposit)]
        public IHttpActionResult Post([FromBody] DepositTransactionRequest deposit)
        {
            try
            {
                if (deposit == null)
                {
                    return BadRequest();
                }

                //var entityAccount = new AccountFactory().CreateAccount(account);
                //if (entityAccount == null)
                //{
                //    return BadRequest();
                //}

                ///*
                //{
                //    "userId": "https://expensetrackeridsrv3/embedded_1",
                //    "title": "STV",
                //    "description": "STV",
                //    "expenseGroupStatusId": 1,
                //}
                //*/

                var accountHandler = new AccountHandler(_repository);
                var transactionHandler = new TransactionHandler(_repository);

                var status = Command.ExecuteCommand(new CreateDepositTransaction(deposit, accountHandler, transactionHandler));

                if (status)
                {                    
                    //var dtoTransaction = EntityToDtoMap.MapTransactionToDto(result.Entity);
                    return Created(Request.RequestUri + "/" + deposit.AccountId, new TransactionDto());
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
}
