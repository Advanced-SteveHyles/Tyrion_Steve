using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Transactions;
using PortfolioManager.DTO.Requests.Transactions;
using Xunit;

namespace BusinessLogicTests.Transactions.Fund
{
    public class PriceHistoryTests
    {
        private readonly FakeRepository _repository;
        private readonly PriceHistoryHandler _priceHistoryHandler;
        private CreatePriceHistoryTransaction _priceHistoryTransaction;

        private int investmentId = 629;

        public PriceHistoryTests()
        {
            _repository = new FakeRepository();
            _priceHistoryHandler = new PriceHistoryHandler(_repository);
        }

        private void SetupPriceHistory(DateTime date, decimal? buyAt, decimal? sellAt)
        {
            var priceHistoryRequest = new PriceHistoryRequest()
            {
                InvestmentId = investmentId,
                valuationDate = date,
                SellPrice = sellAt,
                BuyPrice = buyAt
            };

            _priceHistoryTransaction = new CreatePriceHistoryTransaction(
                priceHistoryRequest, _priceHistoryHandler);
        }

        public decimal? SellPrice { get; set; }

        [Fact]
        public void CanSaveAPriceHistory()
        {
            var evaluationDate = DateTime.Today;
            decimal? buyPrice = (decimal)1.25;
            decimal? sellPrice = (decimal)1.25;
            SetupPriceHistory(evaluationDate, buyPrice, sellPrice);

            Assert.True(_priceHistoryTransaction.CommandValid);
            _priceHistoryTransaction.Execute();
            Assert.True(_priceHistoryTransaction.ExecuteResult);

            var priceHistory = _repository.GetPriceHistory(investmentId);
            Assert.Equal(investmentId, priceHistory.InvestmentId);
            Assert.Equal(evaluationDate, priceHistory.ValuationDate);
            Assert.Equal(sellPrice, priceHistory.SellPrice);
            Assert.Equal(buyPrice, priceHistory.BuyPrice);
        }

        [Fact]
        public void WhenNoHistoricalPriceExistsTheCurrentPriceIsNull()
        {
            var currentSellPrice = _repository.GetInvestmentSellPrice(investmentId);
            var currentBuyPrice = _repository.GetInvestmentBuyPrice(investmentId);

            decimal? notDefinedSellPrice =null;
            decimal? notDefinedBuyPrice = null;

            Assert.Equal(notDefinedSellPrice, currentSellPrice);
            Assert.Equal(notDefinedBuyPrice, currentBuyPrice);
        }


        [Fact]
        public void WhenAHistoricalPriceExistsTheCurrentPriceIsTheClosestBeforeTheCurrentDate()
        {
            var evaluationDate = DateTime.Today;
            decimal? buyPrice = (decimal)1.25;
            decimal? sellPrice = (decimal)1.25;
            SetupPriceHistory(evaluationDate, buyPrice, sellPrice);
            _priceHistoryTransaction.Execute();

            var currentSellPrice = _repository.GetInvestmentSellPrice(investmentId);
            var currentBuyPrice = _repository.GetInvestmentBuyPrice(investmentId);

            Assert.Equal(sellPrice, currentSellPrice);
            Assert.Equal(buyPrice, currentBuyPrice);
        }

        [Fact]
        public void WhenAFutureDatePriceExistsTheCurrentPriceIsTheClosestBeforeTheCurrentDate()
        {
            var evaluationDate = DateTime.Today;
            decimal? buyPrice = (decimal)1.25;
            decimal? sellPrice = (decimal)1.25;
            SetupPriceHistory(evaluationDate, buyPrice, sellPrice);
            _priceHistoryTransaction.Execute();

            var tomorrowsDate = DateTime.Today;
            decimal? tomorrowsBuyPrice = (decimal)2.25;
            decimal? tomorrowsSellPrice = (decimal)2.25;
            SetupPriceHistory(tomorrowsDate, tomorrowsBuyPrice, tomorrowsSellPrice);
            _priceHistoryTransaction.Execute();

            var currentSellPrice = _repository.GetInvestmentSellPrice(investmentId);
            var currentBuyPrice = _repository.GetInvestmentBuyPrice(investmentId);

            Assert.Equal(sellPrice, currentSellPrice);
            Assert.Equal(buyPrice, currentBuyPrice);
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
