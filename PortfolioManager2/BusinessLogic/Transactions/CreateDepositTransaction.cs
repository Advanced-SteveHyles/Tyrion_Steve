using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateDepositTransaction : ICommandRunner
    {
        private readonly DepositTransactionRequest _depositTransactionRequest;
        private readonly IAccountHandler _accountHandler;
        private readonly ICashTransactionProcessor _transactionProcessor;

        public CreateDepositTransaction(DepositTransactionRequest depositTransactionRequest, IAccountHandler accountHandler, ICashTransactionProcessor transactionProcessor)
        {
            this._depositTransactionRequest = depositTransactionRequest;
            _accountHandler = accountHandler;
            _transactionProcessor = transactionProcessor;
        }

        public void Execute()
        {            
            _transactionProcessor.StoreCashTransaction(_depositTransactionRequest);         
            _accountHandler.IncreaseAccountBalance(
                _depositTransactionRequest.AccountId, 
                _depositTransactionRequest.Value);

            ExecuteResult = true;
        }

        public bool ExecuteResult { get; set; }

        public bool CommandValid
        {
            get 
            { 
            return _depositTransactionRequest.AccountId > 0
                   && _depositTransactionRequest.Value > 0
                   && _depositTransactionRequest.TransactionDate != null
                   && !string.IsNullOrWhiteSpace(_depositTransactionRequest.Source)                 
                   ;
            }

        }
    }
}
