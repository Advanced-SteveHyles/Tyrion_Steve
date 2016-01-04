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

        [Fact]
        public void OneYen()
        {
            var number = "1Y";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new NumberToWordsFormatter();

            Assert.Equal("One yen", x.Format(parsedNumber));
        }


        [Theory]
        [InlineData("10000 £", "Ten thousand pounds")]
        [InlineData("10005 £", "Ten thousand and five pounds")]
        [InlineData("11000 £", "Eleven thousand pounds")]
        [InlineData("99999 £", "Ninety nine thousand nine hundred and ninety nine pounds")]
        public void HandlesWholeNumberBetween10000And99999(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }
    }
}   