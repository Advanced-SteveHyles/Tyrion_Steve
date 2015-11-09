using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class HourlyClasssification : PaymentClassification
    {
          public readonly decimal HourlyRate;

          public HourlyClasssification(decimal HourlyRate)
        {
            this.HourlyRate = HourlyRate;
        }

          internal void AddTimeCard(TimeCard timeCard)
          {
              throw new NotImplementedException();
          }

          internal TimeCard GetTimeCard(DateTime dateTime)
          {
              throw new NotImplementedException();
          }
    }
}
