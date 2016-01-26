﻿using System;

namespace PortfolioManager.DTO.Transactions
{
    public class InvestmentBuyDto
    {
        public int MapId;
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public bool UpdatePriceHistory { get; set; } = true;
    }
}