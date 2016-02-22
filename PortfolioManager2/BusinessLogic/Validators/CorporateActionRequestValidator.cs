using System;
using PortfolioManager.DTO.Transactions;

namespace BusinessLogic.Validators
{
    public static class CorporateActionRequestValidator
    {
        public static bool Validate(this CorporateActionRequest request)
        {
            return request.InvestmentMapId != 0 &&
                   request.TransactionDate != DateTime.MinValue;
        }
    }
}