using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Common;
namespace Data.Tests
{
    [Xunit.Collection("RawDataBase")]
    public class PortfolioTests
    {
        //Ultimate goal - read Portfolio data from Database
       [Fact(DisplayName = "DB:BasicRead", Skip = "DatabaseBruteTest")]
       [Trait("Database", "Brute")]
       //[Fact(DisplayName = "DB:BasicRead")]
        public   void ReadPortfolio ()
        {
            var x = new PortfolioManagerContext();

            var qry = x.Portfolios.Select(p => p.PortfolioName);

            Assert.Equal(qry.Count(), 3);
           Assert.NotEmpty(qry.ToList());
        }
    }
}
