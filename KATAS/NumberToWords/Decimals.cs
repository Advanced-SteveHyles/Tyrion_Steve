using Xunit;

namespace NumberToWords
{
    public class Decimals
    {
        [Fact]
        public void Handles44P55()
        {
            var number = "44.55";
        var x = new NumberToWords(number);

        Assert.Equal("Fourty Four point Fifty Five", x.Convert());
        }
    }
}