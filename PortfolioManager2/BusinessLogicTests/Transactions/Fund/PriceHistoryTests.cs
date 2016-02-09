using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessLogicTests.Transactions.Fund
{
    public class PriceHistoryTests
    {
        [Fact]
        public void WhenIAddAPriceHistoryTheFundIsAnOEICThenBothTheBuyAndSellPriceChange()
        {
            var _FakeRepository = new FakeRepository();
            var priceHistoryHandler = new PriceHistoryHandler(_FakeRepository);
            var priceHistoryRequest = new PriceHistoryRequest();

            var priceHistoryTransaction = new PriceHistoryTransaction();
            priceHistoryTransaction.Execute();

            _FakeRepository.GetCurrentPrice();

            Assert.Equal("This next", currentSellPrice);
            Assert.Equal("This next", currentBuyPrice);
        }

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
