namespace Interfaces
{
    public interface IPortfolioHandler
    {
        bool LoadPortfolio();
        bool SavePortfolio(string portfolioName);
    }
}
