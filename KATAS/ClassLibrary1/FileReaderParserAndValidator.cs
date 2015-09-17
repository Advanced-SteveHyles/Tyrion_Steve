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
        public bool LinesAreValid;
        private readonly List<string> _accountNumbers;
        private Dictionary<string, int> _ocrMapping;
        public int LineInError { get; set; }

        public FileReaderParserAndValidator()
        {
            SetUpDictionary();
            _accountNumbers = new List<string>();
        }

        private void SetUpDictionary()
        {
            _ocrMapping = new Dictionary<string, int>();
            _ocrMapping.Add(FormatLine(' ', '_', ' ',
                                        '|', ' ', '|',
                                        '|', '_', '|',
                                        ' ', ' ', ' '), 0);

            _ocrMapping.Add(FormatLine(' ', ' ', ' ',
                                        ' ', ' ', '|',
                                        ' ', ' ', '|',
                                        ' ', ' ', ' '), 1);

            _ocrMapping.Add(FormatLine(' ', '_', ' ',
                                        ' ', '_', '|',
                                        '|', '_', ' ',
                                        ' ', ' ', ' '), 2);

            _ocrMapping.Add(FormatLine(' ', '_', ' ',
                                        ' ', '_', '|',
                                        ' ', '_', '|',
                                        ' ', ' ', ' '), 3);

            _ocrMapping.Add(FormatLine(' ', ' ', ' ',
                                        '|', '_', '|',
                                        ' ', ' ', '|',
                                        ' ', ' ', ' '), 4);

            _ocrMapping.Add(FormatLine(' ', '_', ' ',
                                        '|', '_', ' ',
                                        ' ', '_', '|',
                                        ' ', ' ', ' '), 5);

            _ocrMapping.Add(FormatLine(' ', '_', ' ',
                                        '|', '_', ' ',
                                        '|', '_', '|',
                                        ' ', ' ', ' '), 6);

            _ocrMapping.Add(FormatLine(' ', '_', ' ',
                                        ' ', ' ', '|',
                                        ' ', ' ', '|',
                                        ' ', ' ', ' '), 7);

            _ocrMapping.Add(FormatLine(' ', '_', ' ',
                                        '|', '_', '|',
                                        '|', '_', '|',
                                        ' ', ' ', ' '), 8);

            _ocrMapping.Add(FormatLine(' ', '_', ' ',
                                        '|', '_', '|',
                                        ' ', '_', '|',
                                        ' ', ' ', ' '), 9);
        }

        private string FormatLine(char char1, char char2, char char3, char char4, char char5, char char6, char char7, char char8, char char9, char char10, char char11, char char12)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}", char1, char2, char3, char4, char5, char6, char7, char8, char9, char10, char11, char12);
        }



        public List<string> AccountNumbers
        {
            get { return _accountNumbers; }
        }


        public FileReaderParserAndValidator ValidateFormat()
        {
            var linesChecked = 0;
            LineInError = 0;
            LinesAreValid = true;

            foreach (string line in _fileLinesToParse)
            {
                if (line.Length != 27)
                {
                    LinesAreValid = false;
                    LineInError = linesChecked;
                    return this;
                }
                linesChecked++;
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
                    var testString =FormatLine (                        
                            _fileLinesToParse[fileLine + 0][linePosition], _fileLinesToParse[fileLine + 0][linePosition + 1], _fileLinesToParse[fileLine + 0][linePosition + 2],
                            _fileLinesToParse[fileLine + 1][linePosition], _fileLinesToParse[fileLine + 1][linePosition + 1], _fileLinesToParse[fileLine + 1][linePosition + 2],
                            _fileLinesToParse[fileLine + 2][linePosition], _fileLinesToParse[fileLine + 2][linePosition + 1], _fileLinesToParse[fileLine + 2][linePosition + 2],
                            _fileLinesToParse[fileLine + 3][linePosition], _fileLinesToParse[fileLine + 3][linePosition + 1], _fileLinesToParse[fileLine + 3][linePosition + 2]
                            );

                    try
                    {
                        accountNumber.Append(_ocrMapping[testString]);
                    }
                    catch (Exception)
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