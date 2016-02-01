using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.Repository;

namespace BusinessLogicTests
{
    public class TransactionHandler : ITransactionHandler
    {
        private readonly IPortfolioManagerRepository _repository;

        public TransactionHandler(IPortfolioManagerRepository repository)
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
                depositTransactionRequest.IsTaxRefund
                );
        }
    }
}