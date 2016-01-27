using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.DTO;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository.Factories
{
 public   class PortfoliioFactory
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

    public class AccountsFactory
    {
        public static Account CreateAccount(AccountDto accountDto)
        {
            return new Account
            {
                Id = accountDto.Id
                //TODO fill in rest of fields
            };
        }
    }
}
