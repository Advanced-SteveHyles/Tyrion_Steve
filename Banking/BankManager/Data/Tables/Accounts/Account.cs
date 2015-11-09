using Common.Enums;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Accounts
{
    public class Account : IAccount
    {
      public  Account()
        {
            if (this.Transactions == null)
            {
                this.Transactions = new List<ITransaction>();
            }
        }
        
        public int AccountID{ get; set; }
        public int PortfolioID { get; set; }
        public DateTime OpenedDate { get; set; }
        public string AccountName { get; set; }
        public decimal PredictedBalance { get; set; }
        public decimal ActualBalance { get; set; }

        
        //public int AccountTypeID { get; set; }
        public EnumAccountType AccountType { get; set; }

        public ICollection<ITransaction> Transactions { get; set; }

       
    }
}
