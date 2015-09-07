using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IOC;
using Moq;
using Xunit;

namespace IOCTests
{
    public class GivenIWantToUseTheEngine
    {
        public class Dunno
        {

            [Fact]
            void InvokeEngineUsingParams()
            {
                var mokParameters = new Mock<IParameters>();
                var mokStarter = new Mock<IStarter>();
                var mokTerminator = new Mock<ITerminator>();
                var mokReporter = new Mock<IReporter>();
                var mokCleaner = new Mock<ICleaner>();

                var engine = new IOC.Driver(mokParameters.Object, mokStarter.Object, mokReporter.Object, mokTerminator.Object, mokCleaner.Object);
                engine.Invoke();

            }

            [Fact]
            void InvokeEngineUsingContainer()
            {
                var mokContainer = new Mock<Autofac.IContainer>();
                mokContainer.SetupGet<IParameters>(f=>f.).Returns(
                {
                    new Mock<IParameters>().Object;                    
                }
            );
            )

                var engine = new IOC.Driver(mokContainer.Object);
                engine.Invoke();
            }

        }
    }
}
