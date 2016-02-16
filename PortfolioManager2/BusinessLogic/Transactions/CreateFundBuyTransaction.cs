using BusinessLogic.Commands;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class CreateFundBuyTransaction : ICommandRunner
    {
        private readonly InvestmentBuyRequest _fundBuyRequest;
        private readonly IAccountHandler _accountHandler;
        private readonly ICashTransactionHandler _cashTransactionHandler;
        private readonly IAccountInvestmentMapHandler _accountInvestmentMapHandler;
        private readonly IFundTransactionHandler _fundTransactionHandler;
        private readonly IPriceHistoryHandler _priceHistoryHandler;
        private readonly IInvestmentHandler _investmentHandler;

        public CreateFundBuyTransaction(
            InvestmentBuyRequest fundBuyRequest,
            IAccountHandler accountHandler,
            ICashTransactionHandler cashTransactionHandler,
            IAccountInvestmentMapHandler accountInvestmentMapHandler,
            IFundTransactionHandler fundTransactionHandler,
            IPriceHistoryHandler priceHistoryHandler, IInvestmentHandler investmentHandler)
        {
            _fundBuyRequest = fundBuyRequest;
            _accountHandler = accountHandler;
            _cashTransactionHandler = cashTransactionHandler;
            _accountInvestmentMapHandler = accountInvestmentMapHandler;
            _fundTransactionHandler = fundTransactionHandler;
            _priceHistoryHandler = priceHistoryHandler;
            _investmentHandler = investmentHandler;
        }

        public void Execute()
        {
            
            var investmentMapDto = _accountInvestmentMapHandler.GetAccountInvestmentMap(_fundBuyRequest.InvestmentMapId);
            var investmentId = investmentMapDto.InvestmentId;
            var accountId = investmentMapDto.AccountId;

            _cashTransactionHandler.StoreCashTransaction(accountId, _fundBuyRequest);
            _fundTransactionHandler.StoreFundTransaction(_fundBuyRequest);            
            _accountHandler.DecreaseAccountBalance(accountId, _fundBuyRequest.Value);        
            _accountInvestmentMapHandler.ChangeQuantity(_fundBuyRequest.InvestmentMapId, _fundBuyRequest.Quantity);

            var investment = _investmentHandler.GetInvestment(accountId);

            var priceRequest = new PriceHistoryRequest
            {
                InvestmentId = investmentId,
                BuyPrice = _fundBuyRequest.Price,
                SellPrice = (investment.Type == "OEIC") ? _fundBuyRequest.Price : new decimal?(),
            };

            _priceHistoryHandler.StorePriceHistory(priceRequest);

            var revaluePriceTransaction = new RevalueSinglePriceCommand(
                investmentId,
                _fundBuyRequest.PurchaseDate, _priceHistoryHandler, _accountInvestmentMapHandler, _accountHandler );
            revaluePriceTransaction.Execute();

            ExecuteResult = true;
        }

        public bool CommandValid =>
            _fundBuyRequest.InvestmentMapId != 0;

        public bool ExecuteResult { get; private set; }

    }
}
