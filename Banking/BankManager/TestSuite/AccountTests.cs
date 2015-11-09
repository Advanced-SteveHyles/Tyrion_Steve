using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces;
using Interfaces.BusinessInterfaces;
using BusinessLogic;
using Factories;
using Common.Enums;

namespace TestSuite
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void AccountBalanceMustBeZero()
        {
            IAccount Account = AccountFactory.CreateAccount(EnumAccountType.Test);
            Assert.IsTrue(Account.PredictedBalance == 0);                        
        }

        [TestMethod]
        public void AccountBalanceUpdateBalance()
        {
            IAccount Account = AccountFactory.CreateAccount(EnumAccountType.Test);
            IAccountHandler AccountHandler = new AccountHandler(Account);
            AccountHandler.UpdateBalances();                  
            Assert.IsTrue(Account.PredictedBalance == 0);
        }

        [TestMethod]
        public void AccountBalanceWorks()
        {
            IAccount Account = AccountFactory.CreateAccount(EnumAccountType.Test);
            ITransaction Transaction = new Data.Accounts.Transaction(); 
            IAccountHandler AccountHandler = new AccountHandler(Account);
            Transaction.TransactionValue = 20;
             AccountHandler.AddTransaction( Transaction);         
             AccountHandler.UpdateBalances();                  
            Assert.AreEqual(Account.PredictedBalance , Transaction.TransactionValue);
        }

        [TestMethod]
        public void PredicatedBalanceIncludesAllTransactions()
        {
            IAccount Account = AccountFactory.CreateAccount(EnumAccountType.Test);
            ITransaction Transaction = new Data.Accounts.Transaction(); 
            IAccountHandler AccountHandler = new AccountHandler(Account);

            decimal RunningTotal;

            Transaction.TransactionValue = 20;
            RunningTotal = Transaction.TransactionValue;
           // Account.Transactions.Add(Transaction);
            AccountHandler.AddTransaction(Transaction);

            Transaction = new Data.Accounts.Transaction(); 
            Transaction.IsReconciled = false ;
            Transaction.TransactionValue = 30;
            RunningTotal += Transaction.TransactionValue;
            AccountHandler.AddTransaction(Transaction);

            Transaction = new Data.Accounts.Transaction(); 
            Transaction.TransactionValue = 20;
            Transaction.IsReconciled = true;
            RunningTotal += Transaction.TransactionValue;
            AccountHandler.AddTransaction(Transaction);

          
            AccountHandler.UpdateBalances();                  
            Assert.AreEqual (Account.PredictedBalance , RunningTotal);
        }

        [TestMethod]
        public void ActualBalanceIncludesReconciledTransactions()
        {
            IAccount Account = AccountFactory.CreateAccount(EnumAccountType.Test);
            ITransaction Transaction = new Data.Accounts.Transaction();
            Transaction.TransactionValue = 20;
            decimal RunningTotal = Transaction.TransactionValue;
            Transaction.IsReconciled = true;
            Account.Transactions.Add(Transaction);

            IAccountHandler AccountHandler = new AccountHandler(Account);
             AccountHandler.UpdateBalances();                  
            Assert.IsTrue(Account.ActualBalance == RunningTotal);
        }

      

    }
}
