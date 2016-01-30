using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioManager.Repository.Entities
{
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
}