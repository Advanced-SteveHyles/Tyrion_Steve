using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces;
using System.Linq;
using Interfaces.BusinessInterfaces;
using BusinessLogic;
namespace TestSuite
{
    [TestClass]
    public class InitialFundamentals
    {


        [TestMethod]
        public void NewAccountHasNoTransactions()
        {
            IAccount Account = new Data.Accounts.Account();
            Assert.IsTrue(Account.Transactions.Count == 0);                        
        }

        [TestMethod]
        public void AddingNewTransactions()
        {
            IAccount Account = new Data.Accounts.Account();
            ITransaction Transaction = new Data.Accounts.Transaction();
            IAccountHandler AccountHandler = new AccountHandler(Account);
            AccountHandler.AddTransaction(Transaction);
            Assert.IsTrue(Account.Transactions.Count == 1);

            var value = from at in Account.Transactions
                            select at.TransactionValue;

            Assert.IsTrue(value.Sum() == 0);

            Transaction = new Data.Accounts.Transaction();
            Transaction.TransactionValue = 50;
            Account.Transactions.Add(Transaction);

            value = from at in Account.Transactions
                    select at.TransactionValue;

            Assert.IsTrue(value.Sum() == 50);
        }



//#region "Simple Validators"
//        private void ValidateNewAccount(IAccount Account)
//        {
//            //Assert.IsTrue (Account)
//        }

//#endregion


    }
}
