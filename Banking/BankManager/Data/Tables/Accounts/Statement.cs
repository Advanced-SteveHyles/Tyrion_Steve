using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Accounts
{
    public class Statement
    {
        public int ID { get; set; }
        public DateTime StatementDate { get; set; }

        public int AccountId { get; set; }
          
//IQueryable<Transaction> Transactions;
                 
    }
}
