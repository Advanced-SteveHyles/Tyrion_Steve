using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Payroll.Tests
{
    public class TestEmployees
    {
        [Fact]
        [Trait ("Employee", "Adding")]
        public void TestAddSalariedEmployee()
        {
            int empid = 1;

            AddSalariedEmployee t = new AddSalariedEmployee(empid, "Bob", "Home", (decimal) 1000.00);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.Equal("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.True(pc is SalariedClasssification);

            SalariedClasssification sc = pc as SalariedClasssification;

            Assert.Equal<decimal> ((decimal)1000.00,  sc.Salary ) ; //, .001);
            PaymentSchedule ps = e.Schedule;

            PaymentMethod pm = e.Method;
            Assert.True(pm is HoldMethod);
       }
    

    [Fact]
    [Trait("Employee", "Adding")]
    public void TestAddCommissionedEmployee()
    {
        int empid = 1;

        AddCommissionedEmployee t = new AddCommissionedEmployee(empid, "James", "Home", (decimal) 5.49);
        t.Execute();

        Employee e = PayrollDatabase.GetEmployee(empid);
        Assert.Equal("James", e.Name);

        PaymentClassification pc = e.Classification;
        Assert.True(pc is CommissionedClasssification);

        CommissionedClasssification cc = pc as CommissionedClasssification;

        Assert.Equal<decimal>((decimal)5.49, cc.CommissionRate); //, .001);
        PaymentSchedule ps = e.Schedule;

        PaymentMethod pm = e.Method;
        Assert.True(pm is HoldMethod);
    }

    [Fact]
    [Trait("Employee", "Adding")]
    public void TestAddHourlyEmployee()
    {
            int empid = 1;

            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Steve", "Home", (decimal)15.00);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.Equal("Steve", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.True(pc is HourlyClasssification);

            HourlyClasssification hc = pc as HourlyClasssification;

            Assert.Equal<decimal> ((decimal)15,  hc.HourlyRate ) ; //, .001);
            PaymentSchedule ps = e.Schedule;

            PaymentMethod pm = e.Method;
            Assert.True(pm is HoldMethod);
}

    [Fact]
    [Trait("Employee", "Removing")]
    public void TestDeleteEmployess()
    {
        int empid = 1;

        AddHourlyEmployee t = new AddHourlyEmployee(empid, "Steve", "Home", (decimal)15.00);
        t.Execute();

        Employee e = PayrollDatabase.GetEmployee(empid);
        Assert.NotNull(e);
        Assert.Equal("Steve", e.Name);
        

        DeleteEmployee d = new DeleteEmployee(empid);
        d.Execute();

        e = PayrollDatabase.GetEmployee(empid);

        Assert.Null(e);
        
    }
}
}