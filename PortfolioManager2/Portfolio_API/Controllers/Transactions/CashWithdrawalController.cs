using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Antlr.Runtime.Tree;
using BusinessLogic.Transactions;
using BusinessLogicTests;
using Interfaces;
using PortfolioManager.DTO;
using PortfolioManager.DTO.DTOs.Transactions;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.Repository;

namespace Portfolio_API.Controllers.Transactions
{
public class CashWithdrawalController : ApiController
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IAccountRepository _accountRepository;
        public CashWithdrawalController()
        {
            _transactionRepository = new TransactionRepository(new PortfolioManagerContext());
            _accountRepository = new AccountRepository(new PortfolioManagerContext());
        }


        [System.Web.Http.HttpPost]
        [Route(ApiPaths.CashWithdrawal)]
        public IHttpActionResult Post([FromBody] WithdrawalTransactionRequest  withdrawal)
        {
            try
            {
                if (withdrawal == null)
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

                var accountHandler = new AccountHandler(_accountRepository);
                var transactionHandler = new TransactionHandler(_transactionRepository);

                var status = Command.ExecuteCommand(new CreateWithdrawalTransaction(withdrawal, accountHandler, transactionHandler));

                if (status)
                {
                    //var dtoTransaction = EntityToDtoMap.MapTransactionToDto(result.Entity);
                    return Created(Request.RequestUri + "/" + withdrawal.AccountId, new TransactionDto());
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
