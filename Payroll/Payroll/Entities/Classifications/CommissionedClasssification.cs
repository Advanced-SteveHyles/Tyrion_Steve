using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    class CommissionedClasssification : PaymentClassification
    {

        private static Hashtable SalesReceipts = new Hashtable();

        public readonly decimal CommissionRate;

          public CommissionedClasssification(decimal commissionrate)
        {
            this.CommissionRate = commissionrate;
        }

          public void AddSalesReceipt(DateTime saleDate, SalesReceipt salesReciept)
          {
              SalesReceipts(saleDate) = salesReciept;
          }

          public SalesReceipt GetSalesReceipt(DateTime saleDate)
          {
              return SalesReceipts(saleDate);
          }
    }   
}
