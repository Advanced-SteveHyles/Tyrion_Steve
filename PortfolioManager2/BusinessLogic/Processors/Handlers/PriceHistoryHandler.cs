using System;
using System.Linq;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic.Processors.Handlers
{
    public class PriceHistoryHandler : IPriceHistoryHandler
    {
        private readonly IPriceHistoryRepository _priceHistoryRepository;

        public PriceHistoryHandler(IPriceHistoryRepository priceHistoryRepository)
        {
            this._priceHistoryRepository = priceHistoryRepository;
        }

        public void StorePriceHistory(PriceHistoryRequest priceHistoryRequest)
        {
            _priceHistoryRepository.InsertPriceHistory
                (
                priceHistoryRequest.InvestmentId,
                priceHistoryRequest.ValuationDate,
                priceHistoryRequest.BuyPrice,
                priceHistoryRequest.SellPrice
                );
        }

        public decimal? GetInvestmentSellPrice(int investmentId, DateTime valuationDate)
        {
            var prices = _priceHistoryRepository
                .GetInvestmentSellPrices(investmentId)
                .Where(ip => ip.ValuationDate <= valuationDate && ip.InvestmentId == investmentId)
                .OrderByDescending(ip=>ip.ValuationDate);

            return prices.FirstOrDefault()?.SellPrice ?? null;
        }

        public decimal? GetInvestmentBuyPrice(int investmentId, DateTime valuationDate)
        {
            var prices = _priceHistoryRepository
                .GetInvestmentSellPrices(investmentId)
                .Where(ip => ip.ValuationDate <= valuationDate && ip.InvestmentId == investmentId)
                .OrderByDescending(ip => ip.ValuationDate);

            return prices.FirstOrDefault()?.BuyPrice ?? null;
        }
    }
}