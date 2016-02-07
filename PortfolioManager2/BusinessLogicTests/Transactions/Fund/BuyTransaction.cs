using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.Repository.Entities;
using Xunit;

namespace BusinessLogicTests.Transactions.Fund
{
    public class GivenIAmBuyingIntoAFund
    {
        private readonly InvestmentMap accountFundMap;
        private decimal _numberOfShares;
        private decimal _priceOfOneShare;
        private decimal _commission;
        private decimal _valueOfTransaction;
        private void Setup()
        {
            _numberOfShares = 10;
            _priceOfOneShare = 1;
            _commission = 0;
            _valueOfTransaction = 10;
        }

        public GivenIAmBuyingIntoAFund()
        {
            accountFundMap = new InvestmentMap();
        }

        [Fact]
        public void WhenIBuyThenTheShareCountIsIncreasedBy10()
        {
            Setup();
            Assert.Equal(_numberOfShares, accountFundMap.Quantity);
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
    }
}
