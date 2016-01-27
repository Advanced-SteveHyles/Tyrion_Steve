using System.Collections.Generic;
using System.Linq;
using PortfolioManager.DTO;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository.Factories
{
    public class PortfolioFactory
    {
        public Portfolio CreatePortfolio(PortfolioDto portfolio)
        {
            return new Portfolio()
            {
                Id = portfolio.Id,
                Name = portfolio.Name,

                Accounts = portfolio.Accounts == null ? new List<Account>() : portfolio.Accounts.Select(a => AccountsFactory.CreateAccount(a)).ToList()
            };
        }
    }
}
