using System;
using System.Linq;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository.Interfaces
{
    public interface IPriceHistoryRepository
    {
        IQueryable<PriceHistory> GetInvestmentSellPrices(int investmentId);
        IQueryable<PriceHistory> GetInvestmentBuyPrices(int investmentId);
        void InsertPriceHistory(int investmentId, DateTime valuationDate, decimal? buyPrice, decimal? sellPrice);
    }
}