using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class AddSalariedEmployee : AddEmployeeTransaction
    {
        private readonly decimal salary;

        public AddSalariedEmployee(int empid, string name, string address, decimal salary)
            : base(empid, name, address)
        {            
            this.salary = salary;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new SalariedClasssification(salary);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new MonthlySchedule();
        }
    }
}
