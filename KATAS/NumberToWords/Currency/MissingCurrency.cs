namespace NumberToWords
{
    internal class MissingCurrency : ICurrency
    {
        public string Symbol => "Missing";
        public string MajorCurrencyMultiple => "";
        public string MajorCurrencySingle => "";
        public string MinorCurrencyMultiple => "";
        public string MinorCurrencySingle => "";
    }
}