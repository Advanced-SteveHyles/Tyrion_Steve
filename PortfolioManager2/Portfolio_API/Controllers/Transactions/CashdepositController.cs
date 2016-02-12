﻿using System;
using System.Web.Http;
using System.Web.Http.Routing;
using BusinessLogic;
using BusinessLogic.Handlers;
using BusinessLogic.Transactions;
using Interfaces;
using PortfolioManager.DTO;
using PortfolioManager.DTO.DTOs.Transactions;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Interfaces;
using Portfolio_API.Controllers.Transactions;

namespace Portfolio_API.Controllers
{

    public class CashdepositController : ApiController
    {
        readonly ICashTransactionRepository _cashTransactionRepository;
        readonly IAccountRepository _accountRepository;


        public CashdepositController()
        {
            _cashTransactionRepository = new CashTransactionRepository(new PortfolioManagerContext());
            _accountRepository = new AccountRepository(new PortfolioManagerContext());
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

                var accountHandler = new AccountHandler(_accountRepository);
                var transactionHandler = new CashTransactionHandler(_cashTransactionRepository);

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
