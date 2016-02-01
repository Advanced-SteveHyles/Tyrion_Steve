using System;
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
            private readonly ICommandRunner _depositTransaction;
            private readonly FakeRepository _fakeRepository;
            const int AccountId = 1;
            const int TransactionValue = 10;

            public GivenIAmDepositingTenPounds()
            {
                _fakeRepository = new FakeRepository();
                IAccountHandler accountHandler = new AccountHandler(_fakeRepository);
                ITransactionHandler transactionHandler = new TransactionHandler(_fakeRepository);

                var depositTransactionRequest = new DepositTransactionRequest
                {
                    AccountId = AccountId,
                    Value = TransactionValue,
                    Source = "Test",
                    TransactionDate = DateTime.Now
                };              

                _depositTransaction = new CreateDepositTransaction(depositTransactionRequest,accountHandler, transactionHandler );                
            }

            [Fact]
            public void ValidTransactionCanExecute()
            {
                Assert.True(_depositTransaction.CommandValid());

                _depositTransaction.Execute();
                Assert.Equal(TransactionValue, _fakeRepository.AccountBalance);
            }
            
            [Fact]
            public void WhenTheTransactionCompletesThereIsARecordOfTheDeposit()
            {
                _depositTransaction.Execute();

                Assert.True(_fakeRepository.AddCashTransactionWasCalled);
            }

            [Fact]
            public void WhenTheTransactionCompletesThereAccountBalanceIsCorrect()
            {               
                _depositTransaction.Execute();
                Assert.Equal(TransactionValue, _fakeRepository.AccountBalance);
            }
        }
    }
}
