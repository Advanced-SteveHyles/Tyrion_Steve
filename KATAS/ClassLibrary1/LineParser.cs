using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1.Properties;

namespace ClassLibrary1
{
    public class LineParser
    {
        private string[] _linesToParse;
        public bool LinesAreValid;
        private List<string> _accountNumbers;
        private Dictionary<string, int> _ocrMapping;
        public int LineInError { get; set; }


        public LineParser()
        {
            SetUpDictionary();
            _accountNumbers = new List<string>();
        }

        private void SetUpDictionary()
        {
            _ocrMapping = new Dictionary<string, int>();
            _ocrMapping.Add(SetupMatrix(" ", "_", " ",
                                        "|", " ", "|",
                                        "|", "_", "|",
                                        " ", " ", " "), 0);

            _ocrMapping.Add(SetupMatrix(" ", " ", " ",
                                        " ", " ", "|",
                                        " ", " ", "|",
                                        " ", " ", " "), 1);

            _ocrMapping.Add(SetupMatrix(" ", "_", " ",
                                        " ", "_", "|",
                                        "|", "_", " ",
                                        " ", " ", " "), 2);

            _ocrMapping.Add(SetupMatrix(" ", "_", " ",
                                        " ", "_", "|",
                                        " ", "_", "|",
                                        " ", " ", " "), 3);

            _ocrMapping.Add(SetupMatrix(" ", " ", " ",
                                        "|", "_", "|",
                                        " ", " ", "|",
                                        " ", " ", " "), 4);

            _ocrMapping.Add(SetupMatrix(" ", "_", " ",
                                        "|", "_", " ",
                                        " ", "_", "|",
                                        " ", " ", " "), 5);

            _ocrMapping.Add(SetupMatrix(" ", "_", " ",
                                        "|", "_", " ",
                                        "|", "_", "|",
                                        " ", " ", " "), 6);

            _ocrMapping.Add(SetupMatrix(" ", "_", " ",
                                        " ", " ", "|",
                                        " ", " ", "|",
                                        " ", " ", " "), 7);

            _ocrMapping.Add(SetupMatrix(" ", "_", " ",
                                        "|", "_", "|",
                                        "|", "_", "|",
                                        " ", " ", " "), 8);

            _ocrMapping.Add(SetupMatrix(" ", "_", " ",
                                        "|", "_", "|",
                                        " ", "_", "|",
                                        " ", " ", " "), 9);
        }

        private string SetupMatrix(string char1, string char2, string char3, string char4, string char5, string char6, string char7, string char8, string char9, string char10, string char11, string char12)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}", char1, char2, char3, char4, char5, char6, char7, char8, char9, char10, char11, char12);
        }



        public List<string> AccountNumbers
        {
            get { return _accountNumbers; }
        }


        public LineParser ValidateFormat()
        {
            var linesChecked = 0;
            LineInError = 0;
            LinesAreValid = true;

            foreach (string line in _linesToParse)
            {
                if (line.Length != 27)
                {
                    LinesAreValid = false;
                    LineInError = linesChecked;
                    return this;
                }
                linesChecked ++;
            }

            return this;
        }

        public int LinesFound
        {
            get { return _linesToParse.Count(); }
        }

        public bool CheckSumsValid { get; private set; }

        public LineParser Parse()
        {
            StringBuilder accountNumber = new StringBuilder();

            for (var block = 0; block < _linesToParse.Count() - 1; block += 4)
            {
             
                for (var index = 0; index < 27; index += 3)
                {

                    var testString =
                        string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}",
                            _linesToParse[block + 0][index], _linesToParse[block + 0][index + 1], _linesToParse[block + 0][index + 2],
                            _linesToParse[block + 1][index], _linesToParse[block + 1][index + 1], _linesToParse[block + 1][index + 2],
                            _linesToParse[block + 2][index], _linesToParse[block + 2][index + 1], _linesToParse[block + 2][index + 2],
                            _linesToParse[block + 3][index], _linesToParse[block + 3][index + 1], _linesToParse[block + 3][index + 2])
                        ;

                    try
                    {
                        accountNumber.Append(_ocrMapping[testString]);
                    }
                    catch (Exception)
                    {
                        accountNumber.Append(testString);
                    }
                }
                _accountNumbers.Add(accountNumber.ToString());
                accountNumber.Clear();
            }

          

            return this;
        }


        public void ReadFile(string fileName)
        {
            _linesToParse = System.IO.File.ReadAllLines(fileName);
        }

        public void ValidateCheckSums()
        {
                
        }
    }
}