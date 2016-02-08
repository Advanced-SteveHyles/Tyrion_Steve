using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using PortfolioManager.DTO.DTOs;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateFundBuyTransaction : ICommandRunner
    {
        private readonly int _accountId;
        private readonly InvestmentBuyRequest _fundBuyRequest;
        private readonly IAccountHandler _accountHandler;
        private readonly ITransactionHandler _transactionHandler;
        private IFundTransactionHandler _fundTransactionHandler;

        public CreateFundBuyTransaction(int accountId,
            InvestmentBuyRequest fundBuyRequest, 
            IAccountHandler accountHandler)//, 
            //ITransactionHandler transactionHandler) 
            //IFundTransactionHandler fundTransactionHandler)
        {
            _accountId = accountId;
            _fundBuyRequest = fundBuyRequest;
            _accountHandler = accountHandler;
          //  _transactionHandler = transactionHandler;
            //_fundTransactionHandler = fundTransactionHandler;
        }

        public void Execute()
        {
            //FundTransactionHandler.StoreTransaction(_request);
            //_transactionHandler.StoreTransaction(_request);
            _accountHandler.DecreaseBalance(
                _accountId,
                _fundBuyRequest.Value);


            //_mapHandler.ApplyBuyTransaction();

            ExecuteResult = true;
        }

        public bool CommandValid => 
            _fundBuyRequest.MapId != 0 && 
            _accountId != 0
            ;


        public bool ExecuteResult { get; private set; }

        public IFundTransactionHandler FundTransactionHandler
        {
            get
            {
                return _fundTransactionHandler;
            }

            set
            {
                _fundTransactionHandler = value;
            }
        }
    }
}
