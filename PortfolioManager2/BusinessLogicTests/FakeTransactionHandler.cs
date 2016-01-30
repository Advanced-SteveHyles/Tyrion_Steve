using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogicTests
{
    class FakeTransactionHandler : ITransactionHandler
    {
        public void StoreTransaction(DepositTransactionRequest depositTransactionRequest)
        {
        }
    }
}