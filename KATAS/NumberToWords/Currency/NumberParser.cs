using System;
using System.Collections.Generic;

namespace NumberToWords
{
    
    public class NumberParser
    {
        private readonly Dictionary<string, ICurrency> supportedCurrencies = CurrencyData.SupportedCurrencies();

        public SplitNumber Parse(string number)
        {
            var currencyFormatter = ResolveCurrencyFormatter(number);

            var numberToSplit = number;
            numberToSplit = numberToSplit.Replace(currencyFormatter.Symbol, string.Empty);
            numberToSplit = numberToSplit.Replace(" ", "");

            string[] numberparts = numberToSplit.Split('.');

            var result = new SplitNumber
            {
                CurrencyFormatter = currencyFormatter,
                IntegerPart = PrefixWithZeroIfRequired(numberparts[0])
            };
            result.IntegerPartValue = Convert.ToInt32( result.IntegerPart);

            if (numberparts.Length > 1)
            {
                result.HasPoint = true;
                result.FractionalPart = numberparts[1];
                result.FractionalPartValue = Convert.ToInt32(result.FractionalPart);
            }

            return result;
        }

        private ICurrency ResolveCurrencyFormatter(string numberToSplit)
        {
            foreach (var currency in supportedCurrencies)
            {
                var currencyFormatter = currency.Value;
                if (numberToSplit.Contains(currencyFormatter.Symbol))
                {
                    return currencyFormatter;                                     
                }
            }
            return new MissingCurrency();
        }

        private static string PrefixWithZeroIfRequired(string numberparts)
        {
            return numberparts.Length == 0 ? "0" : numberparts;
        }
    }
}