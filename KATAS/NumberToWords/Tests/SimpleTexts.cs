using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NumberToWords
{
    //http://www.codingdojo.org/cgi-bin/index.pl?KataNumbersInWords

    //Step 1 : Number to Words
    //Step 2: Word to numbers

    public class SimpleTexts
    {
        [Theory]
        [InlineData("0", "Zero")]
        [InlineData("1", "One")]
        [InlineData("8", "Eight")]
        [InlineData("9", "Nine")]
        public void HandlesWholeNumberLessThan10(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }
        
        [Theory]        
        [InlineData("22#", "Twenty two")]
        [InlineData("33#", "Thirty three")]
        [InlineData("44#", "Forty four")]
        [InlineData("55#", "Fifty five")]
        [InlineData("66#", "Sixty six")]
        [InlineData("77#", "Seventy seven")]
        [InlineData("88#", "Eighty eight")]
        [InlineData("99#", "Ninety nine")]
        public void HandlesWholeNumberLessThan100(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }

        [Theory]
        [InlineData("100 #", "One hundred")]
        [InlineData("101 #", "One hundred and one")]
        [InlineData("111 #", "One hundred and eleven")]
        [InlineData("666 #", "Six hundred and sixty six")]
        public void HandlesWholeNumberBetween100And1000(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }


        [Theory]
        [InlineData("10000 #", "Ten thousand")]
        [InlineData("10005 #", "Ten thousand and five")]
        [InlineData("11000 #", "Eleven thousand")]
        [InlineData("99999 #", "Ninety nine thousand nine hundred and ninety nine")]        
        public void HandlesWholeNumberBetween10000And99999WithCurrency(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }

        [Theory]
        [InlineData("10000", "One zero zero zero zero")]
        [InlineData("10005", "One zero zero zero five")]
        [InlineData("11000", "One one zero zero zero")]
        [InlineData("99999", "Nine nine nine nine nine")]
        public void HandlesWholeNumberBetween10000And99999(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }


        [Theory]
        [InlineData("10 $", "Ten dollars")]
        [InlineData("11 $", "Eleven dollars")]
        [InlineData("12 £", "Twelve pounds")]
        [InlineData("13 £", "Thirteen pounds")]
        [InlineData("14 £", "Fourteen pounds")]
        [InlineData("15 £", "Fifteen pounds")]
        [InlineData("16 £", "Sixteen pounds")]
        [InlineData("17 £", "Seventeen pounds")]
        [InlineData("18 $", "Eighteen dollars")]
        [InlineData("19 $", "Nineteen dollars")]
        [InlineData("10", "One zero")]
        [InlineData("11", "One one")]
        [InlineData("12", "One two")]
        [InlineData("13", "One three")]
        [InlineData("14", "One four")]
        [InlineData("15", "One five")]
        [InlineData("16", "One six")]
        [InlineData("17", "One seven")]
        [InlineData("18", "One eight")]
        [InlineData("19", "One nine")]
        public void HandlesTeens(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }

        [Theory]
        [InlineData("19 $", "Nineteen dollars")]
        public void DebugOne(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }

        [Theory]
        [InlineData("1000 #", "One thousand")]
        [InlineData("1220 #", "One thousand two hundred and twenty")]
        [InlineData("7025 #", "Seven thousand and twenty five")]
        public void HandlesWholeNumberBetween1000(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }
    }

}
