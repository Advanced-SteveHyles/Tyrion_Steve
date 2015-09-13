using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary1
{
    public class UserStory1
    {
        private const string url = @"http://codingdojo.org/cgi-bin/index.pl?KataBankOCR";

        private readonly string[] _scenario1 = { " _  _  _  _  _  _  _  _  _ ", 
                                                 "| || || || || || || || || |", 
                                                 "|_||_||_||_||_||_||_||_||_|", 
                                                 "                           " };

        private readonly string[] _scenario2 = { "                           ", 
                                                 "  |  |  |  |  |  |  |  |  |", 
                                                 "  |  |  |  |  |  |  |  |  |", 
                                                 "                           " };

        private readonly string[] _scenario3 = { " _  _  _  _  _  _  _  _  _ ", 
                                                 " _| _| _| _| _| _| _| _| _|",
                                                 "|_ |_ |_ |_ |_ |_ |_ |_ |_ ",
                                                 "                           " };

        private readonly string[] _scenario4 = { " _  _  _  _  _  _  _  _  _ ",
                                                 " _| _| _| _| _| _| _| _| _|", 
                                                 " _| _| _| _| _| _| _| _| _|",
                                                 "                           " };

        private readonly string[] _scenario5 = { "                           ",
                                                 "|_||_||_||_||_||_||_||_||_|", 
                                                 "  |  |  |  |  |  |  |  |  |",
                                                 "                           " };




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
        public void Scenario1_AccountNumberIsAllZeros()
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

        [Fact]
        public void Scenario3_AccountNumberIsAllTwos()
        {
            var lineParser = new LineParser(_scenario3);
            lineParser
                .Validate()
                .Parse();

            Assert.Equal("222222222", lineParser.AccountNumber);
        }

        [Fact]
        public void Scenario4_AccountNumberIsAllThrees()
        {
            var lineParser = new LineParser(_scenario4);
            lineParser
                .Validate()
                .Parse();

            Assert.Equal("333333333", lineParser.AccountNumber);
        }

        [Fact]
        public void Scenario5_AccountNumberIsAllFours()
        {
            var lineParser = new LineParser(_scenario5);
            lineParser
                .Validate()
                .Parse();

            Assert.Equal("444444444", lineParser.AccountNumber);
        }


    }

    public class LineParser
    {
        private string[] _linesToParse;
        public bool LinesAreValid;
        private StringBuilder _accountNumber;
        private Dictionary<string, int> _ocrMapping;

        const string space = " ";
        const string pipe = "|";
        const string dash = "_";


        public LineParser(string[] scenario1)
        {
            SetUpDictionary();


            _linesToParse = scenario1;
            _accountNumber = new StringBuilder();
        }

        private void SetUpDictionary()
        {
            _ocrMapping = new Dictionary<string, int>();
            _ocrMapping.Add(SetupMatrix(space, dash, space, pipe, space, pipe, pipe, dash, pipe, space, space, space), 0);
            _ocrMapping.Add(SetupMatrix(space, space, space, space, space, pipe, space, space, pipe, space, space, space), 1);
            _ocrMapping.Add(SetupMatrix(space, dash, space, space, dash, pipe, pipe, dash, space, space, space, space), 2);
            _ocrMapping.Add(SetupMatrix(space, dash, space, space, dash, pipe, space, dash, pipe, space, space, space), 3);
            _ocrMapping.Add(SetupMatrix(space, space, space, pipe, dash, pipe, space, space, pipe, space, space, space), 4);

        }

        private string SetupMatrix(string char1, string char2, string char3, string char4, string char5, string char6, string char7, string char8, string char9, string char10, string char11, string char12)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}", char1, char2, char3, char4, char5, char6, char7, char8, char9, char10, char11, char12);
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

                var testString =
                    string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}",
                    _linesToParse[0][index], _linesToParse[0][index + 1], _linesToParse[0][index + 2],
                    _linesToParse[1][index], _linesToParse[1][index + 1], _linesToParse[1][index + 2],
                    _linesToParse[2][index], _linesToParse[2][index + 1], _linesToParse[2][index + 2],
                    _linesToParse[3][index], _linesToParse[3][index + 1], _linesToParse[3][index + 2])
                ;

                _accountNumber.Append(_ocrMapping[testString]);

            }

            return this;
        }

    }

}


