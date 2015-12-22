namespace NumberToWords
{
    internal class MissingCurrency : ICurrency
    {
        public string Symbol => "Missing";
        public string MainCurrencyMultiple => "";
        public string MainCurrencySingle => "";
    }
}