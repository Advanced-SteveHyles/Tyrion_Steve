﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary1
{
   public class TestUserStory4
    {
            private FileReaderParserAndValidator _lineParser;
      private const string url = @"http://codingdojo.org/cgi-bin/index.pl?KataBankOCR";

      public TestUserStory4()
        {
            _lineParser = new FileReaderParserAndValidator();
            _lineParser.ReadFile(@"C:\LEARNINGANDRAND\Tyrion_Steve\KATAS\ClassLibrary1\UseCase4.txt");
        }

      [Fact (Skip = "No idea where to go with this!!")]
      public void AccountNumberForOutputline1_Is_111111111()
      {
          _lineParser
              .ValidateFormat()
              .Parse();

          _lineParser.CorrectLine(0);

          Assert.Equal("711111111", _lineParser.AccountNumbers[0]);
      }
    }
}
