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
        private readonly Dictionary<string, int> _ocrMapping;
        private readonly ValidPatternDictionary _validPatternDictionary;
        private readonly Dictionary<int, LineInError> _badLineData;

        public FileReaderParserAndValidator()
        {
            _accountNumbers = new List<string>();
            _ocrMapping = ValidPatternDictionary.GetDictionary(this);
            _badLineData = new Dictionary<int, LineInError>();
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
            StringBuilder characters = new StringBuilder();
            for (var fileLine = 0; fileLine < _fileLinesToParse.Count() - 1; fileLine += 4)
            {
                var lineInError = new LineInError();

                var characterError = false;
    
                for (var linePosition = 0; linePosition < 27; linePosition += 3)
                {            
                    var testString = ValidPatternDictionary.FormatLine (                        
                            _fileLinesToParse[fileLine + 0][linePosition], _fileLinesToParse[fileLine + 0][linePosition + 1], _fileLinesToParse[fileLine + 0][linePosition + 2],
                            _fileLinesToParse[fileLine + 1][linePosition], _fileLinesToParse[fileLine + 1][linePosition + 1], _fileLinesToParse[fileLine + 1][linePosition + 2],
                            _fileLinesToParse[fileLine + 2][linePosition], _fileLinesToParse[fileLine + 2][linePosition + 1], _fileLinesToParse[fileLine + 2][linePosition + 2],
                            _fileLinesToParse[fileLine + 3][linePosition], _fileLinesToParse[fileLine + 3][linePosition + 1], _fileLinesToParse[fileLine + 3][linePosition + 2]
                            );

                    characters.Append(testString);

                    try
                    {
                        accountNumber.Append(_ocrMapping[testString]);
                    }
                    catch (KeyNotFoundException)
                    {
                        characterError = true;
                        accountNumber.Append("?");                        
                    }                  
                }

                if (characterError)
                {
                    lineInError.AccountNumber = accountNumber.ToString();
                    lineInError.ErrorType = " ILL";
                    lineInError.AccountId = _accountNumbers.Count;
                    lineInError.RawData = characters;
                    accountNumber.Append(lineInError.ErrorType);
                    _badLineData.Add(lineInError.AccountId, lineInError);
                }
                else if (!ValidateCheckSum(accountNumber.ToString()))
                {
                    lineInError.AccountNumber = accountNumber.ToString();
                    lineInError.ErrorType = " ERR";
                    lineInError.AccountId = _accountNumbers.Count;
                    lineInError.RawData = characters;
                    accountNumber.Append(lineInError.ErrorType);
                    _badLineData.Add(lineInError.AccountId, lineInError);
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
            var checksum = 0;
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

        public void CorrectLine(int i)
        {
            var lineInError = _badLineData.Single(f => f.Key == i).Value;

            if  (lineInError.ErrorType == "ILL")
            {                
                //Make Account Number Valid

                //Test Checksum

                //If more than 1, apply AMB
            }
            else
            {
                
            }

        }
    }

    public class LineInError
    {
        public string AccountNumber  { get; set; }
        public string ErrorType { get; set; }
        public int AccountId     { get; set; }
        public StringBuilder RawData { get; set; }
    }
}