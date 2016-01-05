using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberToWords
{
    public class NumberNoCurrency
    {
        private readonly Dictionary<char, ITranslatedNumber> _numberFormatters;
        private string _output;

        public NumberNoCurrency(Dictionary<char, ITranslatedNumber> numberFormatters)
        {
            _numberFormatters = numberFormatters;
        }


        public string TranslatePlain(SplitNumber parsedNumber)
        {
            ProcessNonCurrency(parsedNumber.IntegerPart);
            ResolveDecimalPoint(parsedNumber.CurrencyFormatter, parsedNumber.HasPoint);
            ProcessNonCurrency(parsedNumber.FractionalPart);

            return _output;
        }


        private void ProcessFractionalAdd(decimal value)
        {
            if (value != 0) ApplyAnd();
        }

        public void ResolveDecimalPoint(ICurrency currency, bool hasDecimalPoint)
        {
            if (currency is MissingCurrency && hasDecimalPoint)
            {
                _output += "point ";
            }
        }
        
          
        private void ApplyAnd()
        {
            _output += "and ";
        }


        private void ProcessNonCurrency(string number)
        {
            for (var index = 0; index < number.Length; index += 1)
            {
                var item = number[index];

                if (!_numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }

                var unit = _numberFormatters[item].Unit;
                _output += unit + " ";
            }
        }






    }
}