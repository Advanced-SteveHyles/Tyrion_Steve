
using System.Collections.Generic;

namespace Entities
{
    internal class PortfolioEnt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AccountEnt> Accounts { get; set; }
    }


    internal class AccountEnt
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Cash { get; set; }
        public decimal Valuation { get; set; }

        public int PortfolioId { get; set; }
        public string Type { get; set; }

    }

    internal class InvestmentMapEnt
    {
        public int AccountId { get; set; }
        public int InvestmentId { get; set; }
    }

    internal class InvestmentEnt
    {
        public int ID { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public string SubType2 { get; set; }
        public string Income { get; set; }
    }
}