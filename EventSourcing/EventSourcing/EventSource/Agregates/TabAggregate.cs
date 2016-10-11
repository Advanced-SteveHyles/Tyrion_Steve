using System.Collections;
using Edument.CQRS;
using EventSource.Events;

namespace EventSource.Agregates
{
    public class TabAggregate : Aggregate//, IHandleCommand<OpenTab>
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
    }
}