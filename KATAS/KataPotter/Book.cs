namespace KataPotter
{
    public class Book : IBook
    {
        private readonly int _number;
        private readonly double _price;

        public Book(int number, double price)
        {
            _number = number;
            _price = price;
        }

        public double Cost
        {
            get { return _price; }
        }

        public string Name
        {
            get { return string.Format("Book {0}", _number); }
        }
    }
}