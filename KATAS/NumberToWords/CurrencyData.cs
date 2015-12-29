using System.Collections.Generic;

namespace NumberToWords
{
    public class CurrencyData
    {
        internal static Dictionary<string, ICurrency> SupportedCurrencies()
        {
            return new Dictionary<string, ICurrency>()
            {
                {"$", new SupportedCurrency("$", "dollar", "dollars") },
                {"£", new SupportedCurrency("£", "pound", "pounds") },
                {"Y", new SupportedCurrency("Y", "yen", "yen") },
                {"#", UnspecifiedCurrency() },
            };
        }

        private static SupportedCurrency UnspecifiedCurrency()
        {
            return new SupportedCurrency("#", string.Empty, string.Empty);
        }
    }
}