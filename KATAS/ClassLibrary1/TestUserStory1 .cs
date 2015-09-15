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
            _lineParser.ReadFile(@"C:\LEARNINGANDRAND\Tyrion_Steve\KATAS\ClassLibrary1\UseCase1_2.txt");
        }

        [Fact]
        public void TestCase1_InputHas43Lines()
        {
            _lineParser
                .ValidateFormat();

            Assert.Equal(44, _lineParser.LinesFound);
        }

        [Fact]
        public void TestCase1_InputLinesHave27Characters()
        {

            _lineParser
                .ValidateFormat();
                
            Assert.True(_lineParser.LinesAreValid);
        }

        [Fact]
        public void TestCase1_FirstCharacterIsZero()
        {

            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal('0', _lineParser.AccountNumbers[0][0]);
        }


        [Fact]
        public void Scenario1_AccountNumberIsAllZeros()
        {

            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("000000000", _lineParser.AccountNumbers[0]);
        }


        [Fact]
        public void TestCase1_AccountNumberIsAllOnes()
        {
           _lineParser
                .ValidateFormat()
                .Parse();

           Assert.Equal("111111111", _lineParser.AccountNumbers[1]);
        }

        [Fact]
        public void Scenario3_FirstCharacterLine3IsATwo()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal('2', _lineParser.AccountNumbers[2][0]);
        }

        [Fact]
        public void Scenario3_AccountNumberIsAllTwos()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("222222222", _lineParser.AccountNumbers[2]);
        }


        [Fact]
        public void Scenario4_AccountNumberIsAllThrees()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("333333333", _lineParser.AccountNumbers[3]);
        }

        [Fact]
        public void Scenario5_AccountNumberIsAllFours()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("444444444", _lineParser.AccountNumbers[4]);
        }

        [Fact]
        public void Line6_AccountNumberIsAllFives()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("555555555", _lineParser.AccountNumbers[5]);
        }

        [Fact]
        public void Line7_AccountNumberIsAllSixes()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("666666666", _lineParser.AccountNumbers[6]);
        }

        [Fact]
        public void Line8_AccountNumberIsAllSevens()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("777777777", _lineParser.AccountNumbers[7]);
        }

        [Fact]
        public void Line9_AccountNumberIsAllEights()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("888888888", _lineParser.AccountNumbers[8]);
        }

               [Fact]
        public void Line10_AccountNumberIsAllNines()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("999999999", _lineParser.AccountNumbers[9]);
        }


        [Fact]
        public void Line11_AccountNumberIs123456789()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("123456789", _lineParser.AccountNumbers[10]);
        }


        [Fact]
        public void Lines_ValidateChecksums()
        {
            _lineParser
                .ValidateFormat()
                .Parse()
                .ValidateCheckSums();

            Assert.True(_lineParser.CheckSumsValid);
        }

    }
}

