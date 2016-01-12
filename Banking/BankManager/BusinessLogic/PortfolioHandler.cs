using Interfaces;

namespace BusinessLogic
{
    public class PortfolioHandler :   IPortfolioHandler
    {
        //HandlerBase,
        protected  IIOCContainer IOCC;

        public PortfolioHandler(IIOCContainer iocc)
        {
            this.IOCC = iocc;
        }

        public bool SavePortfolio(string portfolioName)
        {
            var dc = (IPortfolioRepository)IOCC.GetSingleInstance("IPortfolioRepository");
            dc.Save(portfolioName);
            return true;
        }

        public bool LoadPortfolio()
        {
            var dc = (IPortfolioRepository)IOCC.GetSingleInstance("IPortfolioRepository");

            return true;
        }
    }
}
