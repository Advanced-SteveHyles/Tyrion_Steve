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
        private InvestmentMap _dummyInvestmentMap;
        private Account _dummyAccount;

        public FakeRepository()
        {
            _dummyAccount = new Account();
            _dummyInvestmentMap = new InvestmentMap();
        }

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
            return _dummyAccount;
        }
        
        public void IncreaseAccountBalance(int accountId, decimal amount)
        {
            _dummyAccount.Cash += amount;
        }

        public void DecreaseAccountBalance(int accountId, decimal amount)
        {
            _dummyAccount.Cash -= amount;
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
            return _dummyInvestmentMap;
        }

        public void Save(InvestmentMap investmentMap)
        {
            _dummyInvestmentMap = investmentMap;
        }
    }
}