namespace PortfolioManager.DTO.Requests.Transactions
{
    public class PriceHistoryRequest
    {
        public int AccountInvestmentMapId { get; set; }
        public object valuationDate { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? BuyPrice { get; set; }
    }
}