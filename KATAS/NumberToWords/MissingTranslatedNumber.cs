namespace NumberToWords
{
    class MissingTranslatedNumber : ITranslatedNumber
    {

        public MissingTranslatedNumber(string number)
        {
            Number = number;
            TeenUnit = string.Empty;
            Unit = string.Empty;
            OneMagnitudeUnit = string.Empty;
        }

        public string Number { get; }
        public string Unit { get; }
        public string OneMagnitudeUnit { get; }
        public string TeenUnit { get; }
    }
}