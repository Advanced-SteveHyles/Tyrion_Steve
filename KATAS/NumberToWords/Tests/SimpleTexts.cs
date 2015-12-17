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
            var x = new NumberSplitter(number);
            Assert.Equal(result, x.Convert());
        }
        
        [Theory]        
        [InlineData("22", "Twenty two")]
        [InlineData("33", "Thirty three")]
        [InlineData("44", "Forty four")]
        [InlineData("55", "Fifty five")]
        [InlineData("66", "Sixty six")]
        [InlineData("77", "Seventy seven")]
        [InlineData("88", "Eighty eight")]
        [InlineData("99", "Ninety nine")]
        public void HandlesWholeNumberLessThan100(string number, string result)
        {
            var x = new NumberSplitter(number);
            Assert.Equal(result, x.Convert());
        }

        [Theory]
        [InlineData("100", "One hundred")]
        [InlineData("101", "One hundred and one")]
        [InlineData("111", "One hundred and eleven")]
        [InlineData("666", "Six hundred and sixty six")]
        public void HandlesWholeNumberBetween100And1000(string number, string result)
        {
            var x = new NumberSplitter(number);
            Assert.Equal(result, x.Convert());
        }

        [Theory]
        [InlineData("10", "Ten")]
        [InlineData("11", "Eleven")]
        [InlineData("12", "Twelve")]
        [InlineData("13", "Thirteen")]
        [InlineData("14", "Fourteen")]
        [InlineData("15", "Fifteen")]
        [InlineData("16", "Sixteen")]
        [InlineData("17", "Seventeen")]
        [InlineData("18", "Eighteen")]
        [InlineData("19", "Nineteen")]
        public void HandlesTeens(string number, string result)
        {
            var x = new NumberSplitter(number);
            Assert.Equal(result, x.Convert());
        }

    }

}
