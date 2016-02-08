using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Transactions;
using Interfaces;
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
        private IAccountHandler _accountHandler;
        private int _accountId;
        private ITransactionHandler _transactionHandler;
        private IInvestmentMapHandler _investmentMapHandler;
        private const int ArbitaryId =1 ;

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
                InvestmentMapId = 1,
                Quantity = _numberOfShares,
                Price = _priceOfOneShare,
                PurchaseDate = _transactionDate,
                UpdatePriceHistory = false,
                Value = _valueOfTransaction
            };

            _fakeRepository = new FakeRepository();
            _accountHandler = new AccountHandler(_fakeRepository);
            _transactionHandler = new TransactionHandler(_fakeRepository);
            _investmentMapHandler = new InvestmentMapHandler(_fakeRepository);
            _buyTransaction = new CreateFundBuyTransaction(
                _accountId, request, _accountHandler,
                _transactionHandler, _investmentMapHandler);

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
            var account = _fakeRepository.GetAccount(ArbitaryId);
            Assert.Equal(-_valueOfTransaction, account.Cash);
        }

        [Fact]
        public void WhenIBuyThenTheAccountHasARecordOfTheWithdrawal()
        {
            Setup();
            _buyTransaction.Execute();
            Assert.True(_fakeRepository.ApplyCashTransactionWasCalled);
        }

        [Fact]
        public void WhenIBuyThenTheShareCountIsIncreased()
        {
            Setup();
            _buyTransaction.Execute();

            var accountFundMap = _fakeRepository.GetInvestmentMap(1);
            Assert.Equal(_numberOfShares, accountFundMap.Quantity);
        }

        //[Fact]
        //public void WhenIBuyThenTheValuationIsCorrect()
        //{
        //    Setup();
        //    _buyTransaction.Execute();

        //    var accountFundMap = _fakeRepository.GetInvestmentMap(1);
        //    Assert.Equal(_numberOfShares, accountFundMap.Quantity);
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
