using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
