using System;

namespace PortfolioManager.DTO.DTOs.PriceUpdates
{
    public class InvestmentPriceUpdate
    {
        public string InvestmentName { get; set; }
        public decimal LatestSellPrice { get; set; }
        public DateTime LatestSellPriceDate { get; set; }

        public decimal LatestBuyPrice { get; set; }
        public DateTime LatestBuyPriceDate { get; set; }

        public string NewBuyPrice { get; set; }
        public string NewSellPrice { get; set; }
    }
}
