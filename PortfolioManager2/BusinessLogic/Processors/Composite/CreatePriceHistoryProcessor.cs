using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogic.Processors.Composite
{
    public class CreatePriceHistoryProcessor: ICommandRunner
{
        private readonly PriceHistoryRequest _priceHistoryRequest;
        private readonly IPriceHistoryHandler _priceHistoryHandler;

        public CreatePriceHistoryProcessor(PriceHistoryRequest priceHistoryRequest, IPriceHistoryHandler priceHistoryHandler)
        {
            _priceHistoryRequest = priceHistoryRequest;
            _priceHistoryHandler = priceHistoryHandler;        
        }

        public void Execute()
        {
            _priceHistoryHandler.StorePriceHistory(_priceHistoryRequest);

            ExecuteResult = true;
        }

        public bool CommandValid => _priceHistoryRequest.InvestmentId != 0;
        public bool ExecuteResult { get; private set; }
}

}
