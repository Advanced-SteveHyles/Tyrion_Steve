using System;

namespace PortfolioManagerWeb.Models
{
    public class InvestmentBuyDTO
    {
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}