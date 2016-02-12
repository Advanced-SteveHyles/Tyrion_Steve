using Interfaces;
using PortfolioManager.Repository.Interfaces;

namespace BusinessLogic.Handlers
{
 public class AccountHandler : IAccountHandler
    {
        private readonly IAccountRepository _repository;

        public AccountHandler(IAccountRepository repository)
        {
            _repository = repository;            
        }

        public void IncreaseAccountBalance(int accountId, decimal amount)
        {
            _repository.IncreaseAccountBalance(accountId, amount);            
        }

     public void DecreaseAccountBalance(int accountId, decimal amount)
     {
            _repository.DecreaseAccountBalance(accountId, amount);
        }

     public void UpdateValuation(int accountId, decimal mapValue)
     {
            _repository.IncreaseValuation(accountId, mapValue);
     }
    }
}