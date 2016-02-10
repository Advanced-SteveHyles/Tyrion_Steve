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
        private FakeRepository _repository;
        private PriceHistoryHandler _priceHistoryHandler;
        private PriceHistoryRequest _priceHistoryRequest;
        private CreatePriceHistoryTransaction _priceHistoryTransaction;

        private int investmentMapId = 629;

        public PriceHistoryTests()
        {
            _repository = new FakeRepository();
            _priceHistoryHandler = new PriceHistoryHandler(_repository);            
        }

        private void CreatePriceHistory(DateTime date, decimal? buyAt, decimal? sellAt)
        {
            var priceHistoryRequest = new PriceHistoryRequest()
            {
                AccountInvestmentMapId = investmentMapId,
                valuationDate = date,
               SellPrice = sellAt,
               BuyPrice = buyAt
            };

            _priceHistoryTransaction = new CreatePriceHistoryTransaction(
                _priceHistoryRequest, _priceHistoryHandler);
        }

        public decimal? SellPrice { get; set; }

        [Fact]
        public void TransactionCommandIsValue()
        {
            Assert.True(_priceHistoryTransaction.CommandValid);
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
