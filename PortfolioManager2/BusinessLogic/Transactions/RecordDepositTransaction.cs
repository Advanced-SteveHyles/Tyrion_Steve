using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogic.Transactions
{
    public class RecordDepositTransaction : ICommandRunner
    {
        private readonly DepositTransactionRequest _depositTransactionRequest;
        private readonly ICashTransactionProcessor _transactionProcessor;

        public RecordDepositTransaction(DepositTransactionRequest depositTransactionRequest, ICashTransactionProcessor transactionProcessor)
        {
            this._depositTransactionRequest = depositTransactionRequest;
            _transactionProcessor = transactionProcessor;
        }

        public void Execute()
        {            
            _transactionProcessor.StoreCashTransaction(_depositTransactionRequest);                                 
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
