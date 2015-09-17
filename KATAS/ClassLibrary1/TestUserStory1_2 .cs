using System;
using System.CodeDom;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary1
{
    public class UserStory1_2
    {
        //Tests changed to incoporate Validation rules from UserStory3

        private FileReaderParserAndValidator _lineParser;
        private const string url = @"http://codingdojo.org/cgi-bin/index.pl?KataBankOCR";

        public UserStory1_2()
        {
            _lineParser = new FileReaderParserAndValidator();
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
                
            Assert.True(_lineParser.AllLinesAreValid);
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
        public void TestCase1_AccountNumberIsAllOnesWithERR()
        {
           _lineParser
                .ValidateFormat()
                .Parse();

           Assert.Equal("111111111 ERR", _lineParser.AccountNumbers[1]);
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
        public void Line8_AccountNumberIsAllSevensWithERR()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("777777777 ERR", _lineParser.AccountNumbers[7]);
        }

        [Fact]
        public void Line9_AccountNumberIsAllEightsWithERR()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("888888888 ERR", _lineParser.AccountNumbers[8]);
        }

        [Fact]
        public void Line10_AccountNumberIsAllNinesWithERR()
        {
            _lineParser
                .ValidateFormat()
                .Parse();

            Assert.Equal("999999999 ERR", _lineParser.AccountNumbers[9]);
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
        public void AccountHasValidChecksum_000000000()
        {
            Assert.True(_lineParser.ValidateCheckSum("000000000"));            
        }

        [Fact]
        public void AccountHasInValidChecksum_111111111()
        {
            Assert.False(_lineParser.ValidateCheckSum("111111111"));
        }

        [Fact]
        public void AccountHasValidChecksum_8888888889()
        {
            Assert.False(_lineParser.ValidateCheckSum("888888888"));
        }
    }
}

