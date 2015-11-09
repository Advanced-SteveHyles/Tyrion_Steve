using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Interfaces
{
 public   interface IDataEntryPortfolioViewModel
    {
     void PortfolioSelected(IPortfolioDTO selectedPortffolio);
    }
}
