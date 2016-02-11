using System;
using Interfaces;

namespace BusinessLogic.Transactions
{
    class RevaluePriceTransaction: ICommandRunner
    {
        private readonly IAccountInvestmentMapHandler _investmentMapHandler;
        private readonly IPriceHistoryHandler _priceHistoryHandler;
        private readonly IAccountHandler _accountHandler;
        private int _investmentId;
        private DateTime _valuationDate;


        public RevaluePriceTransaction(int investmentMapId, DateTime valuationDate, IPriceHistoryHandler priceHistoryHandler, IAccountInvestmentMapHandler investmentMapHandler, IAccountHandler accountHandler)
        {            
            _priceHistoryHandler = priceHistoryHandler;
            _investmentMapHandler = investmentMapHandler;
            _accountHandler = accountHandler;
            _valuationDate = valuationDate;
            var investmentMap = _investmentMapHandler.GetAccountInvestmentMap(investmentMapId);            
            _investmentId = investmentMap.InvestmentId;
        }

        public void Execute()
        {
            var currentSellPrice = _priceHistoryHandler.GetInvestmentSellPrice(_investmentId, _valuationDate);
            var accountsMappedToInvestment = _investmentMapHandler.GetMapsByInvestmentId(_investmentId);

            foreach (var map in accountsMappedToInvestment)
            {
                var mapValue = _investmentMapHandler.RevalueMap(map.AccountInvestmentMapId, currentSellPrice);

                _accountHandler.UpdateValuation(map.AccountId, mapValue);
            }

            ExecuteResult = true;
        }
    
        public bool CommandValid { get; }
        public bool ExecuteResult { get; private set; }
    }
}
