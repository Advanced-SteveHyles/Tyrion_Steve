﻿using System;
using BusinessLogic;
using BusinessLogic.Transactions;
using Interfaces;
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
        private FakeRepository _fakeRepository;
        private CreateFundBuyTransaction _buyTransaction;
        private IAccountHandler _accountHandler;
        private int _accountId;
        private ITransactionHandler _cashTransactionHandler;
        private IAccountInvestmentMapHandler _accountInvestmentMapHandler;
        private FundTransactionHandler _fundTransactionHandler;
        private const int ArbitaryId = 1;

        private void Setup()
        {

            _numberOfShares = 10;
            _priceOfOneShare = 1;
            _commission = 2;
            _valueOfTransaction = (_numberOfShares * _priceOfOneShare) + _commission;
            _transactionDate = DateTime.Now;
            _accountId = 10;
            
            var request = new InvestmentBuyRequest
            {
                InvestmentMapId = 1,
                Quantity = _numberOfShares,
                Price = _priceOfOneShare,
                PurchaseDate = _transactionDate,
                UpdatePriceHistory = false,
                Value = _valueOfTransaction
            };

            _fakeRepository = new FakeRepository();
            _accountHandler = new AccountHandler(_fakeRepository);
            _cashTransactionHandler = new CashTransactionHandler(_fakeRepository);
            _accountInvestmentMapHandler = new AccountInvestmentMapHandler(_fakeRepository);
            _fundTransactionHandler = new FundTransactionHandler(_fakeRepository);

            _buyTransaction = new CreateFundBuyTransaction(
                        _accountId, request, _accountHandler,
                        _cashTransactionHandler, _accountInvestmentMapHandler,
                        _fundTransactionHandler);

        }

        [Fact]
        public void WhenIBuyTransactionIsValid()
        {
            Setup();
            Assert.True(_buyTransaction.CommandValid);
        }

        [Fact]
        public void WhenIBuyThenTheAccountValueIsReduced()
        {
            Setup();
            _buyTransaction.Execute();
            var account = _fakeRepository.GetAccount(ArbitaryId);
            Assert.Equal(-_valueOfTransaction, account.Cash);
        }

        [Fact]
        public void WhenIBuyThenTheAccountHasARecordOfTheWithdrawal()
        {
            Setup();
            _buyTransaction.Execute();
            Assert.True(_fakeRepository.ApplyCashTransactionWasCalled);
        }

        [Fact]
        public void WhenIBuyThenTheShareCountIsIncreased()
        {
            Setup();
            _buyTransaction.Execute();

            var accountFundMap = _fakeRepository.GetAccountInvestmentMap(1);
            Assert.Equal(_numberOfShares, accountFundMap.Quantity);
        }

        [Fact]
        public void WhenIBuyThenTheFundTransactionIsCorrect()
        {
            Setup();
            _buyTransaction.Execute();

            var fundTransaction = _fakeRepository.GetFundTransaction(ArbitaryId);
            Assert.Equal(_priceOfOneShare, fundTransaction.BuyPrice);
            Assert.Equal("BUY", fundTransaction.TransactionType);
            Assert.Equal(ArbitaryId, fundTransaction.AccountId);
            Assert.Equal(_transactionDate, fundTransaction.TransactionDate);
            Assert.Equal(string.Empty, fundTransaction.Source);
            Assert.Equal(_numberOfShares, fundTransaction.Quantity);
            Assert.Equal(null, fundTransaction.SellPrice);
            Assert.Equal(_priceOfOneShare, fundTransaction.BuyPrice);
            Assert.Equal(_commission, fundTransaction.Charges);

            var transactionValue = (_numberOfShares*_priceOfOneShare) + _commission;
            Assert.Equal(transactionValue, fundTransaction.TransactionValue);
        }

        [Fact]
        public void WhenIBuyThenTheFundTransactionAndTheCashTransactionValueAreIdenticalButOpposite()
        {
            Setup();
            _buyTransaction.Execute();

            var fundTransaction = _fakeRepository.GetFundTransaction(ArbitaryId);
            var cashTransaction = _fakeRepository.GetCashTransaction(ArbitaryId);
            
            Assert.Equal(fundTransaction.TransactionValue, cashTransaction.TransactionValue);
        }

        //WhereIBuyTheCashWithdrawnIsEqualToTheTransactionCost



        //[Fact]
        //public void WhenIBuyThenTheValuationIsCorrect()
        //{
        //    Setup();
        //    _buyTransaction.Execute();

        //    var accountFundMap = _fakeRepository.GetInvestmentMap(1);
        //    Assert.Equal(_numberOfShares, accountFundMap.Quantity);
        //}
    }
}
