using System;
using BusinessLogic.Transactions;
using PortfolioManager.DTO.Transactions;
using Xunit;

namespace BusinessLogicTests.Transactions.Fund
{
    class GivenIamApplyingACorporateAction
    {
        //Summary of action
        //  Reduce the amount of money invested in the fund
        //  For OEIC - this money is returned to the account
        //  For non-OEIC - this money is not returned to the account.

        public void TransactionIsValid()
        {
            var _corporateActionAmount = (decimal)50;
            var _transactionDate = DateTime.Now;
            var _existingInvestmentMapId = 1;

            var request = new CorporateActionRequest
            {
                InvestmentMapId = _existingInvestmentMapId,
                Amount = _corporateActionAmount,
                TransactionDate = _transactionDate
            };

            var transaction = new CorporateActionTransaction(request);


            Assert.True(transaction.CommandValid);
        }

        public void WhenIRecordACorporateActionTheAmountInvestedIsReduced()
        {



        }

        public void WhenIRecordACorporateActionAndTheClassIsOEICTheAmountIsCreditedToTheAccount()
        {

        }

        public void WhenIRecordACorporateActionAndTheClassIsNotOEICTheAmountIsCreditedToTheAccountAndRemoved()
        {

        }
        
        //When the Investment is a OEIC - reduce the invested momey and return it to the account
        //When the Invement is a Trust Fund - reduce the invested money but do not return it to the account.
    }
}

