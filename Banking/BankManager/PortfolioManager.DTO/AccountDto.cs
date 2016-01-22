using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.DTO
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Cash { get; set; }
        public decimal Valuation { get; set; }

        public string Type { get; set; }
    }
}
