using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary1
{
  public  class TestUserStory_3
    {
        private FileReaderParserAndValidator _lineParser;
      private const string url = @"http://codingdojo.org/cgi-bin/index.pl?KataBankOCR";

      public TestUserStory_3()
        {
            _lineParser = new FileReaderParserAndValidator();
            _lineParser.ReadFile(@"C:\LEARNINGANDRAND\Tyrion_Steve\KATAS\ClassLibrary1\UseCase3.txt");
        }

      [Fact]
      public void AccountNumberForOutputline1_Is_000000051()
      {
          _lineParser
              .ValidateFormat()
              .Parse();

          Assert.Equal("000000051", _lineParser.AccountNumbers[0]);
      }

      [Fact]
      public void AccountNumberForOutputline2_Is_49006771QspaceERR()
      {
          _lineParser
              .ValidateFormat()
              .Parse();

          Assert.Equal("49006771? ILL", _lineParser.AccountNumbers[1]);
      }

      [Fact]
      public void AccountNumberForOutputline3_Is_1234Q678QspaceERR()
      {
          _lineParser
              .ValidateFormat()
              .Parse();

          Assert.Equal("1234?678? ILL", _lineParser.AccountNumbers[2]);
      }

    }
}
