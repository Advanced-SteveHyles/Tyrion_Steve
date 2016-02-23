using System.Runtime.Remoting.Contexts;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateWithdrawalTransaction : ICommandRunner
    {
        private readonly WithdrawalTransactionRequest _withdrawalTransactionRequest;
        private readonly IAccountHandler _accountHandler;
        private readonly ICashTransactionProcessor _transactionProcessor;

        public CreateWithdrawalTransaction(WithdrawalTransactionRequest withdrawalTransactionRequest,
            IAccountHandler accountHandler, ICashTransactionProcessor transactionProcessor)
        {
            this._withdrawalTransactionRequest = withdrawalTransactionRequest;
            _accountHandler = accountHandler;
            _transactionProcessor = transactionProcessor;
        }

        public void Execute()
        {
            _transactionProcessor.StoreCashTransaction(_withdrawalTransactionRequest);
            _accountHandler.DecreaseAccountBalance(
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