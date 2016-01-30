using System;
using PortfolioManager.DTO.Requests.Transactions;
using Interfaces;

namespace BusinessLogic
{
    public class CreateDepositTransaction : ICommandRunner
    {
        private DepositTransactionRequest _depositTransactionRequest;
        private readonly IAccountHandler _accountHandler;
        private readonly ITransactionHandler _transactionHandler;

        public CreateDepositTransaction(DepositTransactionRequest depositTransactionRequest, IAccountHandler accountHandler, ITransactionHandler transactionHandler)
        {
            this._depositTransactionRequest = depositTransactionRequest;
            _accountHandler = accountHandler;
            _transactionHandler = transactionHandler;
        }

        public void Execute()
        {
            // Write To Transaction Table
            _transactionHandler.StoreTransaction(_depositTransactionRequest);
            // Update Account
            _accountHandler.IncreaseBalance(_depositTransactionRequest.Value);
        }

        public bool CommandValid()
        {
            throw new NotImplementedException();
        }
    }
}
