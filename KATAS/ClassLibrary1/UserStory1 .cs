using System;
using System.CodeDom;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary1
{
    public class UserStory1
    {
        private LineParser _lineParser;
        private string _fileData;
        private const string url = @"http://codingdojo.org/cgi-bin/index.pl?KataBankOCR";

        public UserStory1()
        {
            _lineParser = new LineParser();
            _fileData = _lineParser.ReadFile(1);
        }

        [Fact]
        public void TestCase1_InputHas4Lines()
        {
            _lineParser
                .Validate();

            Assert.Equal(4, _lineParser.LinesFound());
        }

        [Fact]
        public void TestCase1_InputLinesHave27Characters()
        {

            _lineParser
                .Validate()
                .Parse();


            Assert.True(_lineParser.LinesAreValid);
        }

        [Fact]
        public void TestCase1_FirstCharacterIsZero()
        {

            _lineParser
                .Validate()
                .Parse();

            Assert.Equal('0', _lineParser.AccountNumber[0]);
        }


        [Fact]
        public void Scenario1_AccountNumberIsAllZeros()
        {

            _lineParser
                .Validate()
                .Parse();

            Assert.Equal("000000000", _lineParser.AccountNumber);
        }


        [Fact]
        public void TestCase1_AccountNumberIsAllOnes()
        {
           _lineParser
                .Validate()
                .Parse();

           Assert.Equal("111111111", _lineParser.AccountNumber);
        }

        [Fact]
        public void Scenario3_AccountNumberIsAllTwos()
        {
            _lineParser
                .Validate()
                .Parse();

            Assert.Equal("222222222", _lineParser.AccountNumber);
        }

        [Fact]
        public void Scenario4_AccountNumberIsAllThrees()
        {
            _lineParser
                .Validate()
                .Parse();

            Assert.Equal("333333333", _lineParser.AccountNumber);
        }

        [Fact]
        public void Scenario5_AccountNumberIsAllFours()
        {
            _lineParser
                .Validate()
                .Parse();

            Assert.Equal("444444444", _lineParser.AccountNumber);
        }
    }
}


