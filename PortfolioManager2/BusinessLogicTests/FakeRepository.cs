using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PortfolioManager.DTO.DTOs;
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
        , IPriceHistoryRepository
    {
        private readonly Investment _investment = new Investment();
        private FundTransaction _dummyFundTransaction;
        private List<CashTransaction> _dummyCashTransactions;

        private readonly List<PriceHistory> _dummyPriceHistoryList;
        private readonly List<AccountInvestmentMap> _investmentMaps;

        readonly List<Account> _accounts;

        public FakeRepository()
        {
            _dummyFundTransaction = new FundTransaction();
            _dummyCashTransactions = new List<CashTransaction>();
            _dummyPriceHistoryList = new List<PriceHistory>();
            _investmentMaps = FakePopulatedInvestmentMap();

            _accounts = new List<Account>()
            {
                new Account(){AccountId = 1},
                new Account(){AccountId = 2},
                new Account(){AccountId = 3},
                new Account(){AccountId = 4},
                new Account(){AccountId = 5},
                new Account(){AccountId = 6}
            };
        }

        private static List<AccountInvestmentMap> FakePopulatedInvestmentMap()
        {
            return new List<AccountInvestmentMap>
            {
                new AccountInvestmentMap()
                {
                    AccountInvestmentMapId = 1,
                    InvestmentId = 1,
                    AccountId = 1,
                    Quantity = 10,
                },
                new AccountInvestmentMap()
                {
                    AccountInvestmentMapId = 2,
                    InvestmentId = 1,
                    AccountId = 2,
                    Quantity = 5,
                },
                new AccountInvestmentMap()
                {
                    AccountInvestmentMapId = 3,
                    InvestmentId = 2,
                    AccountId = 1,
                    Quantity = 10,
                },
                new AccountInvestmentMap()
                {
                    AccountInvestmentMapId = 4,
                    InvestmentId = 1,
                    AccountId = 3,
                    Quantity = (decimal)25.4,
                },
                new AccountInvestmentMap()
                {
                    AccountInvestmentMapId = 88,
                    InvestmentId = 1,
                    AccountId = 4,
                    Quantity = (decimal)1.78923,
                },
                new AccountInvestmentMap()
                {
                    AccountInvestmentMapId = 89,
                    InvestmentId = 3,
                    AccountId = 6,
                    Quantity = (decimal)21,
                },
            };
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
            return _accounts.Single(a => a.AccountId == id);
        }

        public void IncreaseAccountBalance(int accountId, decimal amount)
        {
            GetAccount(accountId).Cash += amount;
        }

        public void DecreaseAccountBalance(int accountId, decimal amount)
        {
            GetAccount(accountId).Cash -= amount;
        }

        public void IncreaseValuation(int accountId, decimal valuation)
        {
            var account = GetAccount(accountId);
            account.Valuation += valuation;
            _accounts.RemoveAll(acc => acc.AccountId == accountId);
            _accounts.Add(account);
        }

        public void DecreaseValuation(int accountId, decimal valuation)
        {
            var account = GetAccount(accountId);
            account.Valuation -= valuation;
            _accounts.RemoveAll(acc => acc.AccountId == accountId);
            _accounts.Add(account);
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accounts;
        }

        public void SetValuation(int accountId, decimal valuation)
        {
            var account = GetAccount(accountId);
            account.Valuation = valuation;
            _accounts.RemoveAll(acc => acc.AccountId == accountId);
            _accounts.Add(account);
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
            return _investmentMaps.Select(inv => new Investment()
            {
                InvestmentId = inv.InvestmentId,
            }).AsQueryable();
        }

        public Investment GetInvestment(int investmentId)
        {
            return _investment;
        }

        public RepositoryActionResult<CashTransaction> InsertCashTransaction(CreateCashTransactionRequest request)
        {
            _dummyCashTransactions.Add(
                new CashTransaction()
                {
                    AccountId = request.AccountId,
                    TransactionDate = request.TransactionDate,
                    TransactionValue = request.TransactionValue,
                    Source = request.Source,
                    IsTaxRefund = request.IsTaxRefund,
                    TransactionType = request.TransactionType
                }
                );
            return null;
        }

        public AccountInvestmentMap GetAccountInvestmentMap(int accountInvestmentMapId)
        {
            var accountInvestmentMapDto =
                _investmentMaps.SingleOrDefault(i => i.AccountInvestmentMapId == accountInvestmentMapId);

            return new AccountInvestmentMap()
            {
                AccountId = accountInvestmentMapDto.AccountId,
                AccountInvestmentMapId = accountInvestmentMapDto.AccountInvestmentMapId,
                InvestmentId = accountInvestmentMapDto.InvestmentId,
                Quantity = accountInvestmentMapDto.Quantity,
                Valuation = accountInvestmentMapDto.Valuation
            };
        }

        public void UpdateAccountInvestmentMap(AccountInvestmentMap investmentMap)
        {
            var map = GetAccountInvestmentMap(investmentMap.AccountInvestmentMapId);
            map.Valuation = investmentMap.Valuation;
            map.Quantity = investmentMap.Quantity;

            _investmentMaps.RemoveAll(f => f.AccountInvestmentMapId == map.AccountInvestmentMapId);
            _investmentMaps.Add(map);
        }

        public RepositoryActionResult<AccountInvestmentMap> InsertAccountInvestmentMap(AccountInvestmentMap entityAccountInvestmentMap)
        {
            var map = new AccountInvestmentMap()
            {
                AccountInvestmentMapId = entityAccountInvestmentMap.AccountInvestmentMapId,
                AccountId = entityAccountInvestmentMap.AccountId,
                InvestmentId = entityAccountInvestmentMap.InvestmentId,
                Quantity = entityAccountInvestmentMap.Quantity,
                Valuation = entityAccountInvestmentMap.Valuation
            };

            _investmentMaps.Add(map);

            return new RepositoryActionResult<AccountInvestmentMap>(map, RepositoryActionStatus.Created);
        }

        public IQueryable<AccountInvestmentMap> GetAccountInvestmentMapsByInvestmentId(int investmentId)
        {
            return _investmentMaps.Where(inv => inv.InvestmentId == investmentId).AsQueryable();
        }

        public IQueryable<AccountInvestmentMap> GetAccountInvestmentMaps()
        {
            return _investmentMaps.Select(map => new AccountInvestmentMap()
            {
                AccountId = map.AccountId,
                Valuation = map.Valuation
            }).AsQueryable();
        }

        public FundTransaction GetFundTransaction(int fundTransactionId)
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

        public CashTransaction GetCashTransaction(int cashTransactionId)
        {
            return _dummyCashTransactions[0];
        }

        public IQueryable<PriceHistory> GetInvestmentSellPrices(int investmentId)
        {
            return _dummyPriceHistoryList.Where(ph => ph.InvestmentId == investmentId).AsQueryable();
        }

        public IQueryable<PriceHistory> GetInvestmentBuyPrices(int investmentId)
        {
            return _dummyPriceHistoryList.Where(ph => ph.InvestmentId == investmentId).AsQueryable();
        }

        public RepositoryActionResult<PriceHistory> InsertPriceHistory(int investmentId, DateTime valuationDate, decimal? buyPrice, decimal? sellPrice)
        {
            var priceHistory = new PriceHistory
            {
                InvestmentId = investmentId,
                ValuationDate = valuationDate,
                BuyPrice = buyPrice,
                SellPrice = sellPrice
            };

            _dummyPriceHistoryList.Add(priceHistory);

            return null;
        }

        public void SetInvestmentType(int fakeInvestmentId, string investmentClass)
        {
            _investment.Class = investmentClass;
        }

        public List<AccountInvestmentMap> GetAllAccountInvestmentMaps()
        {
            return _investmentMaps;
        }
    }
}