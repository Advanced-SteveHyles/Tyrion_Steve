using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
 public   interface IPortfolioRepository
    {
        IQueryable<IPortfolioDTO> GetAllPortfolios();

        void Save(int portfolioId, string portfolioName);
        void Save(string portfolioName);

     //   PortfolioDTO Find(int portfolioId);
    }
}
