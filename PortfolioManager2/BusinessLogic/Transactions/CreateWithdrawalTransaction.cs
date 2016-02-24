using System.Runtime.Remoting.Contexts;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateWithdrawalTransaction : ICommandRunner
    {
        private readonly WithdrawalTransactionRequest _withdrawalTransactionRequest;
        private readonly IAccountProcessor _accountProcessor;
        private readonly ICashTransactionProcessor _transactionProcessor;

        public CreateWithdrawalTransaction(WithdrawalTransactionRequest withdrawalTransactionRequest,
            IAccountProcessor accountProcessor, ICashTransactionProcessor transactionProcessor)
        {
            this._withdrawalTransactionRequest = withdrawalTransactionRequest;
            _accountProcessor = accountProcessor;
            _transactionProcessor = transactionProcessor;
        }

        public void Execute()
        {
            _transactionProcessor.StoreCashTransaction(_withdrawalTransactionRequest);
            
            ExecuteResult = true;
        }

        public bool ExecuteResult { get; set; }

        public bool CommandValid => _withdrawalTransactionRequest.AccountId > 0
                                    && _withdrawalTransactionRequest.Value > 0
                                    && _withdrawalTransactionRequest.TransactionDate != null
                                    && !string.IsNullOrWhiteSpace(_withdrawalTransactionRequest.Source);
    }
}