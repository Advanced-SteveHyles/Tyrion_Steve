using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    class AddHourlyEmployee :   AddEmployeeTransaction
    {
        private readonly decimal HourlyRate;

        public AddHourlyEmployee(int empid, string name, string address, decimal hourlyRate)
            : base(empid, name, address)
        {
            this.HourlyRate = hourlyRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new HourlyClasssification(HourlyRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new MonthlySchedule();
        }
    }
}
