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
            var x = new NumberToWordsFormatter();

            Assert.Equal("Five four four point five five", x.Format(parsedNumber));
        }


        [Fact]
        public void Handles44P55()
        {
            var number = "44.55";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new NumberToWordsFormatter();

        Assert.Equal("Four four point five five", x.Format(parsedNumber));
        }

        [Fact]
        public void Handles44P55WithCurrency()
        {
            var number = "44.55 $";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new NumberToWordsFormatter();

            Assert.Equal("Forty four dollars fifty five", x.Format(parsedNumber));
        }


        [Fact]
        public void HandlesZeroP55()
        {
            var number = "0.55";
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal("Zero point five five", x.Format(parsedNumber));
        }

        [Fact]
        public void HandlesZeroP55WithCurrency()
        {
            var number = "0.55 £";
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal("Zero pounds fifty five", x.Format(parsedNumber));
        }


        [Fact]
        public void HandlesP55()
        {
            var number = ".55";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new NumberToWordsFormatter();

            Assert.Equal("Zero point five five", x.Format(parsedNumber));
        }

        [Fact]
        public void DoesntContinueAfter2ndDpWhenCurrency()
        {
            var number = ".5555 $";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new NumberToWordsFormatter();

            Assert.Equal("Zero dollars fifty five", x.Format(parsedNumber));
        }

        [Fact]
        public void ShowsAfter2ndDpIfNotCurrency()
        {
            var number = ".5555";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new NumberToWordsFormatter();

            Assert.Equal("Zero point five five five five", x.Format(parsedNumber));
        }

    }
}