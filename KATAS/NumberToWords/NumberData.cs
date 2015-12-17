using System.Collections.Generic;

namespace NumberToWords
{
    public class NumberData
    {
        internal static Dictionary<char, ITranslatedNumber> SetUpNumbers()
        {
            return new Dictionary<char, ITranslatedNumber>()
            {
                {' ', new MissingTranslatedTranslatedNumber("X")},
                { '0', new TranslatedTranslatedNumber("0", "Zero", "Ten", "") },
                { '1', new TranslatedTranslatedNumber("1", "One", "Eleven", "")},
                { '2', new TranslatedTranslatedNumber("2", "Two", "Twelve", "Twenty")},
                { '3', new TranslatedTranslatedNumber("3", "Three", "Thirteen", "Thirty")},
                { '4', new TranslatedTranslatedNumber("4", "Four", "Fourteen", "Forty")},
                { '5', new TranslatedTranslatedNumber("5", "Five", "Fifteen", "Fifty")},
                { '6', new TranslatedTranslatedNumber("6", "Six", "Sixteen", "Sixty")},
                { '7', new TranslatedTranslatedNumber("7", "Seven", "Seventeen", "Seventy")},
                { '8', new TranslatedTranslatedNumber("8", "Eight", "Eighteen", "Eighty")},
                { '9', new TranslatedTranslatedNumber("9", "Nine", "Nineteen", "Ninety")},
                //{ '.', " and "},            
            };
        }
    }
}