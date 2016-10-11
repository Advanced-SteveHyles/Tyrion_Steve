namespace Edument.CQRS
{
    public interface IApplyEvent<TEvent>
    {
        void Apply(TEvent e);
    }
}