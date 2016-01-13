using Interfaces;
using Interfaces.BusinessInterfaces;
using System.Linq;

namespace BusinessLogic
{
 public   class AccountHandler : IAccountHandler
    {
     readonly IAccount _account;
     public AccountHandler(IAccount account)
     {
         this._account = account;       
     }
    

     public void UpdateBalances()
     {
         _account.PredictedBalance = _account.Transactions.Select(p => p.TransactionValue).Sum();
         _account.ActualBalance = _account.Transactions.Where(p => p.IsReconciled).Select(p => p.TransactionValue).Sum();
     }

     public void AddTransaction(ITransaction transaction)
     {         
         _account.Transactions.Add(transaction);
             }
    }
}
