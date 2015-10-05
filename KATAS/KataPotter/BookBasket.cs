using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BookBasket
    {
        private readonly List<IBook> _bookCollection;
        
        private readonly BasketCostCalculator _basketCostCalculator;

        public BookBasket()
        {
            _bookCollection = new List<IBook>();

            _basketCostCalculator = new BasketCostCalculator(_bookCollection);
        }

        public BasketCostCalculator BasketCostCalculator
        {
            get { return _basketCostCalculator; }
        }

        public void AddBook(IBook book1)
        {
            _bookCollection.Add(book1);
        }
    }
}