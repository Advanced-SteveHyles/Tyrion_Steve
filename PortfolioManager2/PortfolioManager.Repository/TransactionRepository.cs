using System;
using ExpenseTracker.Repository;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(PortfolioManagerContext context): base(context)
        {        
        }

        public RepositoryActionResult<Transaction> AddCashTransaction(int accountId, DateTime transactionDate, string source, decimal value, bool isTaxRefund, string transactionType)
        {
            var entityTransaction = new Transaction()
            {
                AccountId = accountId,
                TransactionDate = transactionDate,
                Source = source,
                Value = value,
                IsTaxRefund = isTaxRefund,
                TransactionType = transactionType
            };

            _context.Transactions.Add(entityTransaction);

            var result = _context.SaveChanges();
            if (result > 0)
            {
                return new RepositoryActionResult<Transaction>(entityTransaction, RepositoryActionStatus.Created);
            }
            else
            {
                return new RepositoryActionResult<Transaction>(entityTransaction, RepositoryActionStatus.NothingModified, null);
            }
        }

    }
}