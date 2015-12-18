using Xunit;
using Xunit.Abstractions;

namespace NumberToWords
{
    public class Complex
    {
        [Fact (Skip = "Not Sure Of Correct Scenario")]
        public void OneDollarAndACentReturns_variant1()
        {
            var number = "1.01 $";            
            var parsedNumber = new NumberParser().Parse(number);

            var x = new NumberSplitter();
            Assert.Equal("One Dollar point One Cent", x.Convert(parsedNumber));
        }

        [Fact(Skip = "Not Sure Of Correct Scenario")]
        public void OneDollarAndACentReturns_variant2()
        {
            var number = "1.01 $";
            var parsedNumber = new NumberParser().Parse(number);

            var x = new NumberSplitter();
            Assert.Equal("One Dollar And One Cent", x.Convert(parsedNumber));
        }

        [Fact(Skip = "Not Sure Of Correct Scenario")]
        public void OnePoundAndAPenceReturnsr()
        {
            var number = "1.01 £";
            var parsedNumber = new NumberParser().Parse(number);
            var x = new NumberSplitter();

            Assert.Equal("One Pound And One Pence", x.Convert(parsedNumber));
        }


        [Fact]
        public void FinalTest()
        {
            var number = "745.00 $";
            var x = new NumberSplitter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal("Seven hundred and forty five dollars", x.Convert(parsedNumber));
        }
    }
}