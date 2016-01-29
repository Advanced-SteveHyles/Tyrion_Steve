using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.DTO;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository
{
    public interface IPortfolioManagerRepository
    {        
        System.Linq.IQueryable<Entities.Portfolio> GetPortfolios();

        Portfolio GetPortfolio(int id);
        Portfolio GetPortfolioWithAccounts(int id);
        RepositoryActionResult<Portfolio> InsertPortfolio(Portfolio entityPortfolio);
        System.Linq.IQueryable<Entities.Investment> GetInvestments();
        RepositoryActionResult<Account> InsertAccount(Account entityAccount);
    }
}
