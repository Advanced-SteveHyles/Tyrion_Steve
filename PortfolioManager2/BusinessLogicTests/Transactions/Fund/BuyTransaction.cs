using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Transactions;
using PortfolioManager.DTO.Transactions;
using PortfolioManager.Repository.Entities;
using Xunit;

namespace BusinessLogicTests.Transactions.Fund
{
    public class GivenIAmBuyingIntoAFund
    {
        private readonly InvestmentMap _accountFundMap;
        private decimal _numberOfShares;
        private decimal _priceOfOneShare;
        private decimal _commission;
        private decimal _valueOfTransaction;
        private DateTime _transactionDate;
        private FakeRepository _fakeRepository;
        private CreateFundBuyTransaction _buyTransaction;
        private AccountHandler _accountHandler;
        private int _accountId;

        private void Setup()
        {
            _numberOfShares = 10;
            _priceOfOneShare = 1;
            _commission = 2;
            _valueOfTransaction = (_numberOfShares * _priceOfOneShare) + _commission;
            _transactionDate = DateTime.Now;
            _accountId = 10;

            var request = new InvestmentBuyRequest
            {
                MapId = 1,
                Quantity = _numberOfShares,
                Price = _priceOfOneShare,
                PurchaseDate = _transactionDate,
                UpdatePriceHistory = false,
                Value = _valueOfTransaction
            };

            _fakeRepository = new FakeRepository();
            _accountHandler = new AccountHandler(_fakeRepository);

            _buyTransaction = new CreateFundBuyTransaction(_accountId, request, _accountHandler);
            
        }

        public GivenIAmBuyingIntoAFund()
        {
            _accountFundMap = new InvestmentMap();            
        }

        [Fact]
        public void WhenIBuyTransactionIsValid()
        {
            Setup();
            Assert.True(_buyTransaction.CommandValid);            
}

        [Fact]
        public void WhenIBuyThenTheAccountValueIsReduced()
        {
            Setup();
            _buyTransaction.Execute();
            Assert.Equal(-_valueOfTransaction, _fakeRepository.AccountBalance);
        }

        [Fact]
        public void WhenIBuyThenTheAccountHasARecordOfTheWithdrawal()
        {
            Setup();
            _buyTransaction.Execute();
            Assert.True(_fakeRepository.ApplyCashTransactionWasCalled);
        }

        //[Fact]
        //public void WhenIBuyThenTheShareCountIsIncreasedBy10()
        //{
        //    Setup();
        //    _buyTransaction.Execute();
        //    Assert.Equal(_numberOfShares, _accountFundMap.Quantity);
        //}

        //public void WhenIBuyThenTheShareTransactionIsValuedCorrectly()
        //{
        //    //10 =20
        //}

        //public void WhenIBuyThenTheBuyTransactionIsValuedCorrectly()
        //{
        //    //10 =20
        //}

        //public void WhenIBuyThenTheBuyTransactionIsValuedCorrectly()
        //{
        //    //10 =20
        //}

        //public void WhenIBuyThenTheCommissionIsRecordedAsZero()
        //{
        //    //0
        //}

        //public void WhenIBuy10SharesAtOnePoundAValuationIsCreatedCorrectly()
        //{
        //    //1, Today's Date
        //}

        //WhereIBuyTheCashWithdrawnIsEqualToTheTransactionCost

    }
}
