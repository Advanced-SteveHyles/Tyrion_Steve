using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BasketCostCalculator
    {
        private readonly List<IBook> _bookBasket;
        private readonly Dictionary<int, double> _bookDiscounts;

        public BasketCostCalculator(List<IBook> bookBasket)
        {
            _bookBasket = bookBasket;

            _bookDiscounts = new Dictionary<int, double>
            {                
                   {1, 0},
                   {2, 5},
                   {3, 10},
                   {4, 20},
                   {5, 25},
            };
        }

        public double GetCost()
        {
            var booksToEvaluate = _bookBasket.ToArray();

            var costs = ComputeCosts(booksToEvaluate.ToList(),5);
            return costs;
        }

        private double ComputeCosts(List<IBook> booksToConsider, int maxNumberOfBooksInSet)
        {
            int bookCount = booksToConsider.Count();
            var uniqueBooksToConsider = booksToConsider.GroupBy(f => f.Name).ToList();

            var uniqueBookCount = uniqueBooksToConsider.Count();

            if (uniqueBookCount == bookCount && uniqueBookCount <= maxNumberOfBooksInSet)
            {
                return ProcessUniqueBooks(uniqueBookCount, booksToConsider);    
            }
            else
            {
                var uniqueBooks = new List<IBook>();
                var otherBooks = new List<IBook>();
                
                foreach (var uniqueBooksByBook in uniqueBooksToConsider)
                {
                    uniqueBooks.Add(uniqueBooksByBook.First());
                    otherBooks.AddRange(uniqueBooksByBook.Skip(1));
                }

                var total = 0.0;
                if (uniqueBooks.Count > 0)
                {
                    total += ComputeCosts(uniqueBooks, maxNumberOfBooksInSet);
                }

                if (otherBooks.Count > 0)
                {
                    total += ComputeCosts(otherBooks, maxNumberOfBooksInSet);
                }

                return total;
            }            
        }

        private double ProcessUniqueBooks(int uniqueBookCount, IEnumerable<IBook> bookBasket)
        {
            return ApplyDiscount(uniqueBookCount, bookBasket);                
        }

        private double ApplyDiscount(int uniqueBookCount, IEnumerable<IBook> bookBasket)
        {
            var rate = _bookDiscounts.Keys.Contains(uniqueBookCount) ? GetDiscountRate(uniqueBookCount) : GetNoneDiscountedRate();
            var costs = bookBasket.Sum(f => f.Cost) * (100 - rate) / 100;
            return costs;
        }

        private double GetDiscountRate(int uniqueBookCount)
        {            
            return _bookDiscounts[uniqueBookCount];
        }

        private static double GetNoneDiscountedRate()
        {            
            return 0;
        }

        public double GetCheapestPrice()
        {
            var booksToEvaluate = _bookBasket.ToArray();

            var bestPrice = ComputeCosts(booksToEvaluate.ToList(), 5);

            for (int maxNumberOfBooksInSet = 2; maxNumberOfBooksInSet < 5; maxNumberOfBooksInSet ++)
            {
                var secondAttempt = ComputeCosts(booksToEvaluate.ToList(), maxNumberOfBooksInSet);
                if (bestPrice > secondAttempt)
                {
                    bestPrice = secondAttempt;
                }
            }

            return bestPrice;
        }
    }
}