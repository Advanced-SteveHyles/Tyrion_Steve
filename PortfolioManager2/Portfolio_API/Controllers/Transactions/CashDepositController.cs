using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic;
using BusinessLogicTests;
using ExpenseTracker.Repository;
using PortfolioManager.DTO;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.Repository;

namespace Portfolio_API.Controllers.Transactions
{    

    public class CashDepositController : ApiController
    {
        readonly IPortfolioManagerRepository _repository;
        public CashDepositController()
        {
            _repository = new PortfolioManagerEfRepository(new PortfolioManagerContext());
        }

        [System.Web.Http.HttpPost]
        [Route("api/transactions/cashdeposit")]
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

                var status = ExecuteCommand(new CreateDepositTransaction(deposit, accountHandler, transactionHandler));

                if (status)
                {
                    var dtoTransaction = new TransactionDTO();
                    //var dtoTransaction = EntityToDtoMap.MapTransactionToDto(result.Entity);
                    return Created(Request.RequestUri, dtoTransaction); // + "/" + dtoTransaction.TransactionId, dtoTransaction);
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

        private bool ExecuteCommand(CreateDepositTransaction command)
        {
            try
            {
                if (command.CommandValid())
                {
                    command.Execute();
                    return command.ExecuteResult;
                }
                return false;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return false;
            }            
        }
    }
}
