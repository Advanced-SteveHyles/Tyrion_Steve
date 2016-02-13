using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateFundBuyTransaction : ICommandRunner
    {
        private readonly int _accountId;
        private readonly InvestmentBuyRequest _fundBuyRequest;
        private readonly IAccountHandler _accountHandler;
        private readonly ITransactionHandler _transactionHandler;
        private readonly IAccountInvestmentMapHandler _accountInvestmentMapHandler;
        private IFundTransactionHandler _fundTransactionHandler;
        private readonly IPriceHistoryHandler _priceHistoryHandler;
        private IInvestmentHandler _investmentHandler;

        public CreateFundBuyTransaction(int accountId,
            InvestmentBuyRequest fundBuyRequest,
            IAccountHandler accountHandler,
            ITransactionHandler transactionHandler,
            IAccountInvestmentMapHandler accountInvestmentMapHandler,
            IFundTransactionHandler fundTransactionHandler,
            IPriceHistoryHandler priceHistoryHandler, IInvestmentHandler investmentHandler)
        {
            _accountId = accountId;
            _fundBuyRequest = fundBuyRequest;
            _accountHandler = accountHandler;
            _transactionHandler = transactionHandler;
            _accountInvestmentMapHandler = accountInvestmentMapHandler;
            _fundTransactionHandler = fundTransactionHandler;
            _priceHistoryHandler = priceHistoryHandler;
            _investmentHandler = investmentHandler;
        }

        public void Execute()
        {
            _fundTransactionHandler.StoreFundTransaction(_fundBuyRequest);
            _transactionHandler.StoreCashTransaction(_accountId, _fundBuyRequest);
            _accountHandler.DecreaseAccountBalance(_accountId, _fundBuyRequest.Value);        
            _accountInvestmentMapHandler.ChangeQuantity(_fundBuyRequest.InvestmentMapId, _fundBuyRequest.Quantity);

            var investment = _investmentHandler.GetInvestment(_accountId);

            var investmentId = _accountInvestmentMapHandler.GetAccountInvestmentMap(_fundBuyRequest.InvestmentMapId).InvestmentId;
            var priceRequest = new PriceHistoryRequest
            {
                InvestmentId = investmentId,
                BuyPrice = _fundBuyRequest.Price,                
            };
            priceRequest.SellPrice = (investment.Type == "OEIC") ? _fundBuyRequest.Price : new decimal?();

            _priceHistoryHandler.StorePriceHistory(priceRequest);

            ExecuteResult = true;
        }

        public bool CommandValid =>
            _fundBuyRequest.InvestmentMapId != 0 &&
            _accountId != 0
            ;

        public bool ExecuteResult { get; private set; }

    }
}
