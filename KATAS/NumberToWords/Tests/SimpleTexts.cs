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
        private readonly SingleDebug _singleDebug = new SingleDebug();

        [Theory]
        [InlineData("0", "Zero")]
        [InlineData("1", "One")]
        [InlineData("2", "Two")]
        [InlineData("8", "Eight")]
        [InlineData("9", "Nine")]
        [InlineData("22 £", "Twenty two pounds")]
        [InlineData("33 £", "Thirty three pounds")]
        [InlineData("44 £", "Forty four pounds")]
        [InlineData("55 £", "Fifty five pounds")]
        [InlineData("66 £", "Sixty six pounds")]
        [InlineData("77 £", "Seventy seven pounds")]
        [InlineData("88 £", "Eighty eight pounds")]
        [InlineData("99 £", "Ninety nine pounds")]
        public void HandlesWholeNumberLessThan100(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }

        [Theory]
        [InlineData("100 £", "One hundred pounds")]
        [InlineData("101 £", "One hundred and one pounds")]
        [InlineData("111 £", "One hundred and eleven pounds")]
        [InlineData("666 £", "Six hundred and sixty six pounds")]
        public void HandlesWholeNumberBetween100And1000(string number, string result)
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
//        [InlineData("19 #", "Nineteen")]
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
        [InlineData("1000 $", "One thousand dollars")]
        [InlineData("1220 $", "One thousand two hundred and twenty dollars")]
        [InlineData("7025 $", "Seven thousand and twenty five dollars")]
        public void HandlesWholeNumberBetween1000(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }


        [Theory]
        [InlineData("100000 Y", "One hundred thousand yen")]
        [InlineData("110000 Y", "One hundred and ten thousand yen")]
        [InlineData("111000 Y", "One hundred and eleven thousand yen")]
        [InlineData("111100 Y", "One hundred and eleven thousand one hundred yen")]
        [InlineData("111110 Y", "One hundred and eleven thousand one hundred and ten yen")]
        [InlineData("123456 Y", "One hundred and twenty three thousand four hundred and fifty six yen")]
        [InlineData("123407 Y", "One hundred and twenty three thousand four hundred and seven yen")]
        [InlineData("1000000 Y", "One million yen")]
        [InlineData("10000000 Y", "Ten million yen")]
        [InlineData("100000000 Y", "One hundred million yen")]
        public void HandlesWholeNumberBetween100000and100Million(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }

        [Theory]
        [InlineData("100000005 Y", "One hundred million and five yen")]
        [InlineData("100000010 Y", "One hundred million and ten yen")]
        [InlineData("100000050 Y", "One hundred million and fifty yen")]
        [InlineData("100000100 Y", "One hundred million one hundred yen")]
        public void HandlesWholeNumberAboveMillion(string number, string result)
        {
            var x = new NumberToWordsFormatter();
            var parsedNumber = new NumberParser().Parse(number);
            Assert.Equal(result, x.Format(parsedNumber));
        }

    }

}
