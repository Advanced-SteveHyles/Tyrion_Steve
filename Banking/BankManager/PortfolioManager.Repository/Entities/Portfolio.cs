using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioManager.Repository.Entities
{
    [Table ("Portfolio")]
    public partial class Portfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }

    [Table ("Account")]
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Cash { get; set; }
        public decimal Valuation { get; set; }

        public int PortfolioId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<InvestmentMap> Investments { get; set; }
    }

    [Table ("InvestmentMap")]
    public class InvestmentMap
    {
        public int AccountId { get; set; }
        public int InvestmentId { get; set; }
        public string InvestmentName { get; set; }
        public int Quantity { get; set; }
        public int SellPrice { get; set; }
        public int Valuation { get; set; }
        public int Id { get; set; }
    }

    
}