using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Repository;
using PortfolioManager.DTO;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository
{
    public class PortfolioManagerEfRepository : IPortfolioManagerRepository
    {
        private PortfolioManagerContext _context;

        public PortfolioManagerEfRepository(PortfolioManagerContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
        }
        
        //public IQueryable<Portfolio> GetPortfolios(int expenseGroupId)
        //{
        //    return _context.Portfolio;
        //}

        public IQueryable<Portfolio> GetPortfolios()
        {
            return _context.Portfolios;
        }

        public IQueryable<Portfolio> GetPortfolio(int id)
        {
            return _context.Portfolios.Where(p => p.Id == id);
        }

        public IQueryable<Portfolio> GetPortfolioWithAccounts(int id)
        {
            return _context.Portfolios.Where(p => p.Id == id);
        }

        public RepositoryActionResult<Portfolio> InsertPortfolio(Portfolio entityPortfolio)
        {
            try
            {
                _context.Portfolios.Add(entityPortfolio);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Portfolio>(entityPortfolio, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Portfolio>(entityPortfolio, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Portfolio>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }
}
