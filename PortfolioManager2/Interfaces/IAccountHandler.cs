using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;

namespace Interfaces
{
    public interface IAccountHandler
    {
        void IncreaseBalance(int accountId, decimal amount);
        void DecreaseBalance(int accountId, decimal amount);
    }

    public interface ITransactionHandler
    {
        void StoreTransaction(DepositTransactionRequest depositTransactionRequest);
        void StoreTransaction(WithdrawalTransactionRequest withdrawalTransactionRequest);
        void StoreTransaction(int accountId, InvestmentBuyRequest investmentBuyRequest);
    }

    public interface IFundTransactionHandler
    {        
    }

    public interface IInvestmentMapHandler
    {
        void UpdateMapQuantity(int investmentMapId, decimal quantity);        
    }

}
