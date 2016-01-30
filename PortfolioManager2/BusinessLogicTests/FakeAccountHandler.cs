using Interfaces;

namespace BusinessLogicTests
{
    class FakeAccountHandler : IAccountHandler
    {
        public decimal Balance { get; set; }

        public void IncreaseBalance(decimal amount)
        {
            Balance += amount;
        }
    }
}