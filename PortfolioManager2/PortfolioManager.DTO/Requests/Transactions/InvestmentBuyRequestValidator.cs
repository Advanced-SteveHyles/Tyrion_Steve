using System;

namespace PortfolioManager.DTO.Transactions
{
    public static class InvestmentBuyRequestValidator
    {
        public static bool Validate(this InvestmentBuyRequest fundBuyRequest)
        {
            if (fundBuyRequest.SettlementDate < fundBuyRequest.PurchaseDate)
            {
                fundBuyRequest.SettlementDate = fundBuyRequest.PurchaseDate;
            }

            return fundBuyRequest.InvestmentMapId != 0 &&
                   fundBuyRequest.PurchaseDate != DateTime.MinValue;

        }
    }
}