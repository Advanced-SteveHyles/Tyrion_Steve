using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository
{
    public interface IPortfolioManagerRepository
    {
        
        System.Linq.IQueryable<Entities.Portfolio> GetPortfolios();

        IQueryable<Portfolio> GetPortfolio(int id);
        IQueryable<Portfolio> GetPortfolioWithAccounts(int id);
    }
}
