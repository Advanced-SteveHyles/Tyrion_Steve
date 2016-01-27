using PortfolioManager.DTO;
using PortfolioManager.Repository.Entities;

namespace PortfolioManager.Repository.Factories
{
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