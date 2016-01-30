using PortfolioManager.DTO.Requests.Transactions;

namespace Interfaces
{
    public interface IAccountHandler
    {
        decimal Balance { get; set; }

        void IncreaseBalance(decimal amount);
    }

    public interface ITransactionHandler
    {
        void StoreTransaction(DepositTransactionRequest depositTransactionRequest);
    }

}