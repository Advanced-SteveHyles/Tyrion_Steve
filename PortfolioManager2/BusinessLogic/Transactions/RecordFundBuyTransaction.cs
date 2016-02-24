using System;
using System.Xml.Schema;
using BusinessLogic.Commands;
using BusinessLogic.Validators;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Transactions
{
    public class RecordFundBuyTransaction : ICommandRunner
    {
        private readonly InvestmentBuyRequest _fundBuyRequest;
        private readonly IAccountProcessor _accountProcessor;
        private readonly ICashTransactionProcessor _cashTransactionProcessor;
        private readonly IAccountInvestmentMapProcessor _accountInvestmentMapProcessor;
        private readonly IFundTransactionProcessor _fundTransactionProcessor;
        private readonly IPriceHistoryHandler _priceHistoryHandler;
        private readonly IInvestmentProcessor _investmentProcessor;

        public RecordFundBuyTransaction(
            InvestmentBuyRequest fundBuyRequest,
            IAccountProcessor accountProcessor,
            ICashTransactionProcessor cashTransactionProcessor,
            IAccountInvestmentMapProcessor accountInvestmentMapProcessor,
            IFundTransactionProcessor fundTransactionProcessor,
            IPriceHistoryHandler priceHistoryHandler, IInvestmentProcessor investmentProcessor)
        {
            _fundBuyRequest = fundBuyRequest;
            _accountProcessor = accountProcessor;
            _cashTransactionProcessor = cashTransactionProcessor;
            _accountInvestmentMapProcessor = accountInvestmentMapProcessor;
            _fundTransactionProcessor = fundTransactionProcessor;
            _priceHistoryHandler = priceHistoryHandler;
            _investmentProcessor = investmentProcessor;
        }

        public void Execute()
        {
            
            var investmentMapDto = _accountInvestmentMapProcessor.GetAccountInvestmentMap(_fundBuyRequest.InvestmentMapId);
            var investmentId = investmentMapDto.InvestmentId;
            var accountId = investmentMapDto.AccountId;

            _cashTransactionProcessor.StoreCashTransaction(accountId, _fundBuyRequest);
            _fundTransactionProcessor.StoreFundTransaction(_fundBuyRequest);            
            _accountInvestmentMapProcessor.ChangeQuantity(_fundBuyRequest.InvestmentMapId, _fundBuyRequest.Quantity);

            var investment = _investmentProcessor.GetInvestment(investmentId);

            var priceRequest = new PriceHistoryRequest
            {
                InvestmentId = investmentId,
                BuyPrice = _fundBuyRequest.Price,
                SellPrice = (investment.Class == PortfolioManager.Constants.Funds.FundClasses.Oeic) ? _fundBuyRequest.Price : new decimal?(),
                ValuationDate = _fundBuyRequest.PurchaseDate
            };

            _priceHistoryHandler.StorePriceHistory(priceRequest);

            var revaluePriceTransaction = new RevalueSinglePriceCommand(
                investmentId,
                _fundBuyRequest.PurchaseDate, _priceHistoryHandler, _accountInvestmentMapProcessor, _accountProcessor );
            revaluePriceTransaction.Execute();

            ExecuteResult = true;
        }

        public bool CommandValid => _fundBuyRequest.Validate();
            
        public bool ExecuteResult { get; private set; }
    }
    
}
