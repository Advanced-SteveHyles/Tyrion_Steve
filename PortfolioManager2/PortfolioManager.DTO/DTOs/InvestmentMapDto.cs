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

        public int Quantity { get; set; }
        public int SellPrice { get; set; }
        public int Valuation { get; set; }

        public DateTime LastValuationDate { get; set; }
    }
}