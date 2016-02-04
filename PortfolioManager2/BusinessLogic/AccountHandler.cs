using Interfaces;
using PortfolioManager.Repository;

namespace BusinessLogicTests
{
 public class AccountHandler : IAccountHandler
    {
        private readonly IAccountRepository _repository;

        public AccountHandler(IAccountRepository repository)
        {
            _repository = repository;            
        }

        public void IncreaseBalance(int accountId, decimal amount)
        {
            _repository.IncreaseAccountBalance(accountId, amount);            
        }

     public void DecreaseBalance(int accountId, decimal amount)
     {
            _repository.DecreaseAccountBalance(accountId, amount);
        }
    }
}