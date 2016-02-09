using PortfolioManager.DTO.Requests;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        RepositoryActionResult<CashTransaction> ApplyCashTransaction(CreateCashTransactionRequest request);
    }
}