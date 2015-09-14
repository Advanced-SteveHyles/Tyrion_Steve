using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using ClassLibrary1.Properties;

namespace ClassLibrary1
{
    public class LineParser
    {
        private string[] _linesToParse;
        public bool LinesAreValid;
        private StringBuilder _accountNumber;
        private Dictionary<string, int> _ocrMapping;


        public LineParser(string[] scenario1)
        {
            SetUpDictionary();
            _linesToParse = scenario1;
            _accountNumber = new StringBuilder();
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

        }

        private string SetupMatrix(string char1, string char2, string char3, string char4, string char5, string char6, string char7, string char8, string char9, string char10, string char11, string char12)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}", char1, char2, char3, char4, char5, char6, char7, char8, char9, char10, char11, char12);
        }



        public string AccountNumber
        {
            get { return _accountNumber.ToString(); }
        }


        public LineParser Validate()
        {
            LinesAreValid = true;

            foreach (string line in _linesToParse)
            {
                if (line.Length != 27)
                {
                    LinesAreValid = false;
                    return this;
                }
            }

            return this;
        }

        public int LinesFound()
        {
            return _linesToParse.Count();
        }

        public LineParser Parse(int line)
        {

            for (var index = 0; index < 27; index += 3)
            {

                var testString =
                    string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}",
                        _linesToParse[0][index], _linesToParse[0][index + 1], _linesToParse[0][index + 2],
                        _linesToParse[1][index], _linesToParse[1][index + 1], _linesToParse[1][index + 2],
                        _linesToParse[2][index], _linesToParse[2][index + 1], _linesToParse[2][index + 2],
                        _linesToParse[3][index], _linesToParse[3][index + 1], _linesToParse[3][index + 2])
                    ;

                _accountNumber.Append(_ocrMapping[testString]);

            }

            return this;
        }

        public string ReadFile(int useCase)
        {
            switch (useCase)
            {   
            case 1 ,2:
                {
            return Resources.UseCase1_2;                    
                    }
            }    
    }
    }
}