using System;
using System.Collections.Generic;

namespace PortfolioManager.DTO
{
    public class InvestmentMapDto
    {
        public int InvestmentMapId { get; set; }

        public int AccountId { get; set; }
        public int InvestmentId { get; set; }

        public string InvestmentName { get; set; }

        public decimal Quantity { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Valuation { get; set; }

        public DateTime LastValuationDate { get; set; }
    }
}