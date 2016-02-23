using System;
using System.Linq;
using BusinessLogic;
using BusinessLogic.Handlers;
using BusinessLogic.Transactions;
using Interfaces;
using PortfolioManager.Constants.TransactionTypes;
using PortfolioManager.DTO.Transactions;
using Xunit;

namespace BusinessLogicTests.Transactions.Fund
{
    public class GivenIamApplyingACorporateAction
    {
        private readonly FakeRepository _fakeRepository;
        private CorporateActionTransaction _transaction;
        private IFundTransactionProcessor _fundTransactionProcessor;
        private ICashTransactionProcessor _cashTransactionProcessor;
        private IAccountInvestmentMapProcessor _accountInvestmentMapProcessor ;
        private IInvestmentProcessor _investmentProcessor;

        private readonly int _accountId = 1;
        readonly decimal _corporateActionAmount = (decimal)50;
        readonly DateTime _transactionDate = DateTime.Now;
        readonly int _existingInvestmentMapId = 1;

        public GivenIamApplyingACorporateAction()
        {
            _fakeRepository = new FakeRepository();
        }
        private void SetupAndOrExecute(bool execute)
        {
            var request = new CorporateActionRequest
            {
                InvestmentMapId = _existingInvestmentMapId,
                Amount = _corporateActionAmount,
                TransactionDate = _transactionDate
            };

            _fundTransactionProcessor = new FundTransactionProcessor(_fakeRepository);
            _cashTransactionProcessor = new CashTransactionProcessor(_fakeRepository);
            _accountInvestmentMapProcessor = new AccountInvestmentMapProcessor(_fakeRepository);
            _investmentProcessor  = new InvestmentProcessor(_fakeRepository);

            _transaction = new CorporateActionTransaction(
                request, 
                _fundTransactionProcessor, 
                _cashTransactionProcessor,
                _accountInvestmentMapProcessor,
                _investmentProcessor
                );
            
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
            _fakeRepository.SetInvestmentClass(_existingInvestmentMapId, PortfolioManager.Constants.Funds.FundClasses.Oeic);
            SetupAndOrExecute(true);

            const int cashTransactionId = 1;
            var transaction = _fakeRepository.GetCashTransaction(cashTransactionId);
            Assert.Equal(_accountId, transaction.AccountId);
            Assert.Equal(_transactionDate, transaction.TransactionDate);
            Assert.Equal(_corporateActionAmount, transaction.TransactionValue);
            Assert.Equal(string.Empty, transaction.Source);
            Assert.Equal(false, transaction.IsTaxRefund);
            Assert.Equal(CashTransactionTypes.CorporateAction, transaction.TransactionType);

            Assert.Equal(1, _fakeRepository.GetCashTransactionsForAccount(_accountId).Count());

        }

        [Fact]
        public void WhenIRecordACorporateActionForATrustFundCashTransactionIsNotCreated()
        {
            _fakeRepository.SetInvestmentClass(_existingInvestmentMapId, PortfolioManager.Constants.Funds.FundClasses.Trustfund);
            SetupAndOrExecute(true);
            Assert.Equal(0, _fakeRepository.GetCashTransactionsForAccount(_accountId).Count());
        }

    }    
}


