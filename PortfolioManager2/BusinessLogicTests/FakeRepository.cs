using System;
using System.Linq;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Entities;
using Xunit.Sdk;

namespace BusinessLogicTests
{
    public class FakeRepository : IPortfolioManagerRepository
    {
        public decimal AccountBalance { get; private set; }
        public bool AddCashTransactionWasCalled { get; private set; }

        public IQueryable<Portfolio> GetPortfolios()
        {
            throw new NotImplementedException();
        }

        public Portfolio GetPortfolio(int id)
        {
            throw new NotImplementedException();
        }

        public Portfolio GetPortfolioWithAccounts(int id)
        {
            throw new NotImplementedException();
        }

        public RepositoryActionResult<Portfolio> InsertPortfolio(Portfolio entityPortfolio)
        {
            throw new NotImplementedException();
        }

        IQueryable<Investment> IPortfolioManagerRepository.GetInvestments()
        {
            throw new NotImplementedException();
        }

        public RepositoryActionResult<Account> InsertAccount(Account entityAccount)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountWithInvestments(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(int id)
        {
            throw new NotImplementedException();
        }

        public RepositoryActionResult<Transaction> AddCashTransaction(int accountId, DateTime transactionDate, string source, decimal value,
            bool isTaxRefund, string transactionType)
        {
            AddCashTransactionWasCalled = true;

            return null;
        }
        
        public void IncreaseAccountBalance(int accountId, decimal amount)
        {
            AccountBalance += amount;
        }

        public void DecreaseAccountBalance(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}