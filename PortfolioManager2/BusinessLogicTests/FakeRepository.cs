using System;
using System.Linq;
using PortfolioManager.DTO.Requests;
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
        , IInvestmentMapRepository
    {
        public decimal AccountBalance { get; private set; }
        public bool ApplyCashTransactionWasCalled { get; private set; }

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

        public RepositoryActionResult<CashTransaction> ApplyCashTransaction(CreateCashTransactionRequest request)
        {
            ApplyCashTransactionWasCalled = true;

            return null;
        }

        

        public InvestmentMap GetInvestmentMap(int investmentMapId)
        {
            throw new NotImplementedException();
        }

        public void Save(InvestmentMap investmentMap)
        {
            throw new NotImplementedException();
        }
    }
}