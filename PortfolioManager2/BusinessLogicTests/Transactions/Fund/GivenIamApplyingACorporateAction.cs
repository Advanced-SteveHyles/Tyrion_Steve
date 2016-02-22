using System;
using BusinessLogic;
using BusinessLogic.Transactions;
using PortfolioManager.Constants.TransactionTypes;
using PortfolioManager.DTO.Transactions;
using Xunit;

namespace BusinessLogicTests.Transactions.Fund
{
    public class GivenIamApplyingACorporateAction
    {
        private CorporateActionTransaction _transaction;
        private FakeRepository _fakeRepository;
        decimal _corporateActionAmount = (decimal)50;
        DateTime _transactionDate = DateTime.Now;
        int _existingInvestmentMapId = 1;
        private FundTransactionHandler _fundTransactionHandler;
        private int _accountId = 1;
        //Summary of action
        //  Reduce the amount of money invested in the fund
        //  For OEIC - this money is returned to the account
        //  For non-OEIC - this money is not returned to the account.

        private void SetupAndOrExecute(bool execute)
        {

            _fakeRepository = new FakeRepository();
            var request = new CorporateActionRequest
            {
                InvestmentMapId = _existingInvestmentMapId,
                Amount = _corporateActionAmount,
                TransactionDate = _transactionDate
            };

            _fundTransactionHandler = new FundTransactionHandler(_fakeRepository);
            _transaction = new CorporateActionTransaction(request, _fundTransactionHandler);

            if (execute) _transaction.Execute();
        }

        [Fact]
        public void TransactionIsValid()
        {
            SetupAndOrExecute(false);
            Assert.True(_transaction.CommandValid);
        }


        [Fact]
        public void WhenIRecordACorporateActionThenAFundTransactionIsRecorded()
        {
            SetupAndOrExecute(true);

            var arbitaryId = 1;
            var fundTransaction = _fakeRepository.GetFundTransaction(arbitaryId);

            Assert.Equal(_existingInvestmentMapId, fundTransaction.InvestmentMapId);
            Assert.Equal(_transactionDate, fundTransaction.TransactionDate);
            Assert.Equal("Corporate Action", fundTransaction.TransactionType);
            Assert.Equal(_corporateActionAmount, fundTransaction.TransactionValue);
            Assert.Equal(0, fundTransaction.Quantity);
        }

        [Fact]
        public void WhenIRecordACorporateActionForAnOEICACashTransactionIsCreated()
        {
            SetupAndOrExecute(true);

            var cashTransactionId = -1;
            var transaction = _fakeRepository.GetCashTransaction(cashTransactionId);
            Assert.Equal(_accountId, transaction.AccountId);
            Assert.Equal(_transactionDate, transaction.TransactionDate);
            Assert.Equal(_corporateActionAmount, transaction.TransactionValue);
            Assert.Equal(string.Empty, transaction.Source);
            Assert.Equal(false, transaction.IsTaxRefund);
            Assert.Equal(CashTransactionTypes.CorporateAction, transaction.TransactionType);
        }
    }

    //    public void WhenIRecordACorporateActionAndTheClassIsOEICTheAmountIsCreditedToTheAccount()
    //{

    //}

    //        public void WhenIRecordACorporateActionAndTheClassIsNotOEICTheAmountIsCreditedToTheAccountAndRemoved()
    //        {

    //        }

    //When the Investment is a OEIC - reduce the invested momey and return it to the account
    //When the Invement is a Trust Fund - reduce the invested money but do not return it to the account.
}


