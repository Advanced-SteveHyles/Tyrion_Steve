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
        , ICashTransactionRepository
        , IAccountInvestmentMapRepository
        , IFundTransactionRepository
    {
        private AccountInvestmentMap _dummyAccountInvestmentMap;
        private Account _dummyAccount;
        private FundTransaction _dummyFundTransaction;
        private CashTransaction _dummyCashTransaction;

        public FakeRepository()
        {
            _dummyAccount = new Account();
            _dummyAccountInvestmentMap = new AccountInvestmentMap();
            _dummyFundTransaction = new FundTransaction();
            _dummyCashTransaction = new CashTransaction();
        }
        
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

        public IQueryable<CashTransaction> GetCashTransactionsForAccount(int accountId)
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

        public RepositoryActionResult<CashTransaction> InsertCashTransaction(CreateCashTransactionRequest request)
        {
            _dummyCashTransaction = new CashTransaction()
            {
                AccountId = request.AccountId,
                TransactionDate = request.TransactionDate,
                TransactionValue = request.TransactionValue,
                Source = request.Source,
                IsTaxRefund = request.IsTaxRefund,
                TransactionType = request.TransactionType,
            };
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

        public FundTransaction GetFundTransaction(int arbitaryId)
        {
            return _dummyFundTransaction;
        }

        public RepositoryActionResult<FundTransaction> InsertFundTransaction(CreateFundTransactionRequest request)
        {
            _dummyFundTransaction = new FundTransaction()
            {
                InvestmentMapId = request.InvestmentMapId,
                TransactionType = request.TransactionType,
                TransactionDate = request.TransactionDate,
                SettlementDate = request.SettlementDate,
                Source = request.Source,
                Quantity = request.Quantity,
                SellPrice = request.SellPrice,
                BuyPrice = request.BuyPrice,
                Charges = request.Charges,
                TransactionValue = request.TransactionValue
            };

            return new RepositoryActionResult<FundTransaction>(_dummyFundTransaction, RepositoryActionStatus.Ok);
        }

        public CashTransaction GetCashTransaction(int arbitaryId)
        {
            return _dummyCashTransaction;
        }
    }
}