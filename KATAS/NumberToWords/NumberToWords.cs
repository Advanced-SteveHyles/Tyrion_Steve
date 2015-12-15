using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
    public class NumberToWords
    {
        private string _result = string.Empty;
        private readonly Dictionary<char, INumberTranslator> numberFormatters = new Dictionary<char, INumberTranslator>()
        {
            {' ', new EmptyNumberTranslator(" ")},
            { '0', new NumberTranslator("0", "Zero", "") },
            { '1', new NumberTranslator("1", "One", "Ten")},
            { '4', new NumberTranslator("4", "Four", "Forty")},
            { '5', new NumberTranslator("5", "Five", "Fifty")},
            //{ '.', " and "},            
        }     
        ;

        private readonly Dictionary<string, ICurrency> supportedCurrencies = new Dictionary<string, ICurrency>()
        {
            {"$", new SupportedCurrency("$", "Dollar") },
            {"£", new SupportedCurrency("£", "Pound") },
             {"Missing", new MissingCurrency() }
        };

        private readonly NumberSplitter _numberSplitter;


        public NumberToWords(string number)
        {
            _numberSplitter = new NumberSplitter();
            var parsedNumber = _numberSplitter.ParseNumber(number, supportedCurrencies);

            Process(parsedNumber.Integers);
            _result += " ";
            
            FormatForCurrency(parsedNumber.Currency);

            Process(parsedNumber.Decimals);

            _result = _result.Trim();
            //Parse(number);
        }

        private void FormatForCurrency(string currency)
        {
            if (supportedCurrencies.ContainsKey(currency))
                _result += supportedCurrencies[currency].ToWords;            
        }

        private void Process(string number)
        {
            var magnitude = number.Length;

            for (var index = 0; index < number.Length; index +=1)
            {
                var item = number[0];
                
                if (numberFormatters.Keys.Contains(item))
                {
                    if (magnitude == 2)
                    {
                        _result += numberFormatters[item].OneMagnitudeUnit + " ";
                    }
                    else
                    {
                        _result += numberFormatters[item].Unit + " ";
                    }
                }
                else
                {
                    _result += '?';
                }

                magnitude --;
            }

            _result = _result.Trim();
        }

        public string Convert()
        {
            return _result;
        }
    }

    internal class MissingCurrency : ICurrency
    {
        public string Symbol => "Missing";
        public string ToWords => "point";
    }
}
