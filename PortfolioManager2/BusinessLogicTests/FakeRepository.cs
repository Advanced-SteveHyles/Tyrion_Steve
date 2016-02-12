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
        const int arbitaryId = -1;

        private Account _dummyAccount;
        private FundTransaction _dummyFundTransaction;
        private CashTransaction _dummyCashTransaction;
        private AccountInvestmentMap _dummyAccountInvestment = new AccountInvestmentMap() {AccountInvestmentMapId = arbitaryId};

        private List<PriceHistory> _dummyPriceHistoryList;
        private Dictionary<int, List<AccountInvestmentMapDto>> _investmentMapsKeyedByInvestmentId;
        private int _nextId = 1;

        public FakeRepository()
        {
            _dummyAccount = new Account();
            _dummyFundTransaction = new FundTransaction();
            _dummyCashTransaction = new CashTransaction();
            _dummyPriceHistoryList = new List<PriceHistory>();
            _investmentMapsKeyedByInvestmentId = new Dictionary<int, List<AccountInvestmentMapDto>>();
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

        public void IncreaseValuation(int accountId, decimal mapValue)
        {
            _dummyAccount.Valuation += mapValue;
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
            if (investmentMap.AccountInvestmentMapId != arbitaryId)
            {
                var map = GetAccountInvestmentMap(investmentMap.AccountInvestmentMapId);
                map.Valuation = investmentMap.Valuation;

                
            }
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

        public CashTransaction GetCashTransaction(int arbitaryId)
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