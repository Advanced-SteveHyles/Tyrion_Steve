namespace NumberToWords
{
    public interface ICurrency    {
        string Symbol { get; }
        string MajorCurrencyMultiple { get; }
        string MajorCurrencySingle { get;}
        string MinorCurrencyMultiple { get; }
        string MinorCurrencySingle { get; }
    }

    class SupportedCurrency : ICurrency
    {
        public SupportedCurrency(string symbol, string majorCurrencySingle, string majorCurrencyMultiple, string minorCurrencySingle, string minorCurrencyMultiple)
        {
            Symbol = symbol;
            MajorCurrencySingle = majorCurrencySingle;
            MajorCurrencyMultiple = majorCurrencyMultiple;

            MinorCurrencySingle = minorCurrencySingle;
            MinorCurrencyMultiple = minorCurrencyMultiple;
        }

        public string MinorCurrencyMultiple { get; }

        public string MinorCurrencySingle { get; }

        public string MajorCurrencySingle { get; }

        public string Symbol { get; }

        public string MajorCurrencyMultiple{get;}
        
    }
}