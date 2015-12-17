using Xunit;

namespace NumberToWords
{
    public class Decimals
    {
        [Fact]
        public void Handles44P55()
        {
            var number = "44.55";
        var x = new NumberSplitter(number);

        Assert.Equal("Forty four point fifty five", x.Convert());
        }

        [Fact]
        public void HandlesZeroP55()
        {
            var number = "0.55";
            var x = new NumberSplitter(number);

            Assert.Equal("Zero point fifty five", x.Convert());
        }

        [Fact]
        public void HandlesP55()
        {
            var number = ".55";
            var x = new NumberSplitter(number);

            Assert.Equal("Zero point fifty five", x.Convert());
        }

    }
}