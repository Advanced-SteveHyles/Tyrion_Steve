using System;
using Edument.CQRS;
using EventSource.Agregates;
using EventSource.Events;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TabTests2 : BDDTest<TabAggregate>
    {
        private Guid testId;
        private int testTable;
        private string testWaiter;

        [SetUp]
        public void Setup()
        {
            testId = Guid.NewGuid();
            testTable = 42;
            testWaiter = "Derek";
        }

        [Test]
        public void CanOpenANewTab()
        {
            Test(
                Given(),
                When(new OpenTab
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
                }));
        }
    }
}