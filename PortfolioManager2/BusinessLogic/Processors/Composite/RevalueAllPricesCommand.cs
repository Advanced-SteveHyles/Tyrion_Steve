using System;
using System.Linq;
using Interfaces;

namespace BusinessLogic.Commands
{
    public class RevalueAllPricesCommand : ICommandRunner
    {
        private readonly IAccountInvestmentMapProcessor _investmentMapProcessor;
        private readonly IInvestmentProcessor _investmentProcessor;
        private readonly IPriceHistoryHandler _priceHistoryHandler;
        private readonly IAccountProcessor _accountProcessor;
        private readonly DateTime _evaluationDate;
        
        public RevalueAllPricesCommand(DateTime evaluationDate, IAccountInvestmentMapProcessor investmentMapProcessor, IInvestmentProcessor investmentProcessor, IPriceHistoryHandler priceHistoryHandler, IAccountProcessor accountProcessor)
        {
            _investmentMapProcessor = investmentMapProcessor;
            _investmentProcessor = investmentProcessor;
            _priceHistoryHandler = priceHistoryHandler;
            _accountProcessor = accountProcessor;
            _evaluationDate = evaluationDate;
        }

        public void Execute()
        {            
            RevalueAllMaps();
            UpdateAllAccounts();           
            ExecuteResult = true;
        }

        private void UpdateAllAccounts()
        {
            foreach (var account in _accountProcessor.GetAccounts().ToList())
            {
                var investmentMaps = _investmentMapProcessor.GetMapsByAccountId(account.AccountId);
                var valuation = investmentMaps.Sum(inv => inv.Valuation) ?? 0;
                
                _accountProcessor.SetValuation(account.AccountId, valuation);
            }
        }

        private void RevalueAllMaps()
        {
            foreach (var investment in _investmentProcessor.GetInvestments().ToList())
            {
                RevalueMapsForInvestment(investment.InvestmentId);
            }
        }

        private void RevalueMapsForInvestment(int investmentId)
        {
            var investmentSellPriceAtDate = _priceHistoryHandler.GetInvestmentSellPrice(investmentId, _evaluationDate);
            var investmentMaps = _investmentMapProcessor.GetMapsByInvestmentId(investmentId);
            foreach (var map in investmentMaps)
            {
                _investmentMapProcessor.RevalueMap(map.AccountInvestmentMapId, investmentSellPriceAtDate);
            }
        }

        public bool CommandValid => true;
        public bool ExecuteResult { get; private set; }
    }
}