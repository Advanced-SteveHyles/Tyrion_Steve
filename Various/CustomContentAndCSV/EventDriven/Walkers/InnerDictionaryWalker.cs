using System.Collections.Generic;

namespace DebtsModel.CSVEngines.EventDriven.Walkers
{
    public class InnerDictionaryWalker : IWalker
    {
        private Dictionary<string, object> _data;
        private readonly Bus _bus;

        public InnerDictionaryWalker(Bus bus)
        {
            _bus = bus;
        }

        public void Walk(object item)
        {
            _data = item as Dictionary<string, object>;
            foreach (var key in _data.Keys)
            {
                _bus.Send(new Message.ColumnNamed(key));
                var itemdata = _data[key];
                IWalker walker = WalkerFactory.GetWalker(_bus, itemdata);
                walker.Walk(itemdata);
            }
        }
    }
}