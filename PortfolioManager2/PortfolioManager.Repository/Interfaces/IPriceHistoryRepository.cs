namespace PortfolioManager.Repository.Interfaces
{
    public interface IPriceHistoryRepository
    {
        decimal GetInvestmentSellPrice(int investmentId);
    }
}