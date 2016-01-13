using Interfaces;
using System.Linq;
using Interfaces.BusinessInterfaces;
using BusinessLogic;
using Xunit;

namespace TestSuite
{    
    public class InitialFundamentals
    {

 
        public void NewAccountHasNoTransactions()
        {
            IAccount Account = new Data.Accounts.Account();
            Assert.True(Account.Transactions.Count == 0);                        
        }

        [Fact]
        public void AddingNewTransactions()
        {
            IAccount Account = new Data.Accounts.Account();
            ITransaction Transaction = new Data.Accounts.Transaction();
            IAccountHandler AccountHandler = new AccountHandler(Account);
            AccountHandler.AddTransaction(Transaction);
            Assert.True(Account.Transactions.Count == 1);

            var value = from at in Account.Transactions
                            select at.TransactionValue;

            Assert.True(value.Sum() == 0);

            Transaction = new Data.Accounts.Transaction();
            Transaction.TransactionValue = 50;
            Account.Transactions.Add(Transaction);

            value = from at in Account.Transactions
                    select at.TransactionValue;

            Assert.True(value.Sum() == 50);
        }
    }
}
