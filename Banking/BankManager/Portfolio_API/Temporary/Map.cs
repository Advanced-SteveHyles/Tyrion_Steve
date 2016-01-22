using System.Linq;
using Entities;
using PortfolioManager.DTO;

namespace Portfolio_API.Controllers
{
    internal class Map
    {
        public static AccountDto CreateAccount(Entities.AccountEnt accountEnt)
        {
            return new AccountDto()
            {
                Id = accountEnt.Id,
                Name = accountEnt.Name,
                Cash = accountEnt.Cash,
                Valuation = accountEnt.Valuation
            };
        }

        public static PortfolioDto CreatePortfolio(Entities.PortfolioEnt portfolioEnt)
        {
            return new PortfolioDto()
            {
                Id = portfolioEnt.Id,
                Name = portfolioEnt.Name,
                //UserId = portfolio.UserId,
                Accounts = portfolioEnt.Accounts.Select(e => CreateAccount(e)).ToList()
            };
        }

        public static InvestmentDto CreateInvestment(InvestmentEnt investmentEnt)
        {
            return new InvestmentDto()
            {
                Id = investmentEnt.ID,
                Name = investmentEnt.Name,

                Symbol = investmentEnt.Symbol,

                Type = investmentEnt.Type,
                Class = investmentEnt.Class,
                Income = investmentEnt.Income,
                SubType2 = investmentEnt.SubType2
            };
        }
    }
}