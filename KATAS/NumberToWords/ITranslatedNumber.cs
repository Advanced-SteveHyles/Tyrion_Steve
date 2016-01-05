namespace NumberToWords
{
    public interface ITranslatedNumber
    {
        string Number { get; }

        string Unit { get; }
        string OneMagnitudeUnit { get; }
        string TeenUnit { get;}
    }
}