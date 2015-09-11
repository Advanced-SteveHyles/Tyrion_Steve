using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary1
{
    public class OCR
    {
        private const string url = @"http://codingdojo.org/cgi-bin/index.pl?KataBankOCR";

        private readonly string[] _scenario1 = { " _  _  _  _  _  _  _  _  _ ", "| || || || || || || || || |", "|_||_||_||_||_||_||_||_||_|", "                           " };
        private readonly string[] _scenario2 = { "                           ", "  |  |  |  |  |  |  |  |  |", "  |  |  |  |  |  |  |  |  |", "                           " };
        /*
          " _  _  _  _  _  _  _  _  _ ", 
          "| || || || || || || || || |", 
          "|_||_||_||_||_||_||_||_||_|", 
          "                           " };
        */


        [Fact]
        public void TestCase1_InputHas4Lines()
        {
            var lineParser = new LineParser(_scenario1);
            lineParser
                .Validate();

            Assert.Equal(4, lineParser.LinesFound());
        }

        [Fact]
        public void TestCase1_InputLinesHave27Characters()
        {
            var lineParser = new LineParser(_scenario1);
            lineParser
                .Validate()
                .Parse();


            Assert.True(lineParser.LinesAreValid);
        }

        [Fact]
        public void TestCase1_FirstCharacterIsZero()
        {
            var lineParser = new LineParser(_scenario1);
            lineParser
                .Validate()
                .Parse();

            Assert.Equal('0', lineParser.AccountNumber[0]);
        }


        [Fact]
        public void TestCase1_AccountNumberIsAllZeros()
        {
            var lineParser = new LineParser(_scenario1);
            lineParser
                .Validate()
                .Parse();

            Assert.Equal("000000000", lineParser.AccountNumber);
        }

        [Fact]
        public void TestCase1_AccountNumberIsAllOnes()
        {
            var lineParser = new LineParser(_scenario2);
            lineParser
                .Validate()
                .Parse();

            Assert.Equal("111111111", lineParser.AccountNumber);
        }
        

    }

    public class LineParser
    {
        private string[] _linesToParse;
        public bool LinesAreValid;
        private StringBuilder _accountNumber;

        public LineParser(string[] scenario1)
        {
            _linesToParse = scenario1;
            _accountNumber = new StringBuilder();
        }

        public string AccountNumber
        {
            get { return _accountNumber.ToString(); }
        }


        public LineParser Validate()
        {
            LinesAreValid = true;

            foreach (string line in _linesToParse)
            {
                if (line.Length != 27)
                {
                    LinesAreValid = false;
                    return this;
                }
            }

            return this;
        }

        public int LinesFound()
        {
            return _linesToParse.Count();
        }

        public LineParser Parse()
        {
            for (var index = 0; index < 27; index += 3)
            {
                //Check for Zero.
                if (_linesToParse[0][index] == ' ' && _linesToParse[0][index + 1] == '_' && _linesToParse[0][index + 2] == ' ')
                {
                    //Either Zero or 8
                    if (_linesToParse[1][index] == '|' && _linesToParse[1][index + 1] == ' ' && _linesToParse[1][index + 2] == '|')
                    {
                        if (_linesToParse[2][index] == '|' && _linesToParse[2][index + 1] == '_' && _linesToParse[2][index + 2] == '|')
                        {
                            _accountNumber.Append("0");
                        }
                    }
                }


                if (_linesToParse[0][index] == ' ' && _linesToParse[0][index + 1] == ' ' && _linesToParse[0][index + 2] == ' ')
                {
                    if (_linesToParse[1][index] == ' ' && _linesToParse[1][index + 1] == ' ' && _linesToParse[1][index + 2] == '|')
                    {
                        if (_linesToParse[2][index] == ' ' && _linesToParse[2][index + 1] == ' ' && _linesToParse[2][index + 2] == '|')
                        {
                            _accountNumber.Append("1");
                        }
                    }
                }

            }
            
            return this;
        }

    }

}


