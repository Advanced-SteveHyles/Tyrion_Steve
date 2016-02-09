using System;
using System.Linq;
using PortfolioManager.DTO.Requests;
using PortfolioManager.Repository;
using PortfolioManager.Repository.Entities;
using PortfolioManager.Repository.Interfaces;
using Xunit.Sdk;

namespace BusinessLogicTests
{
    public class FakeRepository
        : IPortfolioRepository
        , IInvestmentRepository
        , IAccountRepository
        , ITransactionRepository
        , IAccountInvestmentMapRepository
    {
        private AccountInvestmentMap _dummyAccountInvestmentMap;
        private Account _dummyAccount;

        public FakeRepository()
        {
            _dummyAccount = new Account();
            _dummyAccountInvestmentMap = new AccountInvestmentMap();
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
      
        public AccountInvestmentMap GetAccountInvestmentMap(int accountInvestmentMapId)
        {
            return _dummyAccountInvestmentMap;
        }

        public void UpdateAccountInvestmentMap(AccountInvestmentMap investmentMap)
        {
            _dummyAccountInvestmentMap = investmentMap;
        }

        public RepositoryActionResult<AccountInvestmentMap> InsertAccountInvestmentMap(AccountInvestmentMap entityAccountInvestmentMap)
        {
            throw new NotImplementedException();
        }
    }
}