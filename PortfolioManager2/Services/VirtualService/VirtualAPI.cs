using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioManager.DTO.Requests.Transactions;

namespace VirtualService
{
    public class VirtualAPI
    {

        public IHttpActionResult Post([FromBody] PriceHistoryRequest request)
        {
            
        }
    }
}
