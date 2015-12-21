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
                        .ProcessIntegerDigits(parsedNumber.IntegerPart, parsedNumber.IntegerPartValue, parsedNumber.CurrencyFormatter)
                        .AddSpace()
                        .ProcessDecimalPoint(parsedNumber.CurrencyFormatter, parsedNumber.HasPoint)
                        .FormatForCurrency(parsedNumber.CurrencyFormatter, parsedNumber.IntegerPartValue)
                        .ProcessFractionalDigits(parsedNumber.FractionalPart, parsedNumber.FractionalPartValue, parsedNumber.CurrencyFormatter)
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
