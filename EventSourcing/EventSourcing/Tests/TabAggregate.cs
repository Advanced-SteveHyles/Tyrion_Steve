using System.Collections;
using Edument.CQRS;
using EventSource;
using EventSource.Agregates;
using EventSource.Events;
using EventSource.Exceptions;

namespace Tests
{
    public class TabAggregate : Aggregate, 
        IHandleCommand<OpenTab>,
        IHandleCommand<PlaceOrder>
    {
        public IEnumerable Handle(OpenTab c)
        {
            yield return new TabOpened
            {
                Id = c.Id,
                TableNumber = c.TableNumber,
                Waiter = c.Waiter
            };
        }

        public IEnumerable Handle(PlaceOrder c)
        {
           throw new TabNotOpen();
        }

    }
}