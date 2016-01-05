using Xunit;

namespace NumberToWords
{
    public class Decimals
    {

        [Fact]
        public void Handles544P55()
        {
            var number = "544.55";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new FormattedNumber();

            Assert.Equal("Five four four point five five", x.ApplyFormat(parsedNumber));
        }


        [Fact]
        public void Handles44P55()
        {
            var number = "44.55";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new FormattedNumber();

          Assert.Equal("Four four point five five", x.ApplyFormat(parsedNumber));
        }

        [Fact]
        public void Handles44P55WithCurrency()
        {
            var number = "44.55 $";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new FormattedNumber();

            Assert.Equal("Forty four dollars and fifty five cents", x.ApplyFormat(parsedNumber));
        }


        [Fact]
        public void HandlesZeroP55()
        {
            var number = "0.55";
            var x = new FormattedNumber();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal("Zero point five five", x.ApplyFormat(parsedNumber));
        }

        [Fact]
        public void HandlesZeroP55WithCurrency()
        {
            var number = "0.55 £";
            var x = new FormattedNumber();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal("Fifty five pence", x.ApplyFormat(parsedNumber));
        }
        
        [Fact]
        public void HandlesP55()
        {
            var number = ".55";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new FormattedNumber();

            Assert.Equal("Zero point five five", x.ApplyFormat(parsedNumber));
        }

        [Fact]
        public void DoesntContinueAfter2ndDpWhenCurrency()
        {
            var number = ".5555 $";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new FormattedNumber();

            Assert.Equal("Fifty five cents", x.ApplyFormat(parsedNumber));
        }

        [Fact]
        public void ShowsAfter2ndDpIfNotCurrency()
        {
            var number = ".5555";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new FormattedNumber();

            Assert.Equal("Zero point five five five five", x.ApplyFormat(parsedNumber));
        }

        [Theory]
        [InlineData("100000005.53 £", "One hundred million and five pounds and fifty three pence")]
        [InlineData("5.53 £", "Five pounds and fifty three pence")]
        [InlineData("500.03 £", "Five hundred pounds and three pence")]
        [InlineData("503 £", "Five hundred and three pounds")]
        [InlineData("500.03 £", "Five hundred pounds and three pence")]
        [InlineData("503 £", "Five hundred and three pounds")]        
        public void TroublesomeIrks(string number, string result)
        {
            var x = new FormattedNumber();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.ApplyFormat(parsedNumber));
        }

    }
}