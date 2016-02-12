﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Handlers;
using BusinessLogic.Transactions;
using PortfolioManager.DTO.Requests;
using PortfolioManager.DTO.Requests.Transactions;
using PortfolioManager.Repository.Entities;
using Xunit;

namespace BusinessLogicTests.Transactions.Fund
{
    public class PriceHistoryTests
    {
        private readonly FakeRepository _repository;
        private readonly PriceHistoryHandler _priceHistoryHandler;
        private CreatePriceHistoryTransaction _priceHistoryTransaction;

        private int investmentId = 629;

        private DateTime todaysValuationDate = DateTime.Today;
        decimal? todaysBuyPrice = (decimal)1.25;
        decimal? todaysSellPrice = (decimal)1.25;
        private RevaluePriceTransaction _revaluePriceTransaction;

        
        public PriceHistoryTests()
        {
            _repository = new FakeRepository();
            _priceHistoryHandler = new PriceHistoryHandler(_repository);

            var accountMapHandler = new AccountHandler(_repository);
            var accountInvestmentMapHandler = new AccountInvestmentMapHandler(_repository,_repository);
            _revaluePriceTransaction = new RevaluePriceTransaction(investmentId, todaysValuationDate, _priceHistoryHandler, accountInvestmentMapHandler, accountMapHandler);
        }

        private void SetupPriceHistory(DateTime valuationDate, decimal? buyAt, decimal? sellAt)
        {
            var priceHistoryRequest = new PriceHistoryRequest()
            {
                InvestmentId = investmentId,
                ValuationDate = valuationDate,
                SellPrice = sellAt,
                BuyPrice = buyAt
            };

            _priceHistoryTransaction = new CreatePriceHistoryTransaction(
                priceHistoryRequest, _priceHistoryHandler);
        }

        [Fact]
        public void CanSaveAPriceHistory()
        {
            SetupPriceHistory(todaysValuationDate, todaysBuyPrice, todaysSellPrice);

            Assert.True(_priceHistoryTransaction.CommandValid);
            _priceHistoryTransaction.Execute();
            Assert.True(_priceHistoryTransaction.ExecuteResult);

            var priceHistory = _repository.GetInvestmentSellPrices(investmentId);
            Assert.Equal(investmentId, priceHistory.FirstOrDefault()?.InvestmentId);
            Assert.Equal(todaysValuationDate, priceHistory.FirstOrDefault()?.ValuationDate);
            Assert.Equal(todaysSellPrice, priceHistory.FirstOrDefault()?.SellPrice);
            Assert.Equal(todaysBuyPrice, priceHistory.FirstOrDefault()?.BuyPrice);
        }

        [Fact]
        public void WhenNoHistoricalPriceExistsTheCurrentPriceIsNull()
        {
            var currentSellPrice = _priceHistoryHandler.GetInvestmentSellPrice(investmentId, todaysValuationDate);
            var currentBuyPrice = _priceHistoryHandler.GetInvestmentBuyPrice(investmentId, todaysValuationDate);

            decimal? notDefinedSellPrice = null;
            decimal? notDefinedBuyPrice = null;

            Assert.Equal(notDefinedSellPrice, currentSellPrice);
            Assert.Equal(notDefinedBuyPrice, currentBuyPrice);
        }


        [Fact]
        public void WhenAHistoricalPriceExistsTheCurrentPriceIsTheClosestBeforeTheCurrentDate()
        {
            SetupPriceHistory(todaysValuationDate, todaysBuyPrice, todaysSellPrice);
            _priceHistoryTransaction.Execute();

            var currentSellPrice = _priceHistoryHandler.GetInvestmentSellPrice(investmentId, todaysValuationDate);
            var currentBuyPrice = _priceHistoryHandler.GetInvestmentBuyPrice(investmentId, todaysValuationDate);

            Assert.Equal(todaysSellPrice, currentSellPrice);
            Assert.Equal(todaysBuyPrice, currentBuyPrice);
        }

        [Fact]
        public void WhenAFutureDatePriceExistsTheCurrentPriceIsTheClosestBeforeTheCurrentDate()
        {
            SetupPriceHistory(todaysValuationDate, todaysBuyPrice, todaysSellPrice);
            _priceHistoryTransaction.Execute();

            var tomorrowsDate = DateTime.Today.AddDays(1);
            decimal? tomorrowsBuyPrice = (decimal)2.25;
            decimal? tomorrowsSellPrice = (decimal)2.25;
            SetupPriceHistory(tomorrowsDate, tomorrowsBuyPrice, tomorrowsSellPrice);
            _priceHistoryTransaction.Execute();


            var currentSellPrice = _priceHistoryHandler.GetInvestmentSellPrice(investmentId, todaysValuationDate);
            var currentBuyPrice = _priceHistoryHandler.GetInvestmentBuyPrice(investmentId, todaysValuationDate);

            Assert.Equal(todaysSellPrice, currentSellPrice);
            Assert.Equal(todaysBuyPrice, currentBuyPrice);
        }

        [Fact]
        public void WhenIHaveTwoInvestmentMapsForTheSameInvestmentAndIUpdateThePriceBothInvestmentsUpdate()
        {
            var request1 = CreateDummyInvestmentMap(1, investmentId, 1);
            _repository.InsertAccountInvestmentMap(request1);

            var request2 = CreateDummyInvestmentMap(2, investmentId, 100);
            _repository.InsertAccountInvestmentMap(request2);

            SetupPriceHistory(todaysValuationDate, todaysBuyPrice, todaysSellPrice);
            _priceHistoryTransaction.Execute();
            _revaluePriceTransaction.Execute();

            var valuation1 = todaysBuyPrice * request1.Quantity;
            var valuation2 = todaysBuyPrice * request2.Quantity;

            var investmentMap1 = _repository.GetAccountInvestmentMap(1);
            var investmentMap2 = _repository.GetAccountInvestmentMap(2);

            Assert.Equal(valuation1, investmentMap1.Valuation);
            Assert.Equal(valuation2, investmentMap2.Valuation);
        }

        //[Fact]
        //public void WhenIHaveTwoInvestmentMapsForTheSameInvestmentAndIUpdateTheAccountValuationUpdate()
        //{
        //    var request1 = CreateDummyInvestmentMap(1, investmentId, 1);
        //    _repository.InsertAccountInvestmentMap(request1);

        //    var request2 = CreateDummyInvestmentMap(2, investmentId, 100);
        //    _repository.InsertAccountInvestmentMap(request2);

        //    SetupPriceHistory(todaysValuationDate, todaysBuyPrice, todaysSellPrice);
        //    _priceHistoryTransaction.Execute();

        //    var valuation1 = todaysBuyPrice * request1.Quantity;
        //    var valuation2 = todaysBuyPrice * request2.Quantity;

        //    var investmentMap1 = _repository.GetAccountInvestmentMap(1);
        //    var investmentMap2 = _repository.GetAccountInvestmentMap(2);

        //    Assert.Equal(valuation1, investmentMap1.Valuation);
        //    Assert.Equal(valuation2, investmentMap2.Valuation);
        //}

        //[Fact]
        //public void WhenTwoPriceUpdatesOccurAndIHaveTwoInvestmentMapsForTheSameInvestmentAndIUpdateTheAccountValuationUpdatesCorrectly()
        //{
        //    var request1 = CreateDummyInvestmentMap(1, investmentId, 1);
        //    _repository.InsertAccountInvestmentMap(request1);

        //    var request2 = CreateDummyInvestmentMap(2, investmentId, 100);
        //    _repository.InsertAccountInvestmentMap(request2);

        //    SetupPriceHistory(todaysValuationDate, todaysBuyPrice, todaysSellPrice);
        //    _priceHistoryTransaction.Execute();

        //    var valuation1 = todaysBuyPrice * request1.Quantity;
        //    var valuation2 = todaysBuyPrice * request2.Quantity;

        //    var investmentMap1 = _repository.GetAccountInvestmentMap(1);
        //    var investmentMap2 = _repository.GetAccountInvestmentMap(2);

        //    Assert.Equal(valuation1, investmentMap1.Valuation);
        //    Assert.Equal(valuation2, investmentMap2.Valuation);

        //    SetupPriceHistory(todaysValuationDate, todaysBuyPrice, todaysSellPrice);
        //    _priceHistoryTransaction.Execute();

        //    var investmentMap1 = _repository.GetAccountInvestmentMap(1);
        //    var investmentMap2 = _repository.GetAccountInvestmentMap(2);

        //    Assert.Equal(valuation1, investmentMap1.Valuation);
        //    Assert.Equal(valuation2, investmentMap2.Valuation);

        //}



        private AccountInvestmentMap CreateDummyInvestmentMap(int accountInvestmentMapId, int investmentId, int quantity)
        {
            return new AccountInvestmentMap()
            {
                AccountInvestmentMapId = accountInvestmentMapId,
                InvestmentId = investmentId,
                Quantity = quantity
            };
        }


        //[Fact]
        //public void WhenIAddAPriceHistoryTheFundIsAnOEICThenBothTheBuyAndSellPriceChange()
        //{
        //    var twoDaysAgo = DateTime.Now.AddDays(-2);
        //    var sellPriceTwoDaysAgo = 2;
        //    var buyPriceTwoDaysAgo = 2;
        //    Setup(twoDaysAgo, buyPriceTwoDaysAgo, sellPriceTwoDaysAgo ;);
        //    _priceHistoryTransaction.Execute();

        //    var sellPrice = _repository.GetInvestmentSellPrice(investmentMapId);
        //    var buyPrice = _repository.GetInvestmentSellPrice(investmentMapId);

        //    Assert.Equal(sellPriceTwoDaysAgo, sellPrice);
        //    Assert.Equal(buyPriceTwoDaysAgo, buyPrice);

        //    var yesterday = DateTime.Now.AddDays(-1);
        //    Setup(yesterday, 3, 3);

        //    sellPrice = _repository.GetInvestmentSellPrice(investmentMapId);
        //    buyPrice = _repository.GetInvestmentSellPrice(investmentMapId);

        //    Assert.Equal("This next", sellPrice);
        //    Assert.Equal("This next", buyPrice);
        //}



        //[Fact]
        //public void WhenIAddAPriceHistoryTheFundIsATrustThenOnlyTheSellPriceChanges()
        //{
        //    Assert.Equal("This next", currentSellPrice);
        //    Assert.Equal("This next", currentBuyPrice);
        //}

        //[Fact]
        //public void WhenMoreThanOnePriceExistsTheCurrentSellPriceIsTheOneThatIsClosestToTheCurrentDateButNotAfter()
        //{
        //    Assert.Equal("This next", currentSellPrice);
        //    Assert.Equal("This next", currentBuyPrice);
        //}

        //[Fact]
        //public void WhenMoreThanOnePriceExistsTheCurrentBuyPriceIsTheOneThatIsClosestToTheCurrentDateButNotAfter()
        //{
        //    Assert.Equal("This next", currentSellPrice);
        //    Assert.Equal("This next", currentBuyPrice);
        //}

    }
}
