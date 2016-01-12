using System.Linq;

namespace Interfaces
{
 public   interface IPortfolioRepository
    {
        IQueryable<IPortfolioDTO> GetAllPortfolios();

        void Save(int portfolioId, string portfolioName);
        void Save(string portfolioName);

     //   PortfolioDTO Find(int portfolioId);
    }
}
