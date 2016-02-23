using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using PortfolioManager.DTO;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic.Handlers
{
    public class InvestmentHandler : IInvestmentHandler
    {
        private readonly IInvestmentRepository _repository;

        public InvestmentHandler(IInvestmentRepository investmentRepository)
        {
            this._repository = investmentRepository;
        }

        public InvestmentDto GetInvestment(int investmentId)
        {
            return _repository.GetInvestment(investmentId).MapToDto();
        }

        public IEnumerable<InvestmentDto> GetInvestments()
        {
            return _repository.GetInvestments().Select(inv=>inv.MapToDto());
        }
    }

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