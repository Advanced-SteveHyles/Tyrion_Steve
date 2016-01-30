using System.Collections.Generic;
using PortfolioManager.DTO;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository.Factories
{
    public class AccountFactory
    {
        public Account CreateAccount(AccountRequest account)
        {
            return new Account()
            {
                PortfolioId = account.PortfolioId,
                Name = account.Name,
                Investments = new List<InvestmentMap>(),
                Cash = 0,
                Valuation = 0,
                Type = "Not Set"
            };
        }
    }
}