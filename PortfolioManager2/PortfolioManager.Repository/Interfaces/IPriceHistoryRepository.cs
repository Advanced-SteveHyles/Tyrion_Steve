using System;

namespace PortfolioManager.Repository.Interfaces
{
    public interface IPriceHistoryRepository
    {
        decimal? GetInvestmentSellPrice(int investmentId);
        decimal? GetInvestmentBuyPrice(int investmentId);
        void InsertPriceHistory(int investmentId, DateTime valuationDate, decimal? buyPrice, decimal? sellPrice);
    }
}