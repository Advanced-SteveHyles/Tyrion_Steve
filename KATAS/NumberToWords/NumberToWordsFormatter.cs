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
            const string zero = "Zero";
            
            var processingQueue = new Queue<char>();

            foreach (var item in number)
            {
                processingQueue.Enqueue(item);
            }

            bool and1Used = false;
            var and1Needed = false;

            bool and2Used = false;
            var and2Needed = false;

            int magnitude = number.Length + 1;

            
            while (processingQueue.Count>0)
            {
                var item = processingQueue.Dequeue();

                magnitude--;

                if (magnitude < 0) return;
                
                if (!numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }

                var digit = numberFormatters[item].Unit;
                
                if (digit == zero && number.Length == 1)
                {
                        _output += zero + " ";
                        return;                    
                }
                else if (digit == zero)
                {
                    continue;
                }
                
                if (magnitude == 9)
                {
                    ProcessOrder9(digit);                    
                }
                else if (magnitude == 8)
                {
                    ProcessOrder8(digit, processingQueue, item);
                }
                else if (magnitude == 7)
                {
                    ProcessOrder7(item);                    
                }
                else if (magnitude == 6)
                {
                    if (and2Needed && !and2Used)
                    {
                        _output += ApplyAnd();
                        and2Needed = false;
                        and2Used = true;
                    }

                    var next = processingQueue.Peek();
                    if (next == '0')
                    {                        
                        _output += numberFormatters[item].Unit + " hundred thousand ";
                        and2Needed = true;
                    }
                    else
                    {
                        _output += numberFormatters[item].Unit + " hundred ";
                    }
                    and2Needed = true;
                }
                else if (magnitude == 5)
                {
                    if (and2Needed && !and2Used)
                    {
                        _output += ApplyAnd();
                        and2Needed = false;
                        and2Used = true;
                    }

                    if (digit == "One")
                    {
                        var nextItem = processingQueue.Dequeue();
                        magnitude --;
                        _output += numberFormatters[nextItem].TeenUnit + " thousand ";
                        and2Needed = false;
                    }
                    else
                    {
                        _output += numberFormatters[item].OneMagnitudeUnit + " ";
                        and2Needed = false;
                    }

                    and1Needed = true;                    
                }
                else if (magnitude == 4)
                {
                    if (and2Needed && !and2Used)
                    {
                        _output += ApplyAnd();
                        and2Needed = false;
                        and2Used = true;
                    }


                    _output += digit + " thousand ";
                    and2Needed = true;
                    and1Needed = true;                    
                }
                else if (magnitude == 3)
                {
                    //if (and2Needed)
                    //{
                    //    _output += ApplyAnd();
                    //    and2Needed = false;
                    //}

                    _output += digit + " Hundred ";
                    and1Needed = true;
                }
                else if (magnitude == 2)
                {
                    if (and1Needed && !and1Used)
                    {
                        _output += ApplyAnd();
                        and2Needed = false;
                        and1Used = true;
                    }


                    if (digit == "One")
                    {                        
                        var nextItem = processingQueue.Dequeue();
                        _output += numberFormatters[nextItem].TeenUnit + " ";
                    }
                    else
                    {                        
                        _output += numberFormatters[item].OneMagnitudeUnit + " ";
                    }
                }
                else if (magnitude == 1)
                {
                    if (and1Needed && !and1Used)
                    {
                        _output += ApplyAnd();
                        and1Needed = false;
                    }
                    
                    _output += digit + " ";
                }                
                else
                {
                    if (and1Needed && !and1Used)
                    {
                        _output += ApplyAnd();
                        and1Needed = false;
                    }

                    _output += digit + " ";
                }
                

            }
        }

        private void ProcessOrder7(char item)
        {
            _output += numberFormatters[item].Unit + " million ";
        }

        private void ProcessOrder8(string digit, Queue<char> processingQueue, char item)
        {
            if (digit == "One")
            {
                var nextItem = processingQueue.Dequeue();
                _output += numberFormatters[nextItem].TeenUnit + " million ";
            }
            else
            {
                _output += numberFormatters[item].OneMagnitudeUnit + " ";
            }
        }

        private void ProcessOrder9(string digit)
        {
            _output += digit + " hundred million ";
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

        private string ApplyAnd()
        {
            return "and ";
        }

        public void UppercaseFirstCharacter()
        {
            _output = _output[0].ToString().ToUpper() + _output.Substring(1).ToLower();

        }
    }
}
