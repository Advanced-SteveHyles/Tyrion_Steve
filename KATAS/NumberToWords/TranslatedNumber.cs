namespace NumberToWords   
{
    class TranslatedNumber : ITranslatedNumber
    {
        public string Number { get; }

        public string Unit { get; }
        public string OneMagnitudeUnit { get; }
        public string TeenUnit { get; }

        public TranslatedNumber(string number, string unit, string teenUnit, string oneMagnitudeUnit)
        {
            Number = number;
            Unit = unit;
            OneMagnitudeUnit = oneMagnitudeUnit;
            TeenUnit = teenUnit;
        }
    }
}