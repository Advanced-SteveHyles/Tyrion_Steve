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

       public DateTime TransactionDate { get; }
        
       public decimal Value { get; }

       public string Source { get; }

       public DepositTransactionRequest(int accountID, decimal value, DateTime transactionDate, string source)
       {
           AccountId = accountID;
           Value = value;
           TransactionDate = transactionDate;
           Source = source;
       }
    }
}
