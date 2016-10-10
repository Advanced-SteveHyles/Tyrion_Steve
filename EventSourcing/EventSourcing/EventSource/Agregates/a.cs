using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSource.Events;

namespace EventSource.Agregates
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
    }

    public class OpenTab
    {
        public Guid Id { get; set; }
        public int TableNumber { get; set; }
        public string Waiter { get; set; }
    }

    public interface IHandleCommand<T>
    {
    }
}
