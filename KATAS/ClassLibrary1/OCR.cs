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
        private readonly string[] _testCase1 = { "_  _  _  _  _  _  _  _  _ ", "| || || || || || || || || |", "|_||_||_||_||_||_||_||_||_|", "" };

        [Fact]
        public void TestCase1_InputHas4Lines()
        {
            var lineParser = new LineParser(_testCase1);
            lineParser.Parse();
            Assert.Equal(4, lineParser.LinesFound());
        }

        [Fact]
        public void TestCase1_InputHas4Lines()
        {
            var lineParser = new LineParser(_testCase1);
            lineParser.Parse();
            Assert.Equal(4, lineParser.LinesFound());
        }


    }

    public class LineParser
    {
        private readonly string[] _linesToParse;

        public LineParser(string[] linesToParse)
        {
            _linesToParse = linesToParse;
        }

        public int LinesFound()
        {
            return _linesToParse.Count();
        }

        public void Parse()
        {
        }
    }

}
