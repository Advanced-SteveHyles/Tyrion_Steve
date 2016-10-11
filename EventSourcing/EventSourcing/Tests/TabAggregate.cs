using System.Collections;
using Edument.CQRS;
using EventSource.Agregates;
using EventSource.Events;

namespace Tests
{
    public class TabAggregate : Aggregate, IHandleCommand<OpenTab>
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

        public IEnumerable Handle(object command)
        {
            throw new System.NotImplementedException();
        }
    }
}