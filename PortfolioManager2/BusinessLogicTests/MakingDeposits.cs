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
            const int transactionValue = 10;

            public GivenIAmDepositingTenPounds()
            {
                
                _accountHandler = new FakeAccountHandler();
                _transactionHandler = new FakeTransactionHandler();

                var depositTransactionRequest = new DepositTransactionRequest
                {
                    AccountId = accountId,
                    Value = transactionValue
                };              

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
                Assert.Equal(transactionValue, _accountHandler.Balance);
            }
        }
    }
}
