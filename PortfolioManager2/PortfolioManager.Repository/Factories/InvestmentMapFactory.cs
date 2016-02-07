using System;
using PortfolioManager.DTO.Requests;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository.Factories
{
    public  class InvestmentMapFactory
    {
        public static InvestmentMap CreateInvestmentMap(AccountInvestmentMapRequest investmentMapRequest)
        {
            return new InvestmentMap
            {
                AccountId = investmentMapRequest.AccountId,
                InvestmentId = investmentMapRequest.InvestmentId,

                InvestmentName = string.Empty,
                Quantity = 0,
                SellPrice = 0,
                Valuation = 0,
                LastValuationDate = DateTime.Today
            };
        }
    }
}