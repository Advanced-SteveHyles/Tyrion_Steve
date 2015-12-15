using System.Collections.Generic;

namespace NumberToWords
{
    public class NumberSplitter
    {        
        public SplitNumber ParseNumber(string number, Dictionary<string, ICurrency> supportedCurrencies)
        {
            var numberToSplit = number;
            var result = new SplitNumber();

            foreach (var currency in supportedCurrencies)
            {
                var formatter = currency.Value;
                if (numberToSplit.Contains(formatter.Symbol))
                {
                    result.Currency = formatter.Symbol;
                    numberToSplit = numberToSplit.Replace(formatter.Symbol, string.Empty);
                    break;
                } 
            }

            numberToSplit = numberToSplit.Replace(" ", "");

            string[] numberparts = numberToSplit.Split('.');
            result.Integers = numberparts[0];

            if (numberparts.Length>1)
                result.Decimals = numberparts[1];

            return result;
        }
    }
}