﻿using BusinessLogicTests;
using Interfaces;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateFundBuyTransaction : ICommandRunner
    {
        private readonly int _accountId;
        private readonly InvestmentBuyRequest _fundBuyRequest;
        private readonly IAccountHandler _accountHandler;
        private readonly ITransactionHandler _transactionHandler;
        private readonly IInvestmentMapHandler _investmentMapHandler;

        public CreateFundBuyTransaction(int accountId,
            InvestmentBuyRequest fundBuyRequest, 
            IAccountHandler accountHandler, 
            ITransactionHandler transactionHandler,
            IInvestmentMapHandler investmentMapHandler)
            //IFundTransactionHandler fundTransactionHandler)
        {
            _accountId = accountId;
            _fundBuyRequest = fundBuyRequest;
            _accountHandler = accountHandler;
            _transactionHandler = transactionHandler;
            _investmentMapHandler = investmentMapHandler;
            //_fundTransactionHandler = fundTransactionHandler;
        }

        public void Execute()
        {
            //FundTransactionHandler.StoreTransaction(_request);

            _transactionHandler.StoreTransaction(_accountId, _fundBuyRequest);

            _accountHandler.DecreaseBalance(
                _accountId,
                _fundBuyRequest.Value);

            _investmentMapHandler.UpdateMapQuantity(_fundBuyRequest.InvestmentMapId, _fundBuyRequest.Quantity);

            //_mapHandler.ApplyBuyTransaction();

            ExecuteResult = true;
        }

        public bool CommandValid => 
            _fundBuyRequest.InvestmentMapId != 0 && 
            _accountId != 0
            ;


        public bool ExecuteResult { get; private set; }

        public IFundTransactionHandler FundTransactionHandler { get; set; }
    }
}