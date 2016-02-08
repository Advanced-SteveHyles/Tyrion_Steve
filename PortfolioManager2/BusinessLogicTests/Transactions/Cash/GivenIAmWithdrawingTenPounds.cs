using System;
using BusinessLogic.Transactions;
using Interfaces;
using PortfolioManager.DTO.Requests.Transactions;
using Xunit;

namespace BusinessLogicTests.Transactions.Cash
{
    public class GivenIAmWithdrawingTenPounds
    {
        private readonly ICommandRunner _withdrawalTransaction;
        private readonly FakeRepository _fakeRepository;
        const int AccountId = 1;
        const int TransactionValue = 10;
        const int ArbitaryId = 1;

        public GivenIAmWithdrawingTenPounds()
        {
            _fakeRepository = new FakeRepository();
            IAccountHandler accountHandler = new AccountHandler(_fakeRepository);
            ITransactionHandler transactionHandler = new TransactionHandler(_fakeRepository);

            var withdrawalTransactionRequest = new WithdrawalTransactionRequest()
            {
                AccountId = AccountId,
                Value = TransactionValue,
                Source = "Test",
                TransactionDate = DateTime.Now
            };

            _withdrawalTransaction = new  CreateWithdrawalTransaction(withdrawalTransactionRequest, accountHandler, transactionHandler);
        }

        [Fact]
        public void ValidTransactionCanExecute()
        {
            Assert.True(_withdrawalTransaction.CommandValid);

            _withdrawalTransaction.Execute();
            var account = _fakeRepository.GetAccount(ArbitaryId);            
            Assert.Equal(-TransactionValue, account.Cash);
        }
        

        [Fact]
        public void WhenTheTransactionCompletesThereIsARecordOfTheDeposit()
        {
            _withdrawalTransaction.Execute();

            Assert.True(_fakeRepository.ApplyCashTransactionWasCalled);
        }

        [Fact]
        public void WhenTheTransactionCompletesThereAccountBalanceIsCorrect()
        {
            _withdrawalTransaction.Execute();
            var account = _fakeRepository.GetAccount(ArbitaryId);
            Assert.Equal(-TransactionValue, account.Cash);
        }
    }
}