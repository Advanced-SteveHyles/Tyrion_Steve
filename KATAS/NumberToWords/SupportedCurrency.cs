namespace NumberToWords
{
    public interface ICurrency    {
        string Symbol { get; }
        string MainCurrencyMultiple { get; }
        string MainCurrencySingle { get;}
    }

    class SupportedCurrency : ICurrency
    {
        public SupportedCurrency(string symbol, string mainCurrencySingle, string mainCurrencyMultiple)
        {
            Symbol = symbol;
            MainCurrencySingle = mainCurrencySingle;
            MainCurrencyMultiple = mainCurrencyMultiple;
        }

        public string MainCurrencySingle { get; set; }

        public string Symbol { get; }

        public string MainCurrencyMultiple{get;}
        
    }
}