namespace NumberToWords
{
    public interface ICurrency    {
        string Symbol { get; }
        string ToWords { get; }
    }

    class SupportedCurrency : ICurrency
    {
        public SupportedCurrency(string symbol, string toWords)
        {
            Symbol = symbol;
            ToWords = toWords;
        }

        public string Symbol { get; }

        public string ToWords{get;}
        
    }
}