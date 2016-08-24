namespace DebtsModel.CSVEngines.EventDriven.Walkers
{
    public class ItemWalker : IWalker
    {
        private readonly Bus _bus;

        public ItemWalker(Bus bus)
        {
            _bus = bus;
            _bus.Send(new Message.NewValuePair());
        }

        public void Walk(object item)
        {
            _bus.Send(new Message.RowData(item?.ToString() ?? string.Empty));
        }
    }
}