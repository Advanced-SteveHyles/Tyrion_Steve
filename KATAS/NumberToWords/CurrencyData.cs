using System.Collections.Generic;

namespace NumberToWords
{
    public class CurrencyData
    {
        internal static Dictionary<string, ICurrency> SetUpCurrencies()
        {
            return new Dictionary<string, ICurrency>()
            {
                {"$", new SupportedCurrency("$", "dollar", "dollars") },
                {"£", new SupportedCurrency("£", "pound", "pounds") },
                {"Missing", new MissingCurrency() }
            };
        }
    }
}