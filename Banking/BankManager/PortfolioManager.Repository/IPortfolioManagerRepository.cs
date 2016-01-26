using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Repository
{
    public interface IPortfolioManagerRepository
    {
        
        System.Linq.IQueryable<Entities.Portfolio> GetPortfolios();
    }
}
