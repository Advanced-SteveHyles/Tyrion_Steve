using System.Collections.Generic;

namespace PortfolioManager.DTO.DTOs.PriceUpdates
{
    public class InvestmentPriceUpdateList
    {
        public ICollection<InvestmentPriceUpdate> Investments { get; } = new List<InvestmentPriceUpdate>();
    }
}