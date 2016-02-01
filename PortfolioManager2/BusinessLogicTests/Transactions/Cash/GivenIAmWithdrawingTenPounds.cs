using System;
using BusinessLogic.Transactions;
using Interfaces;
using Xunit;
using PortfolioManager.DTO.Requests.Transactions;

namespace BusinessLogicTests
{
    public class GivenIAmWithdrawingTenPounds
    {
        private readonly ICommandRunner _withdrawalTransaction;
        private readonly FakeRepository _fakeRepository;
        const int AccountId = 1;
        const int TransactionValue = 10;

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
            Assert.True(_withdrawalTransaction.CommandValid());

            _withdrawalTransaction.Execute();
            Assert.Equal(-TransactionValue, _fakeRepository.AccountBalance);
        }

        [Fact]
        public void WhenTheTransactionCompletesThereIsARecordOfTheDeposit()
        {
            _withdrawalTransaction.Execute();

            Assert.True(_fakeRepository.AddCashTransactionWasCalled);
        }

        [Fact]
        public void WhenTheTransactionCompletesThereAccountBalanceIsCorrect()
        {
            _withdrawalTransaction.Execute();
            Assert.Equal(-TransactionValue, _fakeRepository.AccountBalance);
        }
    }
}