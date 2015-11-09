using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public abstract class AddEmployeeTransaction : ITransaction
    {
        private readonly int empid;
        private readonly string name;
        private readonly string address;

        public AddEmployeeTransaction (int empid, string name, string address)
        {
            this.empid = empid;
            this.name = name;
            this.address = address;
        }

        protected abstract PaymentClassification MakeClassification();
        protected abstract PaymentSchedule MakeSchedule();

        public void Execute()
        {
            PaymentClassification pc = MakeClassification();
            PaymentSchedule ps = MakeSchedule();
            PaymentMethod pm = new HoldMethod();

            Employee e = new Employee() { EmpId = empid, Name = name, Address = address };
            e.Classification = pc;
            e.Schedule = ps;
            e.Method = pm;
            PayrollDatabase.AddEmployee(empid, e);

        }
    }
}
