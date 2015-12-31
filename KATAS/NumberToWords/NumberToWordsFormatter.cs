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
        private const string Zero = "Zero";
        private const string One= "One";

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
                ProcessIntegerCurrency(number);
            }
            else
            {
                ProcessNonCurrency(number);
            }
        }

        private void ProcessIntegerCurrency(string number)
        {
            var processingQueue = ConvertToQueue(number);

            var lowerOrderAndApplied = false;
            var lowerOrderAndNeeded = false;
            var higherOrderAndApplied = false;
            var higherOrderAndNeeded = false;
            var magnitudeOfDigit = number.Length +1;
            
            while (processingQueue.Count>0)
            {
                var item = processingQueue.Dequeue();
                magnitudeOfDigit--;

                if (magnitudeOfDigit < 0) return;
                
                if (!numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }

                var digit = numberFormatters[item].Unit;                
                if (digit == Zero && number.Length == 1)
                {
                    ProcessZeroDigit();
                    break;
                }
                else if (digit == Zero)
                {
                    continue;
                }
                
                switch (magnitudeOfDigit)
                {
                    case 9:
                        ProcessOrder9(digit);
                        lowerOrderAndNeeded = true;
                        break;
                    case 8:
                        ProcessOrder8(digit, processingQueue, item);
                        lowerOrderAndNeeded = true;
                        break;
                    case 7:
                        ProcessOrder7(item);
                        lowerOrderAndNeeded = true;
                        break;
                    case 6:
                        higherOrderAndApplied = ProcessOrder6(higherOrderAndNeeded, higherOrderAndApplied, processingQueue, item);
                        higherOrderAndNeeded = true;
                        lowerOrderAndNeeded = true;
                        break;
                    case 5:
                        higherOrderAndApplied = ProcessOrder5(digit, higherOrderAndNeeded, higherOrderAndApplied, processingQueue, item, ref magnitudeOfDigit);
                        higherOrderAndNeeded = false;
                        lowerOrderAndNeeded = true;
                        break;
                    case 4:
                        higherOrderAndApplied = ProcessOrder4(digit, higherOrderAndNeeded, higherOrderAndApplied);
                        lowerOrderAndNeeded = true;
                        break;
                    case 3:
                        ProcessOrder3(digit);
                        lowerOrderAndNeeded = true;
                        break;
                    case 2:
                        lowerOrderAndApplied = ProcessOrder2(lowerOrderAndNeeded, lowerOrderAndApplied, digit, processingQueue, item);
                        break;
                    case 1:
                        lowerOrderAndApplied = ProcessOrder1(lowerOrderAndNeeded, lowerOrderAndApplied, digit);
                        break;                   
                }
                

            }
        }

        private void ProcessZeroDigit()
        {
            _output += Zero + " ";
        }

        private static Queue<char> ConvertToQueue(string number)
        {
            var processingQueue = new Queue<char>();

            foreach (var item in number)
            {
                processingQueue.Enqueue(item);
            }
            return processingQueue;
        }

        private bool ProcessOrder1(bool andNeeded, bool andIsUsed, string digit)
        {
            andIsUsed = ApplyAnd(andNeeded, andIsUsed);

            _output += digit + " ";
            return andIsUsed;
        }

        private bool ProcessOrder2(bool andNeeded, bool andIsUsed, string digit, Queue<char> processingQueue, char item)
        {
            andIsUsed = ApplyAnd(andNeeded, andIsUsed);

            if (digit == "One")
            {
                var nextItem = processingQueue.Dequeue();
                _output += numberFormatters[nextItem].TeenUnit + " ";
            }
            else
            {
                _output += numberFormatters[item].OneMagnitudeUnit + " ";
            }
            return andIsUsed;
        }

        private void ProcessOrder3(string digit)
        {
            _output += digit + " hundred ";
        }

        private bool ProcessOrder4(string digit, bool andNeeded, bool andIsUsed)
        {
            andIsUsed = ApplyAnd(andNeeded, andIsUsed);

            _output += digit + " thousand ";
            return andIsUsed;
        }

        private bool ProcessOrder5(string digit, bool andNeeded, bool andIsUsed, Queue<char> processingQueue, char item,
            ref int magnitude)
        {
            andIsUsed = ApplyAnd(andNeeded, andIsUsed);

            if (digit == "One")
            {
                var nextItem = processingQueue.Dequeue();
                magnitude --;
                _output += numberFormatters[nextItem].TeenUnit + " thousand ";
            }
            else
            {
                _output += numberFormatters[item].OneMagnitudeUnit + " ";
            }
            return andIsUsed;
        }

        private bool ProcessOrder6(bool andNeeded, bool andIsUsed, Queue<char> processingQueue, char item)
        {
            andIsUsed = ApplyAnd(andNeeded, andIsUsed);

            var next = numberFormatters[processingQueue.Peek()];
            if (next.Unit == Zero)
            {
                _output += numberFormatters[item].Unit + " hundred thousand ";
            }
            else
            {
                _output += numberFormatters[item].Unit + " hundred ";
            }
            return andIsUsed;
        }

        private void ProcessOrder7(char item)
        {
            _output += numberFormatters[item].Unit + " million ";
        }

        private void ProcessOrder8(string digit, Queue<char> processingQueue, char item)
        {
        
            if (digit == One)
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

        private bool ApplyAnd(bool andNeeded, bool andIsUsed)
        {
            if (andNeeded && !andIsUsed)
            {
                _output += ApplyAnd();
                andIsUsed = true;
            }
            return andIsUsed;
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
