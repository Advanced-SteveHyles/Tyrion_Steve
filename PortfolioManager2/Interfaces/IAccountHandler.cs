using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;

namespace Interfaces
{
    public interface IAccountHandler
    {
        void IncreaseAccountBalance(int accountId, decimal amount);
        void DecreaseAccountBalance(int accountId, decimal amount);
    }

    public interface ITransactionHandler
    {
        void StoreCashTransaction(DepositTransactionRequest depositTransactionRequest);
        void StoreCashTransaction(WithdrawalTransactionRequest withdrawalTransactionRequest);
        void StoreCashTransaction(int accountId, InvestmentBuyRequest investmentBuyRequest);
    }

    public interface IFundTransactionHandler
    {
        void StoreFundTransaction(InvestmentBuyRequest fundBuyRequest);
    }

    public interface IAccountInvestmentMapHandler
    {
        void ChangeQuantity(int investmentMapId, decimal quantity);
        void RevalueMap(int investmentMapId);
    }

    public interface IPriceHistoryHandler
{
        void StorePriceHistory(PriceHistoryRequest priceHistoryRequest);
}

}
