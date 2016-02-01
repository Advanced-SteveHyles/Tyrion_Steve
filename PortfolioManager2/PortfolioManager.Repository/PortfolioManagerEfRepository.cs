﻿using System;
using System.Linq;
using ExpenseTracker.Repository;
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
            var portfolio    = _context.Portfolios.SingleOrDefault(p => p.PortfolioId == id);
            return portfolio;
        }

        public Portfolio GetPortfolioWithAccounts(int id)
        {
            var portfolio = _context.Portfolios.Include("Accounts").SingleOrDefault(p => p.PortfolioId == id);
            
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
            var account= _context.Accounts.Include("Investments").SingleOrDefault(p => p.AccountId == id);

            return account;
        }

        public Account GetAccount(int id)
        {
            var account = _context.Accounts.SingleOrDefault(p => p.AccountId == id);
            return account;
        }

        public RepositoryActionResult<Transaction> AddCashTransaction(int accountId, DateTime transactionDate, string source, decimal value, bool isTaxRefund)
        {
            var entityTransaction = new Transaction()
            {
                    AccountId = accountId,
                TransactionDate = transactionDate,
                Source = source,
                Value = value,
                IsTaxRefund = isTaxRefund
            };

            _context.Transactions.Add(entityTransaction);

            var result = _context.SaveChanges();
            if (result > 0)
            {
                return new RepositoryActionResult<Transaction>(entityTransaction, RepositoryActionStatus.Created);
            }
            else
            {
                return new RepositoryActionResult<Transaction>(entityTransaction, RepositoryActionStatus.NothingModified, null);
            }
        }

        public void IncreaseAccountBalance(int accountId, decimal amount)
        {
            var account = _context.Accounts.Single(a => a.AccountId == accountId);
            account.Cash += amount;
            _context.SaveChanges();

        }

    }
}
