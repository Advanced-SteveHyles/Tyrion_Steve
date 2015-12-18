using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace NumberToWords
{
    class Formatter
    {
        private string _output = string.Empty;
        public string GetFormattedResult =>  _output.Trim();

        private readonly Dictionary<char, ITranslatedNumber> numberFormatters = NumberData.SetUpNumbers();

        public Formatter FormatForCurrency(ICurrency currency, int value)
        {
            _output += value != 1 ? currency.MainCurrencyMultiple : currency.MainCurrencySingle;
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

        public Formatter ProcessDigits(string number, int value, bool isFractionalPart)
        {
            var magnitude = number.Length +1;
            var andMaybeNeeded = false;

            for (var index = 0; index < number.Length; index += 1)
            {
                magnitude--;
                var item = number[index];

                if (!numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }


                var unit = numberFormatters[item].Unit;
                if (magnitude == 4 && unit != "Zero")
                {
                    _output += unit + " Thousand ";
                    andMaybeNeeded = true;
                }
                else if (magnitude == 3 && unit != "Zero")
                {
                    _output += unit + " Hundred ";
                    andMaybeNeeded = true;
                }
                else if (magnitude == 2)
                {
                    if (unit == "One")
                    {
                        _output += ApplyAnd(andMaybeNeeded);
                        item = number[index + 1];
                        _output += numberFormatters[item].TeenUnit + " ";
                        break;
                    }
                    else
                    {                      
                        if (unit == "Zero")
                        {
                            continue;
                        }

                        _output += ApplyAnd(andMaybeNeeded);
                        _output += numberFormatters[item].OneMagnitudeUnit + " ";
                    }

                    if (andMaybeNeeded)
                    {
                        andMaybeNeeded = false;
                    }

                }
                else
                {
                    if (unit == "Zero" && (value > 0 || isFractionalPart == true))
                    {
                        continue;
                    }

                    _output += ApplyAnd(andMaybeNeeded);
                    _output += unit + " ";
                }
                
            }

            _output = _output.Trim();

            return this;
        }

        private string ApplyAnd(bool andNeeded)
        {
            return andNeeded ? "and " : string.Empty;
        }

        public Formatter FinaliseFormat()
        {
            _output = _output[0].ToString().ToUpper() + _output.Substring(1).ToLower();

            return this;
        }
    }
}