﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioManager.Repository.Entities
{
    [Table ("AccountInvestmentMap")]
    public class AccountInvestmentMap
    {
        public int AccountInvestmentMapId { get; set; }

        public int AccountId { get; set; }
        public int InvestmentId { get; set; }
        public decimal Quantity { get; set; }        
        public int Valuation { get; set; }        
    }
}