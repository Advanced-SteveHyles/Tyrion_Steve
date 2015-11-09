using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
 public   class PortfolioDTO : IPortfolioDTO
    {       
        public string PortfolioName { get; set; }
   
        public int PortfolioID         {            get;            set;        }
    }
}
