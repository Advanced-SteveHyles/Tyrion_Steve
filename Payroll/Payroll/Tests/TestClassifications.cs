using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Payroll.Tests
{
    public class TestClassifications
    {
        [Fact]
        [Trait ("Classifications", "Hourly")]
        public void TestTimeCardTransaction()
        {
            int empid =5;
            AddHourlyEmployee he = new AddHourlyEmployee(empid, "Bill", "Home", (decimal) 1.25);
            he.Execute();

            TimecardTransaction tct = new TimecardTransaction(new DateTime(2015,5,18), (decimal)8.0,  empid);
            tct.Execute();

            Employee e =PayrollDatabase.GetEmployee(empid);
        Assert.NotNull(e);

            PaymentClassification pc = e.Classification;
        Assert.True(pc is HourlyClasssification);
        HourlyClasssification hc  = pc as HourlyClasssification ;

        TimeCard tc = hc.GetTimeCard(new DateTime(2015,7,31));
        Assert.NotNull (tc);
        Assert.Equal (8, tc.Hours);

        }

        [Fact]
        [Trait("Classifications", "Sales Receipts")]
        public void TestSalesReceiptTransaction()
        {
            int empid = 12;
            AddCommissionedEmployee ce = new AddCommissionedEmployee(empid, "Billy", "Home", (Decimal)5000);
            ce.Execute();

            SalesReceiptTransaction srt = new SalesReceiptTransaction(new DateTime(2015, 5, 18), (decimal)800.0, empid);
            srt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.NotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.True(pc is CommissionedClasssification);
            CommissionedClasssification cc = pc as CommissionedClasssification;

            SalesReceipt sr = cc.GetSalesReceipt(new DateTime(2015, 7, 31));
            Assert.NotNull(sr);
            Assert.Equal(800, sr.SalesValue);
        }

    }
}