using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioManager.Repository.Entities
{
    [Table("FundTransaction")]
    public class FundTransaction
    {
        [Key]
        public int InvestmentMapId { get; set; }

        public int AccountId { get; set; }

        public string TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }
        public string Source { get; set; }

        public decimal Quantity { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }

        public decimal Charges { get; set; }
        public decimal TransactionValue { get; set; }
        public bool IsTaxRefund { get; set; }
    }
}