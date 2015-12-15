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
        [Fact]
        public void ZeroReturnsZero()
        {
            var number ="0";
            var x = new NumberToWords(number);

            Assert.Equal("Zero", x.Convert() );
        }

        [Fact]
        public void OneReturnsOne()
        {
            var number = "1";
            var x = new NumberToWords(number);

            Assert.Equal("One", x.Convert());
        }

        [Fact]
        public void Handles44()
        {
            var number = "44";
            var x = new NumberToWords(number);

            Assert.Equal("Forty Four", x.Convert());
        }

        [Fact]
        public void Handles55()
        {
            var number = "55";
            var x = new NumberToWords(number);

            Assert.Equal("Fifty Five", x.Convert());
        }
    }

    }
