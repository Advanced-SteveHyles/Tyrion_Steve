using Xunit;

namespace NumberToWords
{
    public class Currency
    {
        private readonly Decimals _decimals = new Decimals();

        [Fact]
        public void OneDollarReturns()
        {
            var number = "1 $";
            var x = new NumberSplitter(number);

            Assert.Equal("One Dollar", x.Convert());
        }

        [Fact]
        public void OnePoundReturns()
        {
            var number = "1 £";
            var x = new NumberSplitter(number);

            Assert.Equal("One Pound", x.Convert());
        }

        [Fact]
        public void OneNoCurrency()
        {
            var number = "1";
            var x = new NumberSplitter(number);

            Assert.Equal("One", x.Convert());
        }
    }
}   