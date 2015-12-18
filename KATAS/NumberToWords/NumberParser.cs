using System;
using System.Collections.Generic;

namespace NumberToWords
{
    
    public class NumberParser
    {
        private readonly Dictionary<string, ICurrency> supportedCurrencies = CurrencyData.SetUpCurrencies();

        public SplitNumber Parse(string number)
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

            result.IntegerPart = PrefixWithZeroIfRequired(numberparts[0]);
            result.IntegerPartValue = Convert.ToInt32( result.IntegerPart);

            if (numberparts.Length > 1)
            {
                result.HasPoint = true;
                result.FractionalPart = numberparts[1];
                result.FractionalPartValue = Convert.ToInt32(result.FractionalPart);
            }

            return result;
        }

        private static string PrefixWithZeroIfRequired(string numberparts)
        {
            return numberparts.Length == 0 ? "0" : numberparts;
        }
    }
}