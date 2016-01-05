using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace NumberToWords
{
    public class FormattedNumber
    {
        private readonly Dictionary<char, ITranslatedNumber> numberFormatters = NumberData.SetUpNumbers();
        private readonly NumberWithCurrency _numberWithCurrency;

       
        public string ApplyFormat(SplitNumber parsedNumber)
        {

            var translateForCurrency = !(parsedNumber.CurrencyFormatter is MissingCurrency);

            string result;
            if (translateForCurrency)
            {
                var numberWithCurrency = new NumberWithCurrency(numberFormatters);
                result =  numberWithCurrency.TranslateCurrency(parsedNumber);
            }
            else
            {
                var x = new NumberNoCurrency(numberFormatters);
                result = x.TranslatePlain(parsedNumber);
            }

            result =  UppercaseFirstCharacter(result);
            return result.Trim();
        }

        private string UppercaseFirstCharacter(string result)
        {
            return result[0].ToString().ToUpper() + result.Substring(1).ToLower();
        }
    }
}