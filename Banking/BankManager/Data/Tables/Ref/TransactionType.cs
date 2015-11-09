using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Ref
{
    public class TransactionType : ITransactionType
    {
        private TransactionType(){}

        public TransactionType(int transactionTypeID , string typeName)
        {
            this.TransactionTypeID = transactionTypeID;
            this.TypeName = typeName;

        }

       [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
      public int TransactionTypeID { get; set; }
        public string TypeName { get; set; }
    }
}
