﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.DTO
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string Name { get; set; }

        public int PortfolioId { get; set; }

        public decimal Cash { get; set; }
        public decimal Valuation { get; set; }

        public string Type { get; set; }

        public ICollection<InvestmentMapDto>  Investments { get; set; }
        public Decimal AccountBalance { get; set; }
    }
}