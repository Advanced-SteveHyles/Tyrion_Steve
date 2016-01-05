using Xunit;

namespace NumberToWords
{
    public class SingleDebug
    {
        [Theory]
        [InlineData("5.53 £", "Five pounds and fifty three pence")]
        public void DebugOne(string number, string result)
        {
            var x = new FormattedNumber();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.ApplyFormat(parsedNumber));
        }
    }
}