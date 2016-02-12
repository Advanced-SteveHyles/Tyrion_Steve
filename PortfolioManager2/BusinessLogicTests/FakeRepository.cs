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
        const int ArbitaryId = -1;
        
        private FundTransaction _dummyFundTransaction;
        private CashTransaction _dummyCashTransaction;
        private readonly AccountInvestmentMap _dummyAccountInvestment = new AccountInvestmentMap() {AccountInvestmentMapId = ArbitaryId};

        private readonly List<PriceHistory> _dummyPriceHistoryList;
        private Dictionary<int, List<AccountInvestmentMapDto>> _investmentMapsKeyedByInvestmentId;
        private int _nextId = 1;
        Dictionary<int, Account> _accountDictionary;

        public FakeRepository()
        {            
            _dummyFundTransaction = new FundTransaction();
            _dummyCashTransaction = new CashTransaction();
            _dummyPriceHistoryList = new List<PriceHistory>();
            _investmentMapsKeyedByInvestmentId = new Dictionary<int, List<AccountInvestmentMapDto>>();
            _accountDictionary = new Dictionary<int, Account>()
            {
                {0, new Account(){}},
                {1, new Account(){}},
                {2, new Account(){}},
                {3, new Account(){}}
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
            return _accountDictionary[id];
        }

        public void IncreaseAccountBalance(int accountId, decimal amount)
        {
            _accountDictionary[accountId].Cash += amount;
        }

        public void DecreaseAccountBalance(int accountId, decimal amount)
        {
            _accountDictionary[accountId].Cash -= amount;
        }

        public void IncreaseValuation(int accountId, decimal mapValue)
        {
            _accountDictionary[accountId].Valuation += mapValue;
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
            if (accountInvestmentMapId == -1)
            {
                return _dummyAccountInvestment;
            }
            else
            {
                var accountInvestmentMapDto = _investmentMapsKeyedByInvestmentId.Values
                    .Select(k => k.Where(i => i.AccountInvestmentMapId == accountInvestmentMapId))
                    .Select(r => r.FirstOrDefault()).FirstOrDefault(r1 => r1 != null);

                return new AccountInvestmentMap()
                {
                    AccountId = accountInvestmentMapDto.AccountId,
                    AccountInvestmentMapId = accountInvestmentMapDto.AccountInvestmentMapId,
                    InvestmentId = accountInvestmentMapDto.InvestmentId,
                    Quantity = accountInvestmentMapDto.Quantity,
                    Valuation = accountInvestmentMapDto.Valuation
                };
            }            
        }

        public void UpdateAccountInvestmentMap(AccountInvestmentMap investmentMap)
        {
            if (investmentMap.AccountInvestmentMapId == ArbitaryId) return;

            var map = GetAccountInvestmentMap(investmentMap.AccountInvestmentMapId);
            map.Valuation = investmentMap.Valuation;

            var matchingInvestments = _investmentMapsKeyedByInvestmentId[map.InvestmentId];
            matchingInvestments.RemoveAll(f => f.AccountInvestmentMapId == map.AccountInvestmentMapId);
            matchingInvestments.Add(map.MapToDto());
        }

        public RepositoryActionResult<AccountInvestmentMap> InsertAccountInvestmentMap(AccountInvestmentMap entityAccountInvestmentMap)
        {
            var map = new AccountInvestmentMap()
            {
                AccountInvestmentMapId = NewId(),
                AccountId = entityAccountInvestmentMap.AccountId,
                InvestmentId = entityAccountInvestmentMap.InvestmentId,
                Quantity = entityAccountInvestmentMap.Quantity,
                Valuation = entityAccountInvestmentMap.Valuation
            };

            if (!_investmentMapsKeyedByInvestmentId.ContainsKey(entityAccountInvestmentMap.InvestmentId))
            {
                _investmentMapsKeyedByInvestmentId.Add(entityAccountInvestmentMap.InvestmentId, new List<AccountInvestmentMapDto>());
            }

            _investmentMapsKeyedByInvestmentId[entityAccountInvestmentMap.InvestmentId].Add(map.MapToDto());

            return new RepositoryActionResult<AccountInvestmentMap>(map, RepositoryActionStatus.Created);
        }


        private int NewId()
        {
            return _nextId++;
        }

        public IQueryable<AccountInvestmentMapDto> GetAccountInvestmentMapsByInvestmentId(int investmentId)
        {
            return _investmentMapsKeyedByInvestmentId[investmentId].AsQueryable();
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

        public CashTransaction GetCashTransaction(int cashTransactionId)
        {
            return _dummyCashTransaction;
        }


        public IQueryable<PriceHistory> GetInvestmentSellPrices(int investmentId)
        {
            return _dummyPriceHistoryList.AsQueryable();
        }

        public IQueryable<PriceHistory> GetInvestmentBuyPrices(int investmentId)
        {
            return _dummyPriceHistoryList.AsQueryable();
        }

        public void InsertPriceHistory(int investmentId, DateTime valuationDate, decimal? buyPrice, decimal? sellPrice)
        {
            var priceHistory = new PriceHistory
            {
                InvestmentId = investmentId,
                ValuationDate = valuationDate,
                BuyPrice = buyPrice,
                SellPrice = sellPrice
            };

            _dummyPriceHistoryList.Add(priceHistory);
        }

    }
}