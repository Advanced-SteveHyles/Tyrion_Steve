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
            for (int bookCount = 0; bookCount < numberofBooks; bookCount ++)
            {
                _basket.AddBook(new Book1());    
            }
                        
            Assert.Equal(SingleBookPrice * numberofBooks, _basket.GetCost());
        }

        [Fact]
        public void WhenIHaveTwoBookOfTheDifferentTypesBasketHas5PCDiscountApplied()
        {
            const double twoBooksWith5PCDiscount = (SingleBookPrice * 2) * 95 / 100;

            _basket.AddBook(new Book1());
            _basket.AddBook(new Book2());
            Assert.Equal(twoBooksWith5PCDiscount, _basket.GetCost());
        }

        [Fact]
        public void WhenIHaveThreeBookOfTheDifferentTypesBasketHas10PCDiscountApplied()
        {
            const double threeBooksWith10PCDiscount = (SingleBookPrice * 3) * 90 / 100;

            _basket.AddBook(new Book1());
            _basket.AddBook(new Book2());
            _basket.AddBook(new Book3());
            Assert.Equal(threeBooksWith10PCDiscount, _basket.GetCost());
        }

        [Fact]
        public void WhenIHaveFourBooksOfDifferentTypesBasketHas20PCDiscountApplied()
        {
            const double fourBooksWith10PCDiscount = (SingleBookPrice * 4) * 80 / 100;

            _basket.AddBook(new Book1());
            _basket.AddBook(new Book2());
            _basket.AddBook(new Book3());
            _basket.AddBook(new Book5());
            Assert.Equal(fourBooksWith10PCDiscount, _basket.GetCost());
        }

        [Fact]
        public void WhenIHaveFiveBooksOfDifferentTypesBasketHas25PCDiscountApplied()
        {
            const double fiveBooksWith10PCDiscount = (SingleBookPrice * 5) * 75 / 100;

            _basket.AddBook(new Book1());
            _basket.AddBook(new Book2());
            _basket.AddBook(new Book3());
            _basket.AddBook(new Book4());
            _basket.AddBook(new Book5());
            Assert.Equal(fiveBooksWith10PCDiscount, _basket.GetCost());
        }

        [Fact]
        public void WhenIHave2BooksOfOneTypeAndOneOfAnotherTheBasketHas5PercentDiscountAppliedToTheTwoBooks()
        {
            const double twoBookDiscount = (SingleBookPrice * 2) * 5 / 100;
            const double oneBookCost = SingleBookPrice;

            _basket.AddBook(new Book1());
            _basket.AddBook(new Book1());
            _basket.AddBook(new Book2());
            Assert.Equal(oneBookCost + twoBookDiscount, _basket.GetCost());
        }


        [Fact(Skip = "Ultimate Test -WIP")]
        //[Fact]
        public void WhenIHave2Ones2Twos2Threes1Four1Five_TheBasketCosts_51point20()
        {
            _basket.AddBook(new Book1());
            _basket.AddBook(new Book1());
            _basket.AddBook(new Book2());
            _basket.AddBook(new Book2());
            _basket.AddBook(new Book3());
            _basket.AddBook(new Book3());
            _basket.AddBook(new Book4());
            _basket.AddBook(new Book5());

            Assert.Equal(51.20, _basket.GetCost());
        }
    }
}
