namespace NumberToWords
{
    public class SplitNumber
    {
        public string IntegerPart { get; set; }
        public int IntegerPartValue { get; set; }

        
        public ICurrency CurrencyFormatter { get ; set; }
        public bool HasPoint { get; set; }

        public string FractionalPart { get; set; }
        public int FractionalPartValue { get; set; }

        public SplitNumber()
        {
            FractionalPart = string.Empty;
            FractionalPartValue = 0;
        }
    }
}