using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResharperOnly;
using Xunit;
namespace Tests
{
    public class GivenWeAreTestingTheCountingEngine
    {
        public class WhenISupplyAllParameters
        {
            [Fact]
            public void ThenTheCountingEngineRuns()
            {
                var countingEngine = new CountingEngine();

                try
                {
                    countingEngine.Invoke();
                    /*Assert.ThrowsAny<Exception>(() => countingEngine.Invoke());*/
                }
                catch (Exception)
                {
                    Assert.Equal(1,0);
                }
                
            }
        }
    }
}
