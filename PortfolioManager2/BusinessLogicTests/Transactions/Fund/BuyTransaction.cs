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

        private void Setup()
        {
            _numberOfShares = 10;
            _priceOfOneShare = 1;
            _commission = 0;
            _valueOfTransaction = 10;
            _transactionDate = DateTime.Now;

            var request = new InvestmentBuyRequest
            {
                MapId = 1,
                Quantity = _numberOfShares,
                Price = _priceOfOneShare,
                PurchaseDate = _transactionDate,
                UpdatePriceHistory = false
            };

            _fakeRepository = new FakeRepository();

            _buyTransaction = new CreateFundBuyTransaction(request);
            
        }

        public GivenIAmBuyingIntoAFund()
        {
            _accountFundMap = new InvestmentMap();            
        }

        [Fact]
        public void WhenIBuyThenTheShareCountIsIncreasedBy10()
        {
            Setup();
            _buyTransaction.Execute();
            Assert.Equal(_numberOfShares, _accountFundMap.Quantity);
        }
        
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

        //public void WhenIBuyThenTheAccountIsReducedBy10Pounds()
        //{
        //    //-10
        //}

        //public void WhenIBuy10SharesAtOnePoundAValuationIsCreatedCorrectly()
        //{
        //    //1, Today's Date
        //}

        //WhereIBuyTheCashWithdrawnIsEqualToTheTransactionCost

    }
}
