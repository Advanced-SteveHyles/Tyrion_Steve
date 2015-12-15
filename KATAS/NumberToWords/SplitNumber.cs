namespace NumberToWords
{
    public class SplitNumber
    {
        public string Integers { get; set; }
        public string Decimals { get; set; }
        public string Currency { get ; set; }

        public SplitNumber()
        {
            Decimals = string.Empty;
            Currency = "Missing";
        }
    }
}