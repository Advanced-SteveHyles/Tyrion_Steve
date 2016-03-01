using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualService.VirtualActionResults;
using Xunit;
namespace VirtualServiceTests
{
    public class PortfolioServiceTests
    {
        [Fact]
        public void CallsToPortfolioServiceSucceed()
        {
            var sut = new VirtualService.VirtualControllers.PortfoliosController();
            var portfolios =  sut.Get();
            Assert.IsType<Ok> (portfolios);
        }
    }
}
