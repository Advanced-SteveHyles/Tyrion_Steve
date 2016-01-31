using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Repository.Entities
{
    [Table ("Investment")]
    public class Investment
    {
            public int InvestmentId { get; set; }
            public string Name { get; set; }

            public string Symbol { get; set; }

            public string Type { get; set; }
            public string Class { get; set; }
            public string Income { get; set; }
            public string SubType2 { get; set; }
        }    
}
