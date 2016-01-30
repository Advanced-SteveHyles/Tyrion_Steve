﻿using System.Collections.Generic;

namespace PortfolioManager.DTO
{
    public class InvestmentMapDto
    {
        public int AccountId { get; set; }
        public int InvestmentId { get; set; }

        public string InvestmentName { get; set; }

        public int Quantity { get; set; }
        public int SellPrice { get; set; }
        public int Valuation { get; set; }
        public int Id { get; set; }        
    }
}