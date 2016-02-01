using Interfaces;
using PortfolioManager.Repository;

namespace BusinessLogicTests
{
 public class AccountHandler : IAccountHandler
    {
        private readonly IPortfolioManagerRepository _repository;

        public AccountHandler(IPortfolioManagerRepository repository)
        {
            _repository = repository;            
        }

        public void IncreaseBalance(int accountId, decimal amount)
        {
            _repository.IncreaseAccountBalance(accountId, amount);            
        }
    }
}