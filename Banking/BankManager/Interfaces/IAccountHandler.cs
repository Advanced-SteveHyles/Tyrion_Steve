using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BusinessInterfaces
{
 public   interface IAccountHandler
    {
     void   UpdateBalances();
     void AddTransaction(  ITransaction Transaction);
    }
}
