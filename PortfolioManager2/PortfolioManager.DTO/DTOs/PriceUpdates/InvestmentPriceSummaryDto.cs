using System;

namespace PortfolioManager.DTO.DTOs.PriceUpdates
{
    public class InvestmentPriceUpdateRequest
    {
        public int InvestmentId { get; set; }

        public decimal? NewBuyPrice { get; set; }
        public decimal? NewSellPrice { get; set; }
    }

    public class InvestmentPriceSummaryDto
    {
        public int InvestmentId { get; set; }

        public string InvestmentName { get; set; }
        public decimal LatestSellPrice { get; set; }
        public DateTime LatestSellPriceDate { get; set; }

        public decimal LatestBuyPrice { get; set; }
        public DateTime LatestBuyPriceDate { get; set; }        
    }
}
