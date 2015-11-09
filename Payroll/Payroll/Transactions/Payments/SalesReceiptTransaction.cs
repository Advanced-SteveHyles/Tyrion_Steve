using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class SalesReceiptTransaction : ITransaction
    {
        private readonly DateTime date;
        private readonly decimal salesvalue;
        private readonly int empid;

        public SalesReceiptTransaction(DateTime saleDate, decimal salesValue, int empid)
            {
                this.date = saleDate;
                this.salesvalue = salesValue;
            this.empid = empid;
        }

       public void Execute()
       {
           Employee e = PayrollDatabase.GetEmployee(empid);

           if (e != null)
           {
               CommissionedClasssification cc = e.Classification as CommissionedClasssification;

               if (cc != null)
               {
                   cc.AddSalesReceipt(new SalesReceipt(date, salesvalue));
               }
               else
               {
                   throw new InvalidOperationException("Tried to add sales receipt to commissioned employee.");
               }
           }
           else
           {
               throw new InvalidOperationException("No such employee.");
           }
       }     
    }
}
