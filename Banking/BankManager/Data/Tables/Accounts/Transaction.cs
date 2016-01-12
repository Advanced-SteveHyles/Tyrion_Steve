using Interfaces;
using System;
using Common.Enums;


namespace Data.Accounts
{
    public class Transaction : ITransaction
    {
        public int TransactionID { get; set; }
        
        //[ForeignKey("AccountId")]
        public EnumTransactionType TransactionType { get; set; }

        public virtual Account Account { get; set; }
        //public virtual Account Account { get; set; }
        public virtual Statement Statement { get; set; }

        public decimal TransactionValue { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime ReconciledDate { get; set; }
        public DateTime StatementedDate { get; set; }
        public bool IsReconciled { get; set; }
    }
}
