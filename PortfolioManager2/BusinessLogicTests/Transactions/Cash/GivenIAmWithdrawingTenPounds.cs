using System;
using BusinessLogic;
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
        private readonly ITransactionHandler _transactionHandler;
        const int AccountId = 1;
        const int TransactionValue = 10;
        const int ArbitaryId = 1;
        DateTime transactionDate = DateTime.Now;
        const string Source = "Test";

        public GivenIAmWithdrawingTenPounds()
        {
            _fakeRepository = new FakeRepository();
            IAccountHandler accountHandler = new AccountHandler(_fakeRepository);
            _transactionHandler = new CashTransactionHandler(_fakeRepository);


            
            var withdrawalTransactionRequest = new WithdrawalTransactionRequest()
            {
                AccountId = AccountId,
                Value = TransactionValue,
                Source = Source,
                TransactionDate = transactionDate,                
            };

            _withdrawalTransaction = new  CreateWithdrawalTransaction(withdrawalTransactionRequest, accountHandler, _transactionHandler);
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
            const bool isTaxRefund = false;

            _withdrawalTransaction.Execute();

            var transaction = _fakeRepository.GetCashTransaction(ArbitaryId);
            
            Assert.Equal(AccountId, transaction.AccountId);
            Assert.Equal(transactionDate, transaction.TransactionDate);
            Assert.Equal(TransactionValue, transaction.TransactionValue);
            Assert.Equal(Source, transaction.Source);
            
            Assert.Equal(isTaxRefund, transaction.IsTaxRefund);
            Assert.Equal("Withdrawal", transaction.TransactionType);
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