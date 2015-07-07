using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MokkingStuff;
using Moq;
using Xunit;

namespace TestLibrary
{
    public class GivenIAmTestingAFourPhaseEngine
    {
        public class WhenISupplyAllFourPhases
        {
            [Fact]
            public void ThenEachUniquePhaseIsRunOnceOnly()
            {
                var mockPhase1 = new Mock<ICommand>();
                var mockPhase2 = new Mock<ICommand>();
                var mockPhase3 = new Mock<ICommand>();
                var mockPhase4 = new Mock<ICommand>();

                var fourPhaseEngine = new FourPhaseEngine();

                fourPhaseEngine
                        .SetPhase1(mockPhase1.Object)
                            .SetPhase2(mockPhase2.Object)
                                .SetPhase3(mockPhase3.Object)
                                    .SetPhase4(mockPhase4.Object);

                fourPhaseEngine.PerformRun();

                mockPhase1.Verify(f => f.Execute(), Times.AtMostOnce);
                mockPhase2.Verify(f => f.Execute(), Times.AtMostOnce);
                mockPhase3.Verify(f => f.Execute(), Times.AtMostOnce);
                mockPhase4.Verify(f=>f.Execute(), Times.AtMostOnce);
                                
            }

            [Fact]
            public void ThenAPhaseRunsFourTimesIfSuppliesToEachPhase()
            {
                var mockPhase1 = new Mock<ICommand>();
                
                var fourPhaseEngine = new FourPhaseEngine();

                fourPhaseEngine
                        .SetPhase1(mockPhase1.Object)
                            .SetPhase2(mockPhase1.Object)
                                .SetPhase3(mockPhase1.Object)
                                    .SetPhase4(mockPhase1.Object);

                fourPhaseEngine.PerformRun();

                mockPhase1.Verify(f => f.Execute(), Times.Exactly(4));                
                
            }
        }
    }
}
