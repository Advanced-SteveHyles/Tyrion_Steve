using Interfaces;

namespace Common.DTOs
{
 public   class PortfolioDTO : IPortfolioDTO
    {       
        public string PortfolioName { get; set; }
   
        public int PortfolioID         {            get;            set;        }
    }
}
