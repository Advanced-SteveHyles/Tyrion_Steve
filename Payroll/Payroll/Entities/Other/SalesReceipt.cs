using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class SalesReceipt
    {
        private readonly DateTime date;
        private readonly decimal salesvalue;

        public SalesReceipt (DateTime date, decimal salesValue)
        {
            this.date = date;
            this.salesvalue = salesValue;
        }

        public decimal SalesValue { get { return salesvalue; } }
        public DateTime Date { get { return date; } }
    }
}
