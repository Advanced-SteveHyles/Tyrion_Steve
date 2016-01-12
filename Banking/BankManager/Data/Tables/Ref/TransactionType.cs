using Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
