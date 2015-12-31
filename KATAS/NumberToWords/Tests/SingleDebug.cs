using Xunit;

namespace NumberToWords
{
    public class SingleDebug
    {
        [Theory]
        [InlineData("10005 #", "Ten thousand and five")]
        public void DebugOne(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }
    }
}