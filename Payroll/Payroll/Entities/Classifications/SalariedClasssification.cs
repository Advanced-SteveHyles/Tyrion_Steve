using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class SalariedClasssification : PaymentClassification
    {
        public readonly decimal Salary;

        public  SalariedClasssification(decimal salary)
        {
            this.Salary = salary;
        }

    }
}
