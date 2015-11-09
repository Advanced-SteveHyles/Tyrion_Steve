using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public  interface IAccount
    {
       ICollection<ITransaction> Transactions { get; set; }
       decimal PredictedBalance { get; set; }
       decimal ActualBalance { get; set; }
      
    }
}
