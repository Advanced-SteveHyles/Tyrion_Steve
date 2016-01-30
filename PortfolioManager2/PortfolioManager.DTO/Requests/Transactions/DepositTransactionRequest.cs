using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.DTO.Requests.Transactions
{
   public class DepositTransactionRequest
    {
       public int AccountId { get; }
       public decimal Value { get; }

       public DepositTransactionRequest(int accountID, decimal value )
       {
           AccountId = accountID;
           Value = value;
       }
    }
}
