using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EventSource.Agregates;
using EventSource.Edument.CQRS;
using EventSource.Events;
using Xunit;

namespace Tests
{
    public class TabTests : BDDTest<TabAggregate>
    {
        private Guid testId;
        private int testTable;
        private string testWaiter;

        public TabTests()
        {
            testId = Guid.NewGuid();
            testTable = 42;
            testWaiter = "Derek";
        }

        [Fact]
        public void CanOpenANewTab()
        {
            Test(
                Given(),
                When (new OpenTab
                    {
                        Id = testId,
                        TableNumber = testTable,
                        Waiter = testWaiter
                    }),
                Then(new TabOpened
            {
                Id = testId,
                TableNumber = testTable,
                Waiter = testWaiter
            }))
            ;
        }
    }
}

