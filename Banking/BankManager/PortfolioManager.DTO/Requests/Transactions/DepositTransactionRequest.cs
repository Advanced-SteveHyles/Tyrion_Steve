using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.DTO.Requests.Transactions
{
   public class DepositTransactionRequest
    {
       private readonly int _accountId;
       private readonly decimal _value;

       public DepositTransactionRequest(int accountID, decimal value )
       {
           _accountId = accountID;
           _value = value;
       }
    }
}
