using System;

namespace PortfolioManager.DTO.Transactions
{
    public static class CorporateActionRequestValidator
    {
        public static bool Validate(this CorporateActionRequest _request)
        {
            return _request.InvestmentMapId != 0 &&
                   _request.TransactionDate != DateTime.MinValue;
        }
    }
}