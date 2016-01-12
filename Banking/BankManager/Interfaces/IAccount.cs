using System.Collections.Generic;

namespace Interfaces
{
   public  interface IAccount
    {
       ICollection<ITransaction> Transactions { get; set; }
       decimal PredictedBalance { get; set; }
       decimal ActualBalance { get; set; }
      
    }
}
