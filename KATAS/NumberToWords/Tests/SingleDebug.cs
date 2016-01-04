using Xunit;

namespace NumberToWords
{
    public class SingleDebug
    {
        [Theory]
        [InlineData("5.53 #", "Five fifty three")]
        public void DebugOne(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }
    }
}