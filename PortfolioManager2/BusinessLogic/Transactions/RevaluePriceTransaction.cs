using System;
using Interfaces;

namespace BusinessLogic.Transactions
{
    public class RevaluePriceTransaction: ICommandRunner
    {
        private readonly IAccountInvestmentMapHandler _investmentMapHandler;
        private readonly IPriceHistoryHandler _priceHistoryHandler;
        private readonly IAccountHandler _accountHandler;
        private int _investmentId;
        private DateTime _valuationDate;


        public RevaluePriceTransaction(int investmentId, DateTime valuationDate, IPriceHistoryHandler priceHistoryHandler, IAccountInvestmentMapHandler investmentMapHandler, IAccountHandler accountHandler)
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
                RemovePreviousValuationFromAccount(map.AccountId, map.Valuation);

                var mapValue = _investmentMapHandler.RevalueMap(map.AccountInvestmentMapId, currentSellPrice);

                AddNewValuationToAccount(map.AccountId, mapValue);
            }

            ExecuteResult = true;
        }

        private void AddNewValuationToAccount(int accountId, decimal mapValue)
        {
            _accountHandler.IncreaseValuation(accountId, mapValue);
        }

        private void RemovePreviousValuationFromAccount(int accountId, decimal valuation)
        {
            _accountHandler.DecreaseValuation(accountId, valuation);
        }

        public bool CommandValid { get; }
        public bool ExecuteResult { get; private set; }
    }
}
