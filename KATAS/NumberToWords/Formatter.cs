using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace NumberToWords
{
    class Formatter
    {
        private string _output = string.Empty;
        public string GetFormattedResult => _output;

        public Formatter FormatForCurrency(ICurrency currency)
        {
            _output += currency.ToWords;

            return this;
        }

        public Formatter ProcessDecimalPoint(ICurrency currency, bool hasDecimalPoint)
        {
            if (currency is MissingCurrency && hasDecimalPoint)
            {
                _output += "point ";
            }

            return this;
        }

        public Formatter AddSpace()
        {
            _output += " ";
            return this;
        }

        public Formatter ProcessDigits(string number, Dictionary<char, ITranslatedNumber> numberFormatters)
        {
            var magnitude = number.Length +1;
            var andNeeded = false;
            var suppressZero = false;

            for (var index = 0; index < number.Length; index += 1)
            {
                magnitude--;
                var item = number[index];

                if (!numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }

                if (magnitude == 3)
                {
                    _output += numberFormatters[item].Unit + " Hundred ";
                    suppressZero = true;
                    andNeeded = true;
                }
                else if (magnitude == 2)
                {
                    if (item == '1')
                    {
                        _output += ApplyAnd(andNeeded);
                        item = number[index + 1];
                        _output += numberFormatters[item].TeenUnit + " ";
                        break;
                    }
                    else
                    {                      
                        if (suppressZero && item == '0')
                        {
                            continue;
                        }

                        _output += ApplyAnd(andNeeded);
                        _output += numberFormatters[item].OneMagnitudeUnit + " ";
                    }
                }
                else
                {
                    if (suppressZero && item == '0')
                    {
                        continue;
                    }

                    _output += numberFormatters[item].Unit + " ";
                }
                
            }

            _output = _output.Trim();

            return this;
        }

        private string ApplyAnd(bool andNeeded)
        {
            if (andNeeded)
            {
                return "and ";
            }

            return string.Empty;
        }

        public Formatter FinaliseFormat()
        {
            _output = _output[0].ToString().ToUpper() + _output.Substring(1).ToLower();

            return this;
        }
    }
}