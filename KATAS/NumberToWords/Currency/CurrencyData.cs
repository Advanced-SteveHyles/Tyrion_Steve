using System.Collections.Generic;

namespace NumberToWords
{
    public class CurrencyData
    {
        internal static Dictionary<string, ICurrency> SupportedCurrencies()
        {
            return new Dictionary<string, ICurrency>()
            {
                {"$", new SupportedCurrency("$", "dollar", "dollars", "cent", "cents") },
                {"£", new SupportedCurrency("£", "pound", "pounds", "pence", "pence") },
                {"Y", new SupportedCurrency("Y", "yen", "yen", "","") },
                {"€", new SupportedCurrency("€", "euro", "euros", "cent","cents") },                
            };
        }
    }
}