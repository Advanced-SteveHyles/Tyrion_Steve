using PortfolioManager.Repository.Interfaces;

namespace PortfolioManager.Repository.Repositories
{
    public class PriceHistoryRepository : BaseRepository, IPriceHistoryRepository
    {
        public PriceHistoryRepository(PortfolioManagerContext context) : base(context){ }

    }
}