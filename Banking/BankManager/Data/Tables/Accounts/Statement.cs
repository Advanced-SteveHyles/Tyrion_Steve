using System;

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
