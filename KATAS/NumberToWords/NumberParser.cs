using System.Collections.Generic;

namespace NumberToWords
{
    public class NumberParser
    {
        public SplitNumber Parse(string number, Dictionary<string, ICurrency> supportedCurrencies)
        {
            var numberToSplit = number;
            var result = new SplitNumber {Currency = new MissingCurrency()};

            foreach (var currency in supportedCurrencies)
            {
                var currencyFormatter = currency.Value;
                if (numberToSplit.Contains(currencyFormatter.Symbol))
                {
                    result.Currency = currencyFormatter;
                    numberToSplit = numberToSplit.Replace(currencyFormatter.Symbol, string.Empty);
                    break;
                }
            }

            numberToSplit = numberToSplit.Replace(" ", "");

            string[] numberparts = numberToSplit.Split('.');             

            result.Integers = PrefixWithZeroIfRequired(numberparts[0]);

            if (numberparts.Length > 1)
            {
                result.HasPoint = true;
                result.Decimals = numberparts[1];
            }

            return result;
        }

        private static string PrefixWithZeroIfRequired(string numberparts)
        {
            return numberparts.Length == 0 ? "0" : numberparts;
        }
    }
}