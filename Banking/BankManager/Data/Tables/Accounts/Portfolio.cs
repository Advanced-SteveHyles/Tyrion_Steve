using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Accounts
{
    public class Portfolio
    {
        public int PortfolioID { get; set; }

        public string PortfolioName {get;set;}

        public virtual ICollection<Account> Accounts { get; set; }

    }


}
