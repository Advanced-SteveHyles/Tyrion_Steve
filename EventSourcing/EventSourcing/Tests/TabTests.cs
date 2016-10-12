using System;
using System.Collections.Generic;
using Edument.CQRS;
using EventSource;
using EventSource.Agregates;
using EventSource.Edument.CQRS;
using EventSource.Events;
using EventSource.Exceptions;
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
                }))
            ;
        }

        [Fact]
        public void CanNotOrderWithUnopenedTab()
        {
            var testDrink1 = new OrderedItem
            {
                Description = "Drink 1",
                IsDrink = true,
                MenuNumber = 2,
                Price = (decimal)2.50
            };
            Test(
                Given(),
                When(new PlaceOrder
                {
                    Id = testId,
                    Items = new List<OrderedItem> { testDrink1 }
                }),
                ThenFailWith<TabNotOpen>());
        }
    }
}

