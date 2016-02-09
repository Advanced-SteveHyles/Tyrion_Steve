using System;
using PortfolioManager.DTO.Requests;
using PortfolioManager.Repository.Entities;
using PortfolioManager.Repository.Interfaces;

namespace PortfolioManager.Repository
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(PortfolioManagerContext context): base(context)
        {        
        }

        public RepositoryActionResult<CashTransaction> ApplyCashTransaction(CreateCashTransactionRequest request)
        {
            var entityTransaction = new CashTransaction()
            {
                AccountId = request.AccountId,
                TransactionDate = request.TransactionDate,
                Source = request.Source,
                Value = request.Value,
                IsTaxRefund = request.IsTaxRefund,
                TransactionType = request.TransactionType
            };

            _context.Transactions.Add(entityTransaction);

            var result = _context.SaveChanges();
            if (result > 0)
            {
                return new RepositoryActionResult<CashTransaction>(entityTransaction, RepositoryActionStatus.Created);
            }
            else
            {
                return new RepositoryActionResult<CashTransaction>(entityTransaction, RepositoryActionStatus.NothingModified, null);
            }
        }
    }
}