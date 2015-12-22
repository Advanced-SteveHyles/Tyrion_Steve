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
            var parsedNumber = new NumberParser().Parse(number);
            var x = new NumberToWordsFormatter();

            Assert.Equal("One dollar", x.Format(parsedNumber));
        }

        [Fact]
        public void OnePoundReturns()
        {
            var number = "1 £";
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal("One pound", x.Format(parsedNumber));
        }

        [Fact]
        public void OneNoCurrency()
        {
            var number = "1";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new NumberToWordsFormatter();

            Assert.Equal("One", x.Format(parsedNumber));
        }
    }
}   