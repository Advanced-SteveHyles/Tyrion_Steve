namespace Interfaces.BusinessInterfaces
{
 public   interface IAccountHandler
    {
     void   UpdateBalances();
     void AddTransaction(  ITransaction Transaction);
    }
}
