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

        public Portfolio GetPortfolio(int id)
        {
            var portfolio    = _context.Portfolios.SingleOrDefault(p => p.Id == id);
            return portfolio;
        }

        public Portfolio GetPortfolioWithAccounts(int id)
        {
            var portfolio = _context.Portfolios.Include("Accounts").SingleOrDefault(p => p.Id == id);
            
            return portfolio ;
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

        public IQueryable<Investment> GetInvestments()
        {
            var investment = _context.Investments;
            return investment;
        }

        public RepositoryActionResult<Account> InsertAccount(Account entityAccount)
        {
            try
            {
                _context.Accounts.Add(entityAccount);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Account>(entityAccount, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Account>(entityAccount, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Account>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public Account GetAccountWithInvestments(int id)
        {
            var account= _context.Accounts.Include("Investments").SingleOrDefault(p => p.Id == id);

            return account;
        }

        public Account GetAccount(int id)
        {
            var account = _context.Accounts.SingleOrDefault(p => p.Id == id);
            return account;
        }
    }
}
