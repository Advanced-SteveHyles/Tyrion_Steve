using System;
using System.Collections.Generic;
using Microsoft.Ajax.Utilities;

namespace PortfolioManagerWeb.Models
{
    public class InvestmentPriceUpdateList
    {
        public List<InvestmentPriceUpdate> Investments { get; } = new List<InvestmentPriceUpdate>();
    }

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