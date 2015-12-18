using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
    public class NumberSplitter
    {
        public string Convert(SplitNumber parsedNumber)
        {
            
            return new Formatter()
                        .ProcessDigits(parsedNumber.IntegerPart, parsedNumber.IntegerPartValue, false)
                        .AddSpace()
                        .ProcessDecimalPoint(parsedNumber.Currency, parsedNumber.HasPoint)
                        .FormatForCurrency(parsedNumber.Currency, parsedNumber.IntegerPartValue)
                        .ProcessDigits(parsedNumber.FractionalPart, parsedNumber.FractionalPartValue, true)
                        .FinaliseFormat()
                        .GetFormattedResult;
        }
    }

    internal class MissingCurrency : ICurrency
    {
        public string Symbol => "Missing";
        public string MainCurrencyMultiple => "";
        public string MainCurrencySingle => "";
    }
}
