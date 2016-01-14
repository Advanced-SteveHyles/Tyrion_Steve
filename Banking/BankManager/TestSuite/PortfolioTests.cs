using System.ComponentModel.DataAnnotations;
using System.Linq;
using Data.Accounts;
using Xunit;

namespace Data.Tests
{
    [Xunit.Collection("RawDataBase")]
    public class PortfolioTests
    {
        //Ultimate goal - read Portfolio data from Database
        [Fact(DisplayName = "DB:BasicRead", Skip = "DatabaseBruteTest")]
        [Trait("Database", "Brute")]
        //[Fact(DisplayName = "DB:BasicRead")]
        public void ReadPortfolio()
        {
            var x = new PortfolioManagerContext();

            var qry = x.Portfolios.Select(p => p.PortfolioName);

            Assert.Equal(qry.Count(), 3);
            Assert.NotEmpty(qry.ToList());
        }

        [Fact(DisplayName = "DB:PortfolioCreate")]
        [Trait("Database", "Brute")]
        public void CreatePortfolio()
        {
            var x = new PortfolioManagerContext();

            var portfolio = new Portfolio();
            var portfolioName = "Steves";
            portfolio.PortfolioName = portfolioName;

            x.Portfolios.Add(portfolio);

            var qry = x.Portfolios.Select(p => p.PortfolioName);
            Assert.Equal(1, qry.Count());
            Assert.NotEmpty(qry.ToList());
            Assert.Equal(portfolioName, qry.First());
        }
    }
}
