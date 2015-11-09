using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class AddCommissionedEmployee : AddEmployeeTransaction
    {
          private readonly decimal hourlyrate;

          public AddCommissionedEmployee(int empid, string name, string address, decimal salary)
            : base(empid, name, address)
        {
            this.hourlyrate = salary;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new CommissionedClasssification(hourlyrate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new MonthlySchedule();
        }
    }
}
