using System.Collections.Generic;

namespace NumberToWords
{
    public class NumberData
    {
        internal static Dictionary<char, ITranslatedNumber> SetUpNumbers()
        {
            return new Dictionary<char, ITranslatedNumber>()
            {
                {' ', new MissingTranslatedNumber("X")},
                { '0', new TranslatedNumber("0", "Zero", "Ten", "") },
                { '1', new TranslatedNumber("1", "One", "Eleven", "")},
                { '2', new TranslatedNumber("2", "Two", "Twelve", "Twenty")},
                { '3', new TranslatedNumber("3", "Three", "Thirteen", "Thirty")},
                { '4', new TranslatedNumber("4", "Four", "Fourteen", "Forty")},
                { '5', new TranslatedNumber("5", "Five", "Fifteen", "Fifty")},
                { '6', new TranslatedNumber("6", "Six", "Sixteen", "Sixty")},
                { '7', new TranslatedNumber("7", "Seven", "Seventeen", "Seventy")},
                { '8', new TranslatedNumber("8", "Eight", "Eighteen", "Eighty")},
                { '9', new TranslatedNumber("9", "Nine", "Nineteen", "Ninety")},                
            };
        }
    }
}