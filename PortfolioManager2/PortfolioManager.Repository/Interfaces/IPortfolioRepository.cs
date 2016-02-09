using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository.Interfaces
{
    public interface IPortfolioRepository
    {
        System.Linq.IQueryable<Entities.Portfolio> GetPortfolios();

        Portfolio GetPortfolio(int id);
        Portfolio GetPortfolioWithAccounts(int id);
        RepositoryActionResult<Portfolio> InsertPortfolio(Portfolio entityPortfolio);
    }
}
