using System.Collections;

namespace EventSource.Agregates
{
    public interface IHandleCommand<TCommand>
    {
        IEnumerable Handle(TCommand c);
    }
}