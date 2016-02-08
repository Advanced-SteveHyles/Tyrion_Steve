using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateFundBuyTransaction : ICommandRunner
    {
        private readonly InvestmentBuyRequest _request;
        private readonly IAccountHandler _accountHandler;
        private readonly ITransactionHandler _transactionHandler;
        private IFundTransactionHandler _fundTransactionHandler;

        public CreateFundBuyTransaction(InvestmentBuyRequest request, 
            IAccountHandler accountHandler, 
            ITransactionHandler transactionHandler, 
            IFundTransactionHandler fundTransactionHandler)
        {
            _request = request;
            _accountHandler = accountHandler;
            _transactionHandler = transactionHandler;
            _fundTransactionHandler = fundTransactionHandler;
        }

        public void Execute()
        {
            FundTransactionHandler.StoreTransaction(_request);
            _transactionHandler.StoreTransaction(_request);
            _accountHandler.DecreaseBalance(
                _request.AccountId,
                _request.Value);


            _mapHandler.ApplyBuyTransaction();

            ExecuteResult = true;
        }

        public bool CommandValid()
        {
            return
                _request.MapId != null;

        }

        public bool ExecuteResult { get; }

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
