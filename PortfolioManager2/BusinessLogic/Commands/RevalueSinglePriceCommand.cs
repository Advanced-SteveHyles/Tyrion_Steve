using System;
using Interfaces;

namespace BusinessLogic.Commands
{
    public class RevalueSinglePriceCommand: ICommandRunner
    {
        private readonly IAccountInvestmentMapHandler _investmentMapHandler;
        private readonly IPriceHistoryHandler _priceHistoryHandler;
        private readonly IAccountHandler _accountHandler;
        private readonly int _investmentId;
        private readonly DateTime _valuationDate;


        public RevalueSinglePriceCommand(int investmentId, DateTime valuationDate, IPriceHistoryHandler priceHistoryHandler, IAccountInvestmentMapHandler investmentMapHandler, IAccountHandler accountHandler)
        {
            _investmentId = investmentId;
            _priceHistoryHandler = priceHistoryHandler;
            _investmentMapHandler = investmentMapHandler;
            _accountHandler = accountHandler;
            _valuationDate = valuationDate;            
        }

        public void Execute()
        {
            var currentSellPrice = _priceHistoryHandler.GetInvestmentSellPrice(_investmentId, _valuationDate);
            var accountsMappedToInvestment = _investmentMapHandler.GetMapsByInvestmentId(_investmentId);

            foreach (var map in accountsMappedToInvestment)
            {
                var currentValuation = map.Valuation??0;
                RemovePreviousValuationFromAccount(map.AccountId, currentValuation);

                var newValuation = _investmentMapHandler.RevalueMap(map.AccountInvestmentMapId, currentSellPrice);

                AddNewValuationToAccount(map.AccountId, newValuation);
            }

            ExecuteResult = true;
        }

        private void AddNewValuationToAccount(int accountId, decimal valuation)
        {
            _accountHandler.IncreaseValuation(accountId, valuation);
        }

        private void RemovePreviousValuationFromAccount(int accountId, decimal valuation)
        {
            _accountHandler.DecreaseValuation(accountId, valuation);
        }

        public bool CommandValid { get; }
        public bool ExecuteResult { get; private set; }
    }
}
