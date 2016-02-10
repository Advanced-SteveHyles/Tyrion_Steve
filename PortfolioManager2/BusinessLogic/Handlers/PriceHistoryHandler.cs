using Interfaces;
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
    }
}