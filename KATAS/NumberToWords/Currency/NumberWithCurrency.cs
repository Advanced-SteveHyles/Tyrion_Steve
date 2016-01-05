using System.Collections.Generic;
using System.Linq;

namespace NumberToWords
{
    public class NumberWithCurrency
    {
        private const string Zero = "Zero";
        private const string One = "One";

        private readonly Dictionary<char, ITranslatedNumber> _numberFormatters;
        private string _output;

        public NumberWithCurrency(Dictionary<char, ITranslatedNumber> numberFormatters)
        {
            _numberFormatters = numberFormatters;
        }

        public string TranslateCurrency(SplitNumber parsedNumber)
        {
            ICurrency currency = parsedNumber.CurrencyFormatter;
            ProcessIntegerCurrency(parsedNumber.IntegerPart);
            ResolveCurrencyPluralisation(parsedNumber.IntegerPartValue, currency.MajorCurrencySingle, currency.MajorCurrencyMultiple);
            ProcessFractionalCurrency(parsedNumber.FractionalPart, parsedNumber.IntegerPartValue, parsedNumber.FractionalPartValue);
            ResolveCurrencyPluralisation(parsedNumber.FractionalPartValue, currency.MinorCurrencySingle, currency.MinorCurrencyMultiple);

            return _output;
        }

        private void ProcessIntegerCurrency(string number)
        {
            var processingQueue = ConvertToQueue(number);

            var lowerOrderAndApplied = false;
            var lowerOrderAndNeeded = false;
            var higherOrderAndApplied = false;
            var higherOrderAndNeeded = false;
            var magnitudeOfDigit = number.Length + 1;

            while (processingQueue.Count > 0)
            {
                var item = processingQueue.Dequeue();
                magnitudeOfDigit--;

                if (magnitudeOfDigit < 0) return;

                if (!_numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }

                var digit = _numberFormatters[item].Unit;
                if (digit == Zero)
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
                _output += _numberFormatters[nextItem].TeenUnit + " ";
            }
            else
            {
                _output += _numberFormatters[item].OneMagnitudeUnit + " ";
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
                magnitude--;
                _output += _numberFormatters[nextItem].TeenUnit + " thousand ";
            }
            else
            {
                _output += _numberFormatters[item].OneMagnitudeUnit + " ";
            }
            return andIsUsed;
        }

        private bool ProcessOrder6(bool andNeeded, bool andIsUsed, Queue<char> processingQueue, char item)
        {
            andIsUsed = ApplyAnd(andNeeded, andIsUsed);

            var next = _numberFormatters[processingQueue.Peek()];
            if (next.Unit == Zero)
            {
                _output += _numberFormatters[item].Unit + " hundred thousand ";
            }
            else
            {
                _output += _numberFormatters[item].Unit + " hundred ";
            }
            return andIsUsed;
        }

        private void ProcessOrder7(char item)
        {
            _output += _numberFormatters[item].Unit + " million ";
        }

        private void ProcessOrder8(string digit, Queue<char> processingQueue, char item)
        {

            if (digit == One)
            {
                var nextItem = processingQueue.Dequeue();
                _output += _numberFormatters[nextItem].TeenUnit + " million ";
            }
            else
            {
                _output += _numberFormatters[item].OneMagnitudeUnit + " ";
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
                ApplyAnd();
                andIsUsed = true;
            }
            return andIsUsed;
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

        public void ResolveCurrencyPluralisation(int value, string majorCurrencySingle, string majorCurrencyMultiple)
        {
            if (value != 0)
            {
                _output += (value != 1 ? majorCurrencyMultiple : majorCurrencySingle) + " ";
            }
        }

        public void UppercaseFirstCharacter()
        {
            _output = _output[0].ToString().ToUpper() + _output.Substring(1).ToLower();

        }

        private void ProcessFractionalCurrency(string number, int integerValue, int decimalPart)
        {

            if (decimalPart == 0) return;

            if (integerValue != 0) ApplyAnd();


            var magnitude = 3;

            for (var index = 0; index < number.Length; index += 1)
            {
                var item = number[index];
                if (!_numberFormatters.Keys.Contains(item))
                {
                    _output += '?';
                    continue;
                }

                var unit = _numberFormatters[item].Unit;

                magnitude--;

                if (magnitude == 2)
                {
                    if (unit == "One")
                    {
                        item = number[index + 1];
                        _output += _numberFormatters[item].TeenUnit + " ";
                        break;
                    }
                    else
                    {
                        if (unit == "Zero")
                        {
                            continue;
                        }

                        _output += _numberFormatters[item].OneMagnitudeUnit + " ";
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

        private void ApplyAnd()
        {
            _output += "and ";
        }
    }
}