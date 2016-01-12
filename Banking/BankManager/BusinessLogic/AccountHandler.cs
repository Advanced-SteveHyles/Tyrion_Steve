using Interfaces;
using Interfaces.BusinessInterfaces;
using System.Linq;

namespace BusinessLogic
{
 public   class AccountHandler : IAccountHandler
    {

     IAccount Account;
     public AccountHandler(IAccount account)
     {
         this.Account = account;       
     }
    

     public void UpdateBalances()
     {
         Account.PredictedBalance = Account.Transactions.Select(p => p.TransactionValue).Sum();
         Account.ActualBalance = Account.Transactions.Where(p => p.IsReconciled).Select(p => p.TransactionValue).Sum();
     }

     public void AddTransaction(ITransaction Transaction)
     {
         
         Account.Transactions.Add(Transaction);
             }
    }
}
