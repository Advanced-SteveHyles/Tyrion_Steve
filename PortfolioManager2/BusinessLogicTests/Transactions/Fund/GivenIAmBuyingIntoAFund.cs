﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;
using BusinessLogic;
using BusinessLogic.Handlers;
using BusinessLogic.Transactions;
using Interfaces;
using PortfolioManager.Constants.TransactionTypes;
using PortfolioManager.DTO.Transactions;
using Xunit;

namespace BusinessLogicTests.Transactions.Fund
{
    public class GivenIAmBuyingIntoAFund
    {
        private decimal _numberOfShares;
        private decimal _priceOfOneShare;
        private decimal _commission;
        private decimal _valueOfTransaction;
        private DateTime _transactionDate;
        private readonly FakeRepository _fakeRepository = new FakeRepository();
        private CreateFundBuyTransaction _buyTransaction;
        private int _accountId;

        private IAccountHandler _accountHandler;        
        private ITransactionHandler _cashTransactionHandler;
        private IAccountInvestmentMapHandler _accountInvestmentMapHandler;
        private IFundTransactionHandler _fundTransactionHandler;
        private IInvestmentHandler _investmentHandler;

        private DateTime _settlementDate;
        private decimal _valuation;
        private IPriceHistoryHandler _priceHistoryHandler;
        private int _existingInvestmentMapId = 1;

        private void SetupAndOrExecute(bool execute)
        {

            _numberOfShares = 10;
            _priceOfOneShare = 1;
            _commission = 2;
            _valueOfTransaction = (_numberOfShares * _priceOfOneShare) + _commission;
            _transactionDate = DateTime.Now;
            _settlementDate = DateTime.Today.AddDays(14);
            _accountId = 3;
            _valuation = (_numberOfShares*_priceOfOneShare);

            var request = new InvestmentBuyRequest
            {
                InvestmentMapId = _existingInvestmentMapId,
                Quantity = _numberOfShares,
                Price = _priceOfOneShare,
                PurchaseDate = _transactionDate,
                SettlementDate = _settlementDate,
                UpdatePriceHistory = false,
                Value = _valueOfTransaction,
                Charges = _commission
            };
            
            _accountHandler = new AccountHandler(_fakeRepository);
            _cashTransactionHandler = new CashTransactionHandler(_fakeRepository);
            _accountInvestmentMapHandler = new AccountInvestmentMapHandler(_fakeRepository, _fakeRepository);
            _fundTransactionHandler = new FundTransactionHandler(_fakeRepository);
            _priceHistoryHandler = new  PriceHistoryHandler(_fakeRepository);
            _investmentHandler = new InvestmentHandler(_fakeRepository);

            _buyTransaction = new CreateFundBuyTransaction(
                        _accountId, request, _accountHandler,
                        _cashTransactionHandler, _accountInvestmentMapHandler,
                        _fundTransactionHandler, _priceHistoryHandler,
                        _investmentHandler);

            if (execute) _buyTransaction.Execute();
        }

        [Fact]
        public void WhenIBuyTransactionIsValid()
        {
            SetupAndOrExecute(false);
            Assert.True(_buyTransaction.CommandValid);
        }

        [Fact]
        public void WhenIBuyThenTheAccountValueIsReduced()
        {
            SetupAndOrExecute(true);

            var account = _fakeRepository.GetAccount(_accountId);
            Assert.Equal(-_valueOfTransaction, account.Cash);
        }

        [Fact]
        public void WhenIBuyThenTheAccountHasARecordOfTheWithdrawal()
        {
            SetupAndOrExecute(true);

            var cashTransactionId = -1;
            var transaction = _fakeRepository.GetCashTransaction(cashTransactionId);
            Assert.Equal(_accountId, transaction.AccountId);
            Assert.Equal(_transactionDate, transaction.TransactionDate);
            Assert.Equal(_valueOfTransaction, transaction.TransactionValue);
            Assert.Equal(string.Empty, transaction.Source);
            Assert.Equal(false, transaction.IsTaxRefund);
            Assert.Equal(CashTransactionTypes.FundPurchase, transaction.TransactionType);
        }

        [Fact]
        public void WhenIBuyThenTheShareCountIsIncreased()
        {
            SetupAndOrExecute(true);

            var accountFundMap = _fakeRepository.GetAccountInvestmentMap(_existingInvestmentMapId);
            var startingNumberOfShares = 10;
            Assert.Equal(_numberOfShares +startingNumberOfShares, accountFundMap.Quantity);
        }

        [Fact]
        public void WhenIBuyThenTheFundTransactionIsCorrect()
        {
            SetupAndOrExecute(true);

            var arbitaryId = 1;
            var fundTransaction = _fakeRepository.GetFundTransaction(arbitaryId);
            Assert.Equal(_priceOfOneShare, fundTransaction.BuyPrice);            
            Assert.Equal(FundTransactionTypes.Buy, fundTransaction.TransactionType);
            Assert.Equal(_transactionDate, fundTransaction.TransactionDate);
            Assert.Equal(_settlementDate, fundTransaction.SettlementDate);
            Assert.Equal(string.Empty, fundTransaction.Source);
            Assert.Equal(_numberOfShares, fundTransaction.Quantity);
            Assert.Equal(null, fundTransaction.SellPrice);
            Assert.Equal(_priceOfOneShare, fundTransaction.BuyPrice);
            Assert.Equal(_commission, fundTransaction.Charges);

            var transactionValue = (_numberOfShares * _priceOfOneShare) + _commission;
            Assert.Equal(transactionValue, fundTransaction.TransactionValue);
        }

        [Fact]
        public void WhenIBuyThenTheFundTransactionAndTheCashTransactionValueAreIdenticalButOpposite()
        {
            SetupAndOrExecute(true);
            _buyTransaction.Execute();

            var arbitaryId= 1;
            var fundTransaction = _fakeRepository.GetFundTransaction(arbitaryId);
            var cashTransaction = _fakeRepository.GetCashTransaction(arbitaryId);

            Assert.Equal(fundTransaction.TransactionValue, cashTransaction.TransactionValue);
        }

        [Fact]
        public void WhenIBuyThenTheValuationIsCorrect()
        {
            SetupAndOrExecute(true);
            var startingNumberOfShares = 10;
            var accountFundMap = _fakeRepository.GetAccountInvestmentMap(_existingInvestmentMapId);
            Assert.Equal(_numberOfShares+ startingNumberOfShares, accountFundMap.Quantity);
            Assert.Equal(0, accountFundMap.Valuation);
        }

        [Fact]
        public void WhenIBuyAndTheAccountIsAnOEICBothTheSellingAndBuyPriceAreRecorded()
        {
            var fakeInvestmentId = 1;
            _fakeRepository.SetInvestmentType(fakeInvestmentId, "OEIC");
            SetupAndOrExecute(true);

            var investmentId = 1;
            var prices = _fakeRepository.GetInvestmentBuyPrices(investmentId);

            Assert.Equal(_priceOfOneShare, prices.First().BuyPrice);
            Assert.Equal(_priceOfOneShare, prices.First().SellPrice);
        }

        [Fact]
        public void WhenIBuyAndTheAccountIsAOEICBothThenTheAccountIsValuedCorrect()
        {
            var fakeInvestmentId = 1;
            _fakeRepository.SetInvestmentType(fakeInvestmentId, "OEIC");
            SetupAndOrExecute(true);

            var account = _fakeRepository.GetAccount(_accountId);
            Assert.Equal(_priceOfOneShare, account.Valuation);            
        }

        [Fact]
        public void WhenIBuyAndTheAccountIsUnitTrustBothThenTheAccountIsValuedCorrect()
        {
            var fakeInvestmentId = 1;
            _fakeRepository.SetInvestmentType(fakeInvestmentId, "UnitTrust");
            SetupAndOrExecute(true);

            var account = _fakeRepository.GetAccount(_accountId);
            Assert.Equal(new decimal?(), account.Valuation);
        }
        
        [Fact]
        public void WhenIBuyAndTheAccountIsAUnitTrustFundOnlyTheBuyIsRecorded()
        {
            var fakeInvestmentId = 1;
            _fakeRepository.SetInvestmentType(fakeInvestmentId, "UnitTrust");
            SetupAndOrExecute(true);

            var investmentId = 1;
            var prices = _fakeRepository.GetInvestmentBuyPrices(investmentId);

            Assert.Equal(_priceOfOneShare, prices.First().BuyPrice);
            Assert.Equal(null, prices.First().SellPrice);
        }


    }
}
