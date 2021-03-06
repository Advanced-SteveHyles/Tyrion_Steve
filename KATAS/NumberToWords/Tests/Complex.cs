using Xunit;
using Xunit.Abstractions;

namespace NumberToWords
{
    public class Complex
    {
     
        [Fact]
        public void FinalTest()
        {
            var number = "745.00 $";
            var x = new FormattedNumber();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal("Seven hundred and forty five dollars", x.ApplyFormat(parsedNumber));
        }
    }
}