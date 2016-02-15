using System.Linq;
using PortfolioManager.DTO.Requests;
using PortfolioManager.Repository.Entities;
using PortfolioManager.Repository.Interfaces;

namespace PortfolioManager.Repository.Repositories
{
    public class FundTransactionRepository : BaseRepository, IFundTransactionRepository
    {
        public FundTransactionRepository(PortfolioManagerContext context) : base(context){ }
        public FundTransaction GetFundTransaction(int fundTransactionId)
        {
            return _context.FundTransactions.SingleOrDefault(tx => tx.FundTransactionId == fundTransactionId);
        }

        public RepositoryActionResult<FundTransaction> InsertFundTransaction(CreateFundTransactionRequest request)
        {
            var fundTransaction = new FundTransaction()
            {
                
            };

            _context.FundTransactions.Add(fundTransaction);

            return fundTransaction;
        }
    }
}