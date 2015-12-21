using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Xunit.Sdk;

namespace NumberToWords
{
    internal class Formatter
    {
        private string _output = string.Empty;
        public string GetFormattedResult => _output.Trim();

        private readonly Dictionary<char, ITranslatedNumber> numberFormatters = NumberData.SetUpNumbers();

        public Formatter FormatForCurrency(ICurrency currency, int value)
        {
            _output += value != 1 ? currency.MainCurrencyMultiple : currency.MainCurrencySingle;
            _output += " ";
            return this;
        }

        public Formatter ProcessDecimalPoint(ICurrency currency, bool hasDecimalPoint)
        {
            if (currency is MissingCurrency && hasDecimalPoint)
            {
                _output += "point";
            }

            return this;
        }

        public Formatter AddSpace()
        {
            _output += " ";
            return this;
        }

        public Formatter ProcessIntegerDigits(string number, int value, ICurrency currency)
        {
            var translateForCurrency = !(currency is MissingCurrency);

            int magnitude = number.Length + 1;

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

                if (!translateForCurrency)
                {
                    _output += ApplyAnd(andMaybeNeeded);
                    _output += unit + " ";
                    continue;
                }

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

                        if (translateForCurrency)
                        {
                            item = number[index + 1];
                            _output += numberFormatters[item].TeenUnit + " ";
                            break;
                        }
                        else
                        {
                            _output += numberFormatters[item].Unit + " ";
                        }
                    }
                    else
                    {
                        if (unit == "Zero")
                        {
                            if (translateForCurrency)
                            {
                                continue;
                            }
                            else
                            {
                                _output += numberFormatters[item].Unit + " ";
                                continue;
                            }
                        }
                        
                        if (translateForCurrency)
                        {
                            _output += ApplyAnd(andMaybeNeeded);
                            _output += numberFormatters[item].OneMagnitudeUnit + " ";
                        }
                        else
                        {
                            _output += numberFormatters[item].Unit + " ";
                        }
                    }

                    if (andMaybeNeeded)
                    {
                        andMaybeNeeded = false;
                    }

                }
                else
                {
                    if (unit == "Zero" && value > 0)
                    {
                        continue;
                    }

                    _output += ApplyAnd(andMaybeNeeded);
                    _output += unit + " ";
                    break;
                }

            }

            _output = _output.Trim();

            return this;
        }


        public Formatter ProcessFractionalDigits(string number, int value, ICurrency currency)
        {
            var translateForCurrency = !(currency is MissingCurrency);

            int magnitude;

            if (translateForCurrency)
            {
                if (number.Length > 2)
                {
                    magnitude = 3;
                }
                else
                {
                    magnitude = number.Length + 1;
                }

            }
            else
            {
                magnitude = number.Length + 1;
            }

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
                if (magnitude == 2)
                {
                    if (unit == "One")
                    {
                        if (translateForCurrency)
                        {
                            item = number[index + 1];
                            _output += numberFormatters[item].TeenUnit + " ";
                        }
                        else
                        {
                            _output += numberFormatters[item].Unit + " ";
                        }
                    }
                    else
                    {
                        if (unit == "Zero" & translateForCurrency)
                        {
                            continue;
                        }

                        if (translateForCurrency)
                        {
                            _output += numberFormatters[item].OneMagnitudeUnit + " ";
                            break;
                        }
                        else
                        {
                            _output += numberFormatters[item].Unit + " ";
                        }
                    }
                }
                else
                {
                    if (unit == "Zero" && translateForCurrency)
                    {
                        continue;
                    }

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