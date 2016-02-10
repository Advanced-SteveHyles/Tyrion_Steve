using System;

namespace PortfolioManager.DTO.Requests.Transactions
{
    public class PriceHistoryRequest
    {
        public int InvestmentId { get; set; }
        public DateTime valuationDate { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? BuyPrice { get; set; }
    }
}