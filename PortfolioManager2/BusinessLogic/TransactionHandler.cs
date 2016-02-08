using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;
using PortfolioManager.Repository;

namespace BusinessLogicTests
{
    public class TransactionHandler : ITransactionHandler
    {
        private readonly ITransactionRepository _repository;

        public TransactionHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public void StoreTransaction(DepositTransactionRequest depositTransactionRequest)
        {
            _repository.AddCashTransaction
                (
                depositTransactionRequest.AccountId,
                depositTransactionRequest.TransactionDate,
                depositTransactionRequest.Source,
                depositTransactionRequest.Value,
                depositTransactionRequest.IsTaxRefund,
                "Deposit"
                );
        }

        public void StoreTransaction(WithdrawalTransactionRequest withdrawalTransactionRequest)
        {
            _repository.AddCashTransaction
                      (
                      withdrawalTransactionRequest.AccountId,
                      withdrawalTransactionRequest.TransactionDate,
                      withdrawalTransactionRequest.Source,
                      withdrawalTransactionRequest.Value,
                      false,
                      "Withdrawal"
                      );
        }
        
        public void StoreTransaction(int accountId, InvestmentBuyRequest investmentBuyRequest)
        {
            var depositTransaction = new DepositTransactionRequest()
            {
                AccountId = accountId,
                TransactionDate = investmentBuyRequest.PurchaseDate,
                Value = investmentBuyRequest.Value,
                Source = "Buy",
                IsTaxRefund = false,
            };

            StoreTransaction(depositTransaction);
        }
    }
}