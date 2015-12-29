using System;
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
    public class NumberToWordsFormatter
    {
        private string _output = string.Empty;
        public string GetFormattedResult => _output.Trim();
        private readonly Dictionary<char, ITranslatedNumber> numberFormatters = NumberData.SetUpNumbers();

        public string Format(SplitNumber parsedNumber)
        {
            ResolveIntegerDigits(parsedNumber.IntegerPart, parsedNumber.IntegerPartValue, parsedNumber.CurrencyFormatter);
            ResolveDecimalPoint(parsedNumber.CurrencyFormatter, parsedNumber.HasPoint);
            ResolveCurrencyPluralisation(parsedNumber.CurrencyFormatter, parsedNumber.IntegerPartValue);
            ResolveFractionalDigits(parsedNumber.FractionalPart, parsedNumber.FractionalPartValue, parsedNumber.CurrencyFormatter);
            UppercaseFirstCharacter();

            return GetFormattedResult;
        }


        public void ResolveIntegerDigits(string number, int value, ICurrency currency)
        {
            var translateForCurrency = !(currency is MissingCurrency);

            if (translateForCurrency)
            {
                ProcessIntegerCurrency(number, value);
            }
            else
            {
                ProcessNonCurrency(number);
            }
        }

        private void ProcessIntegerCurrency(string number, int value)
        {
          int magnitude = number.Length + 1;

            var andMaybeNeeded = false;
            bool skipNext = false;

            foreach (char item in number)
            {
                magnitude--;

                if (magnitude < 0) return;
                
                if (!numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }

                var unit = numberFormatters[item].Unit;

                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                if (unit == "Zero")
                {
                    magnitude --;
                    continue;
                }
                
                if (andMaybeNeeded)
                {
                    _output += ApplyAnd(andMaybeNeeded);
                    andMaybeNeeded = false;
                }

                if (magnitude == 9 && unit != "Zero")
                {
                    _output += numberFormatters[item].Unit + " hundred million ";                    
                }
                else if (magnitude == 8 && unit != "Zero")
                {
                    if (unit == "One")
                    {                        
                        var nextItem = number[number.Length - magnitude];
                        _output += numberFormatters[nextItem].TeenUnit + " million ";
                        skipNext = true;
                    }
                    else
                    {
                        _output += numberFormatters[item].OneMagnitudeUnit + " ";
                    }                      
                }
                else if (magnitude == 7 && unit != "Zero")
                {
                    _output += numberFormatters[item].Unit + " million ";                    
                }
                else if (magnitude == 6 && unit != "Zero")
                {
                    var next = numberFormatters[number[magnitude -1]];
                    if (next.Unit == "Zero")
                    {                        
                        _output += numberFormatters[item].Unit + " hundred thousand ";
                        skipNext = true;
                    }
                    else
                    {
                        _output += numberFormatters[item].Unit + " hundred ";
                    }                    
                }
                else if (magnitude == 5 && unit != "Zero")
                {                    
                    if (unit == "One")
                    {                        
                        var nextItem = number[number.Length - magnitude];
                        _output += numberFormatters[nextItem].TeenUnit + " thousand ";
                        skipNext=true;                        
                    }
                    else
                    {
                        _output += numberFormatters[item].OneMagnitudeUnit + " ";
                    }
                    andMaybeNeeded = true;
                }
                else if (magnitude == 4 && unit != "Zero")
                {
                    _output += unit + " thousand ";
                    andMaybeNeeded = true;
                }
                else if (magnitude == 3 && unit != "Zero")
                {
                    _output += unit + " Hundred ";
                    andMaybeNeeded = true;
                }
                else if (magnitude == 2 && unit != "Zero")
                {
                    if (unit == "One")
                    {
                        _output += ApplyAnd(andMaybeNeeded);                        
                        var nextItem= number[number.Length - magnitude];
                        _output += numberFormatters[nextItem].TeenUnit + " ";
                        skipNext=true;
                    }
                    else
                    {                        
                        _output += numberFormatters[item].OneMagnitudeUnit + " ";
                    }
                }
                else if (magnitude == 1 && unit != "Zero")
                {
                    _output += unit + " ";
                }
                else if (magnitude == 1 && unit == "Zero" && value == 0)
                {                    
                    _output += unit + " ";
                }
                else
                {
                    _output += unit + " ";
                }
            }
        }


        private void ProcessNonCurrency(string number)
        {
            for (var index = 0; index < number.Length; index += 1)
            {
                var item = number[index];

                if (!numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }

                var unit = numberFormatters[item].Unit;
                _output += unit + " ";
            }
        }

        public void ResolveCurrencyPluralisation(ICurrency currency, int value)
        {
            _output += (value != 1 ? currency.MainCurrencyMultiple : currency.MainCurrencySingle) + " ";
        }

        public void ResolveDecimalPoint(ICurrency currency, bool hasDecimalPoint)
        {
            if (currency is MissingCurrency && hasDecimalPoint)
            {
                _output += "point";
            }
        }


        public void ResolveFractionalDigits(string number, int value, ICurrency currency)
        {
            var translateForCurrency = !(currency is MissingCurrency);

            if (translateForCurrency)
            {
                ProcessFractionalCurrency(number);
            }
            else
            {
                ProcessNonCurrency(number);
            }
        }

        private void ProcessFractionalCurrency(string number)
        {
            var magnitude = 3;

            for (var index = 0; index < number.Length; index += 1)
            {
                var item = number[index];
                if (!numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }

                var unit = numberFormatters[item].Unit;

                magnitude--;

                if (magnitude == 2)
                {
                    if (unit == "One")
                    {
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

                        _output += numberFormatters[item].OneMagnitudeUnit + " ";
                    }
                }
                else
                {
                    if (unit == "Zero")
                    {
                        continue;
                    }

                    _output += unit + " ";
                    break;
                }
            }
        }

        private string ApplyAnd(bool andNeeded)
        {
            return andNeeded ? "and " : string.Empty;
        }

        public void UppercaseFirstCharacter()
        {
            _output = _output[0].ToString().ToUpper() + _output.Substring(1).ToLower();

        }
    }
}
