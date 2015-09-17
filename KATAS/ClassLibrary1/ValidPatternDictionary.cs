using System.Collections.Generic;

namespace ClassLibrary1
{
    public class ValidPatternDictionary
    {
        public static Dictionary<string, int> GetDictionary(FileReaderParserAndValidator fileReaderParserAndValidator)
        {
            var ocrMapping = new Dictionary<string, int>
            {
                {FormatLine( ' ', '_', ' ',
                    '|', ' ', '|',
                    '|', '_', '|',
                    ' ', ' ', ' '), 0},

                {FormatLine(' ', ' ', ' ',
                    ' ', ' ', '|',
                    ' ', ' ', '|',
                    ' ', ' ', ' '), 1},

                {FormatLine(' ', '_', ' ',
                    ' ', '_', '|',
                    '|', '_', ' ',
                    ' ', ' ', ' '), 2},

                {FormatLine(' ', '_', ' ',
                    ' ', '_', '|',
                    ' ', '_', '|',
                    ' ', ' ', ' '), 3},

                {FormatLine(' ', ' ', ' ',
                    '|', '_', '|',
                    ' ', ' ', '|',
                    ' ', ' ', ' '), 4},

                {FormatLine(' ', '_', ' ',
                    '|', '_', ' ',
                    ' ', '_', '|',
                    ' ', ' ', ' '), 5},

                {    FormatLine(' ', '_', ' ',
                    '|', '_', ' ',
                    '|', '_', '|',
                    ' ', ' ', ' '), 6},

                {     FormatLine(' ', '_', ' ',
                    ' ', ' ', '|',
                    ' ', ' ', '|',
                    ' ', ' ', ' '), 7},

                {     FormatLine(' ', '_', ' ',
                    '|', '_', '|',
                    '|', '_', '|',
                    ' ', ' ', ' '), 8},

                {    FormatLine(' ', '_', ' ',
                    '|', '_', '|',
                    ' ', '_', '|',
                    ' ', ' ', ' '), 9}

            };

            return ocrMapping;
        }

        public static string FormatLine(char char1, char char2, char char3, char char4, char char5, char char6, char char7, char char8, char char9, char char10, char char11, char char12)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}", char1, char2, char3, char4, char5, char6, char7, char8, char9, char10, char11, char12);
        }

    }
}