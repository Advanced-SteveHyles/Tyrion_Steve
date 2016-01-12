using Interfaces;
using Interfaces.BusinessInterfaces;
using BusinessLogic;
using Factories;
using Common.Enums;
using Xunit;

namespace TestSuite
{
    public class AccountTests
    {
        [Fact]
        public void InitialAccountBalanceMustBeZero()
        {
            IAccount Account = AccountFactory.CreateAccount(EnumAccountType.Test);
            Assert.True(Account.PredictedBalance == 0);                        
        }

        [Fact]
        public void AccountBalanceUpdateBalance()
        {
            IAccount Account = AccountFactory.CreateAccount(EnumAccountType.Test);
            IAccountHandler AccountHandler = new AccountHandler(Account);
            AccountHandler.UpdateBalances();                  
            Assert.True(Account.PredictedBalance == 0);
        }

        [Fact]
        public void AccountBalanceWorks()
        {
            IAccount Account = AccountFactory.CreateAccount(EnumAccountType.Test);
            ITransaction Transaction = new Data.Accounts.Transaction(); 
            IAccountHandler AccountHandler = new AccountHandler(Account);
            Transaction.TransactionValue = 20;
             AccountHandler.AddTransaction( Transaction);         
             AccountHandler.UpdateBalances();                  
            Assert.Equal(Account.PredictedBalance , Transaction.TransactionValue);
        }

        [Fact]
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
            Assert.Equal (Account.PredictedBalance , RunningTotal);
        }

        [Fact]
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
            Assert.True(Account.ActualBalance == RunningTotal);
        }

      

    }
}
