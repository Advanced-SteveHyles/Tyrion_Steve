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
        private readonly string _number;
        private string _result = string.Empty;
        private readonly Dictionary<char, ITranslatedNumber> numberFormatters = NumberData.SetUpNumbers();
        private readonly Dictionary<string, ICurrency> supportedCurrencies = CurrencyData.SetUpCurrencies();

        public NumberSplitter(string number)
        {
            _number = number;
        }

        private void Parse()
        {
           var  numberParser = new NumberParser();
            var parsedNumber = numberParser.Parse(_number, supportedCurrencies);

            var formatter = new Formatter();
            _result = formatter
                        .ProcessDigits(parsedNumber.Integers, numberFormatters)
                        .AddSpace()
                        .ProcessDecimalPoint(parsedNumber.Currency, parsedNumber.HasPoint)
                        .FormatForCurrency(parsedNumber.Currency)
                        .ProcessDigits(parsedNumber.Decimals, numberFormatters)
                        .FinaliseFormat()
                        .GetFormattedResult;

            _result = _result.Trim();
            //Parse(number);
        }
        

        public string Convert()
        {
            Parse();
            ;
            return _result;
        }
    }

    internal class MissingCurrency : ICurrency
    {
        public string Symbol => "Missing";
        public string ToWords => "";
    }
}
