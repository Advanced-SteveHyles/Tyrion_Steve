using Interfaces;
using Interfaces.BusinessInterfaces;
using BusinessLogic;
using Factories;
using Common.Enums;
using Data.Accounts;
using Xunit;

namespace TestSuite
{
    public class AccountTests
    {
        private readonly IAccount _account;
        private IAccountHandler _accountHandler;

        public AccountTests()
        {
            _account = AccountFactory.CreateAccount(EnumAccountType.Test);
            _accountHandler = new AccountHandler(_account);
        }


        [Fact]
        public void InitialAccountBalanceMustBeZero()
        {            
            Assert.True(_account.PredictedBalance == 0);                        
        }
        
        [Fact]
        public void PredictedAccountBalanceIsSumOfAllTransactions()
        {
            decimal amount = 20;
            AddTransaction(false, amount);
            var runningTotal = amount;

            amount = 30;
            AddTransaction(false, amount);
            runningTotal += amount;

            amount = 20;
            AddTransaction(true, amount);
            runningTotal += amount;
            
            _accountHandler.UpdateBalances();                  
            Assert.Equal (_account.PredictedBalance , runningTotal);
        }

        private void AddTransaction(bool isReconciled, decimal transactionValue)
        {            
            ITransaction transaction = new Data.Accounts.Transaction();
            transaction.TransactionValue = transactionValue;
            transaction.IsReconciled = isReconciled;
            
            _accountHandler.AddTransaction(transaction);
            
        }

        [Fact]
        public void ActualBalanceExcludesUnReconciledTransactions()
        {            
            AddTransaction(false, 20);
            
            AddTransaction(false, 30);
                        
            AddTransaction(true, 20);
            var runningTotal = 20;

            _accountHandler.UpdateBalances();                  
            Assert.Equal(runningTotal, _account.ActualBalance);
        }

      

    }
}
