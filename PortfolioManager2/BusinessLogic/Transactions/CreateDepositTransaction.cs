using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateDepositTransaction : ICommandRunner
    {
        private readonly DepositTransactionRequest _depositTransactionRequest;
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
            _transactionHandler.StoreCashTransaction(_depositTransactionRequest);         
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
