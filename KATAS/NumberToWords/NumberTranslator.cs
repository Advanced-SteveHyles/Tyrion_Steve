namespace NumberToWords   
{
    class EmptyNumberTranslator : INumberTranslator
    {

        public EmptyNumberTranslator(string number)
        {
            Number = number;
            Unit = string.Empty;
            OneMagnitudeUnit = string.Empty;
        }

        public string Number { get; }
        public string Unit { get; }
        public string OneMagnitudeUnit { get; }
    }

    class NumberTranslator : INumberTranslator
    {
        public string Number { get; }

        public string Unit { get; }
        public string OneMagnitudeUnit { get; }

        public NumberTranslator(string number, string unit, string oneMagnitudeUnit)
        {
            Number = number;
            Unit = unit;
            OneMagnitudeUnit = oneMagnitudeUnit;
        }
    }

    internal interface INumberTranslator
    {
        string Number { get; }

        string Unit { get; }
        string OneMagnitudeUnit { get; }
    }
}