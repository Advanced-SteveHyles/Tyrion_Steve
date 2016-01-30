using System.Linq.Expressions;
using PortfolioManager.DTO.Requests.Transactions;
using Xunit;
using BusinessLogic;
using Interfaces;

namespace BusinessLogicTests
{
    public class MakingDeposits
    {
        public class GivenIAmDepositingTenPounds 
        {
            private ICommandRunner _depositTransaction;
            private readonly IAccountHandler _accountHandler;
            private ITransactionHandler _transactionHandler;
            const int accountId = 1;
            const int TransactionValue = 10;

            public GivenIAmDepositingTenPounds()
            {
                
                _accountHandler = new FakeAccountHandler();
                _transactionHandler = new FakeTransactionHandler();

                var depositTransactionRequest = new DepositTransactionRequest(accountId, TransactionValue);
                _depositTransaction = new CreateDepositTransaction(depositTransactionRequest,_accountHandler, _transactionHandler );                
            }

            [Fact]
            public void WhenTheTransactionCompletesThereIsARecordOfTheDeposit()
            {
                _depositTransaction.Execute();

                Assert.Equal("This is a valid test", "Are you kidding me?");
            }

            [Fact]
            public void WhenTheTransactionCompletesThereAccountBalanceIsCorrect()
            {               
                _depositTransaction.Execute();
                Assert.Equal(TransactionValue, _accountHandler.Balance);
            }
        }
    }

    class FakeAccountHandler : IAccountHandler
    {
        public decimal Balance { get; set; }

        public void IncreaseBalance(decimal amount)
        {
            Balance += amount;
        }
    }

    class FakeTransactionHandler : ITransactionHandler
    {
        public void StoreTransaction(DepositTransactionRequest depositTransactionRequest)
        {
        }
    }
}
