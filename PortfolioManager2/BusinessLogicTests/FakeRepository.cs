using System;
using System.Linq;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Entities;
using Xunit.Sdk;

namespace BusinessLogicTests
{
    public class FakeRepository
        : IPortfolioRepository
        , IInvestmentRepository
        , IAccountRepository
        , ITransactionRepository
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

        public RepositoryActionResult<CashTransaction> AddCashTransaction(int accountId, DateTime transactionDate, string source, decimal value,
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
            AccountBalance -= amount;
        }

        public IQueryable<CashTransaction> GetAccountTransactions(int accountId)
        {
            throw new NotImplementedException();
        }

        public RepositoryActionResult<Investment> InsertInvestment(Investment entityInvestment)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Investment> GetInvestments()
        {
            throw new NotImplementedException();
        }
    }
}