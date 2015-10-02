using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BookBasket
    {
        private readonly List<IBook> _bookCollection;

        public BookBasket()
        {
            _bookCollection = new List<IBook>();
        }

        public double GetCost()
        {
            return ComputeCosts();
        }

        private double ComputeCosts()
        {
            var collectionGroup = _bookCollection.GroupBy(f => f.Name);
            var bookCount = _bookCollection.Count;
            var uniqueBookCount = collectionGroup.Count();

            var costs = 0.0;

            if (bookCount == 2 && uniqueBookCount == 2)
            {
                return ApplyDiscount(5);
            }

            if (bookCount == 3 && uniqueBookCount == 3)
            {
                return ApplyDiscount(10);
            }

            if (bookCount == 4 && uniqueBookCount == 4)
            {
                return ApplyDiscount(20);
            }

            if (bookCount == 5 && uniqueBookCount == 5)
            {
                return ApplyDiscount(25);
            }


            return _bookCollection.Sum(f => f.Cost);
        }

        private double ApplyDiscount(int discountRate)
        {
            double costs;
            costs = _bookCollection.Sum(f => f.Cost)* (100 - discountRate) /100;
            return costs;
        }

        public void AddBook(IBook book1)
        {
            _bookCollection.Add(book1);
        }
    }
}