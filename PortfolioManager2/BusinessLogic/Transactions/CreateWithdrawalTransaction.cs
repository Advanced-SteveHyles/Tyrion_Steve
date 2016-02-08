using System.Runtime.Remoting.Contexts;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateWithdrawalTransaction : ICommandRunner
    {
        private readonly WithdrawalTransactionRequest _withdrawalTransactionRequest;
        private readonly IAccountHandler _accountHandler;
        private readonly ITransactionHandler _transactionHandler;

        public CreateWithdrawalTransaction(WithdrawalTransactionRequest withdrawalTransactionRequest,
            IAccountHandler accountHandler, ITransactionHandler transactionHandler)
        {
            this._withdrawalTransactionRequest = withdrawalTransactionRequest;
            _accountHandler = accountHandler;
            _transactionHandler = transactionHandler;
        }

        public void Execute()
        {
            _transactionHandler.StoreTransaction(_withdrawalTransactionRequest);
            _accountHandler.DecreaseBalance(
                _withdrawalTransactionRequest.AccountId,
                _withdrawalTransactionRequest.Value);

            ExecuteResult = true;
        }

        public bool ExecuteResult { get; set; }

        public bool CommandValid => _withdrawalTransactionRequest.AccountId > 0
                                    && _withdrawalTransactionRequest.Value > 0
                                    && _withdrawalTransactionRequest.TransactionDate != null
                                    && !string.IsNullOrWhiteSpace(_withdrawalTransactionRequest.Source);
    }
}