using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PortfolioManager.DTO.Requests.Transactions;

namespace Portfolio_API.Controllers.Transactions
{
    public class CashDepositController : ApiController
    {
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

                //var result = _repository.InsertAccount(entityAccount);
                //if (result.Status == RepositoryActionStatus.Created)
                //{
                //    var dtoAccount = EntityToDtoMap.MapAccountToDto(result.Entity);
                //    return Created(Request.RequestUri + "/" + dtoAccount.AccountId, dtoAccount);
                //}
                //else
                //{
                return BadRequest();
                //}

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return InternalServerError();
            }
        }
    }
}
