using PortfolioManager.DTO.Requests.Transactions;

namespace Interfaces
{
    public interface IAccountHandler
    {
        void IncreaseBalance(int accountId, decimal amount);
    }

    public interface ITransactionHandler
    {
        void StoreTransaction(DepositTransactionRequest depositTransactionRequest);
    }

}