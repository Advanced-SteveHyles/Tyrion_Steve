using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITransaction
    {
        DateTime EstimatedDate { get; set; }
        DateTime ReconciledDate { get; set; }
        bool IsReconciled { get; set; }
        DateTime StatementedDate { get; set; }
        decimal TransactionValue { get;set;}
    }
}
