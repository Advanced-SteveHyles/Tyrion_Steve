using System;

namespace PortfolioManager.DTO.Transactions
{
    public class CorporateActionRequest
    {
        public int InvestmentMapId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}