using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1.Properties;

namespace ClassLibrary1
{
    public class FileReaderParserAndValidator //Breask SRP!!
    {
        private string[] _fileLinesToParse;
        public bool AllLinesAreValid;
        private readonly List<string> _accountNumbers;
        private Dictionary<string, int> _ocrMapping;
        private readonly ValidPatternDictionary _validPatternDictionary;

        public FileReaderParserAndValidator()
        {
            _accountNumbers = new List<string>();
            _ocrMapping = ValidPatternDictionary.GetDictionary(this);
        }
        
        public List<string> AccountNumbers
        {
            get { return _accountNumbers; }
        }


        public FileReaderParserAndValidator ValidateFormat()
        {
            AllLinesAreValid = true;

            if (_fileLinesToParse.Any(f => f.Length != 27))
            {
                AllLinesAreValid = false;
            }
            
            return this;
        }

        public int LinesFound
        {
            get { return _fileLinesToParse.Count(); }
        }

        public bool CheckSumsValid { get; private set; }

        public FileReaderParserAndValidator Parse()
        {
            StringBuilder accountNumber = new StringBuilder();

            for (var fileLine = 0; fileLine < _fileLinesToParse.Count() - 1; fileLine += 4)
            {
                var err = false;
    
                for (var linePosition = 0; linePosition < 27; linePosition += 3)
                {            
                    var testString = ValidPatternDictionary.FormatLine (                        
                            _fileLinesToParse[fileLine + 0][linePosition], _fileLinesToParse[fileLine + 0][linePosition + 1], _fileLinesToParse[fileLine + 0][linePosition + 2],
                            _fileLinesToParse[fileLine + 1][linePosition], _fileLinesToParse[fileLine + 1][linePosition + 1], _fileLinesToParse[fileLine + 1][linePosition + 2],
                            _fileLinesToParse[fileLine + 2][linePosition], _fileLinesToParse[fileLine + 2][linePosition + 1], _fileLinesToParse[fileLine + 2][linePosition + 2],
                            _fileLinesToParse[fileLine + 3][linePosition], _fileLinesToParse[fileLine + 3][linePosition + 1], _fileLinesToParse[fileLine + 3][linePosition + 2]
                            );

                    try
                    {
                        accountNumber.Append(_ocrMapping[testString]);
                    }
                    catch (KeyNotFoundException)
                    {
                        err = true;
                        accountNumber.Append("?");                        
                    }                    
                }

                if (err)
                {
                    accountNumber.Append(" ILL");
                }
                else if (!ValidateCheckSum(accountNumber.ToString()))
                {
                    accountNumber.Append(" ERR");
                }
                
                _accountNumbers.Add(accountNumber.ToString());
                accountNumber.Clear();
            }

            return this;
        }

        public void ReadFile(string fileName)
        {
            _fileLinesToParse = System.IO.File.ReadAllLines(fileName);
        }
        
        public bool ValidateCheckSum(string accountNumber)
        {
            // account number:  3  4  5  8  8  2  8  6  5
            // position names:   d9 d8 d7 d6 d5 d4 d3 d2 d1
            // checksum calculation:
            // (d1+2*d2+3*d3 +..+9*d9) mod 11 = 0

            int checksum = 0;
            var testAccountNumber = accountNumber.Reverse().ToList();
            var value = ExtractInt(testAccountNumber[0]);

            checksum = value + 2;

            for (var i = 1; i < 8; i++)
            {
                value = ExtractInt(testAccountNumber[i]);
                checksum *= value + (i + 2);                
            }

            value = ExtractInt(testAccountNumber[8]);
            checksum *= value;

            return checksum % 11 == 0;
        }

        private static int ExtractInt(char testAccountNumber)
        {
            int value;
            int.TryParse(testAccountNumber.ToString(), out value);
            return value;
        }
    }
}