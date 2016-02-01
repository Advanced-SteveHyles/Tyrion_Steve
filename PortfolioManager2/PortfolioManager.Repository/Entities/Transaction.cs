using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioManager.Repository.Entities
{
    [Table ("Transaction")]
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Source { get; set; }
        public decimal Value { get; set; }
    }
}