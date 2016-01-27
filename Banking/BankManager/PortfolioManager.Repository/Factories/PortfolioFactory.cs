using System.Collections.Generic;
using System.Linq;
using PortfolioManager.DTO;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository.Factories
{
    public class PortfolioFactory
    {
        public Portfolio CreatePortfolio(PortfolioRequest portfolio)
        {
            return new Portfolio()
            {                
                Name = portfolio.Name,
                Accounts = new List<Account>()
            };
        }
    }
}
