using System.Collections.Generic;

namespace Data.Accounts
{
    public class Portfolio
    {
        public int PortfolioID { get; set; }

        public string PortfolioName {get;set;}

        public virtual ICollection<Account> Accounts { get; set; }

    }


}
