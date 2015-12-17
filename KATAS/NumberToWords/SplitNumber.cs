namespace NumberToWords
{
    public class SplitNumber
    {
        public string Integers { get; set; }
        public string Decimals { get; set; }
        public ICurrency Currency { get ; set; }
        public bool HasPoint { get; set; }

        public SplitNumber()
        {
            Decimals = string.Empty;            
        }
    }
}