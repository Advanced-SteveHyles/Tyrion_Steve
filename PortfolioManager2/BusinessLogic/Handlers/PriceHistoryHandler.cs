using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic
{
    public class PriceHistoryHandler : IPriceHistoryHandler
    {
        private IPriceHistoryRepository _priceHistoryRepository;

        public PriceHistoryHandler(IPriceHistoryRepository priceHistoryRepository)
        {
            this._priceHistoryRepository = priceHistoryRepository;
        }

        public void StorePriceHistory(PriceHistoryRequest priceHistoryRequest)
        {
            _priceHistoryRepository.InsertPriceHistory
                (
                priceHistoryRequest.InvestmentId,
                priceHistoryRequest.valuationDate,
                priceHistoryRequest.BuyPrice,
                priceHistoryRequest.SellPrice
                );
        }
    }
}