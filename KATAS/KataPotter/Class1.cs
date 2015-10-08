using Xunit;

namespace KataPotter
{
    //http://codingdojo.org/cgi-bin/index.pl?KataPotter

    public class GivenIHaveAShoppingBasketOfBooks
    {
        private readonly BookBasket _basket;
        const double SingleBookPrice = 8.0;

        public GivenIHaveAShoppingBasketOfBooks()
        {
            _basket = new BookBasket();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(30)]
        public void WhenIHaveJustBooksOfTheSameTypeTheBasket8EurPerBook(int numberofBooks)
        {
            for (var bookCount = 0; bookCount < numberofBooks; bookCount++)
            {
                AddBookToBasket(1);
            }

            Assert.Equal(SingleBookPrice * numberofBooks, _basket.BasketCostCalculator.GetCheapestPrice());
        }

        [Fact]
        public void WhenIHaveTwoBookOfTheDifferentTypesBasketHas5PcDiscountApplied()
        {
            const double twoBooksWith5PcDiscount = (SingleBookPrice * 2) * 95 / 100;

            AddBookToBasket(1);
            AddBookToBasket(2);

            Assert.Equal(twoBooksWith5PcDiscount, _basket.BasketCostCalculator.GetCheapestPrice());
        }

        [Fact]
        public void WhenIHaveThreeBookOfTheDifferentTypesBasketHas10PcDiscountApplied()
        {
            const double threeBooksWith10PcDiscount = (SingleBookPrice * 3) * 90 / 100;

            AddBookToBasket(1);
            AddBookToBasket(2);
            AddBookToBasket(3);
            Assert.Equal(threeBooksWith10PcDiscount, _basket.BasketCostCalculator.GetCheapestPrice());
        }

        [Fact]
        public void WhenIHaveFourBooksOfDifferentTypesBasketHas20PcDiscountApplied()
        {
            const double fourBooksWith10PcDiscount = (SingleBookPrice * 4) * 80 / 100;

            AddBookToBasket(1);
            AddBookToBasket(2);
            AddBookToBasket(3);
            AddBookToBasket(5);
            Assert.Equal(fourBooksWith10PcDiscount, _basket.BasketCostCalculator.GetCheapestPrice());
        }

        [Fact]
        public void WhenIHaveFiveBooksOfDifferentTypesBasketHas25PcDiscountApplied()
        {
            const double fiveBooksWith10PcDiscount = (SingleBookPrice * 5) * 75 / 100;

            AddBookToBasket(1);
            AddBookToBasket(2);
            AddBookToBasket(3);
            AddBookToBasket(4);
            AddBookToBasket(5);
            Assert.Equal(fiveBooksWith10PcDiscount, _basket.BasketCostCalculator.GetCheapestPrice());
        }

        [Fact]
        public void WhenIHave2BooksOfOneTypeAndOneOfAnotherTheBasketHas5PercentDiscountAppliedToTheTwoBooks()
        {
            const double twoBookDiscount = (SingleBookPrice * 2) * 95 / 100;
            const double oneBookCost = SingleBookPrice;

            AddBookToBasket(1);
            AddBookToBasket(1);
            AddBookToBasket(2);
            Assert.Equal(oneBookCost + twoBookDiscount, _basket.BasketCostCalculator.GetCheapestPrice());
        }

        [Fact]
        public void WhenIHave2BooksOfOneTypeAndTwoOfAnotherTheBasketHas5PercentTooEachUniquePairOfBooks()
        {
            const double twoBookDiscount = (SingleBookPrice * 2) * 95 / 100;

            AddBookToBasket(1);
            AddBookToBasket(1);
            AddBookToBasket(2);
            AddBookToBasket(2);

            Assert.Equal(twoBookDiscount + twoBookDiscount, _basket.BasketCostCalculator.GetCheapestPrice());
        }

        [Fact]
        public void WhenIHave5UniqueBooksAnd1DuplicateTheCostIsReducedBy25PercentOnTheFiveBooksOnlyBooks()
        {
            const double fiveBookDiscount = (SingleBookPrice * 5) * 75 / 100;
            const double oneBookCost = SingleBookPrice;

            AddBookToBasket(1);
            AddBookToBasket(1);
            AddBookToBasket(2);
            AddBookToBasket(3);
            AddBookToBasket(4);
            AddBookToBasket(5);
            Assert.Equal(oneBookCost + fiveBookDiscount, _basket.BasketCostCalculator.GetCheapestPrice());
        }
        

        public void WhenIHave2Ones2Twos2Threes1Four1Five_TheBasketCosts_51point60()
        {
            AddBookToBasket(1);
            AddBookToBasket(2);
            AddBookToBasket(3);
            AddBookToBasket(4);
            AddBookToBasket(5);

            AddBookToBasket(1);    
            AddBookToBasket(2);
            AddBookToBasket(3);   

            Assert.Equal(51.60, _basket.BasketCostCalculator.GetCheapestPrice());
        }

        [Fact]
        public void WhenIHave2Ones2Twos2Threes1Four1Five_TheBasketCosts_51point20()
        {
            AddBookToBasket(1);
            AddBookToBasket(2);
            AddBookToBasket(3);
            AddBookToBasket(4);    

            AddBookToBasket(1);
            AddBookToBasket(2);
            AddBookToBasket(3);
            AddBookToBasket(5);

            Assert.Equal(51.20, _basket.BasketCostCalculator.GetCheapestPrice());

            var bestPriceSetSize = 4;
            Assert.Equal(bestPriceSetSize, _basket.BasketCostCalculator.BestPriceSetSize);

        }

        

        private void AddBookToBasket(int bookNumber)
        {
            _basket.AddBook(new Book(bookNumber, SingleBookPrice));
        }
    }
}
