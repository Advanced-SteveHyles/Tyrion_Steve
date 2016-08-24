using System.Collections.Generic;

namespace DebtsModel.CSVEngines.EventDriven.Walkers
{
    public class TopLevelDictionaryWalker : IWalker
    {
        private Dictionary<string, object> _data;
        private readonly Bus _bus;

        public TopLevelDictionaryWalker(Bus bus)
        {
            _bus = bus;
            _bus.Send(new Message.NewRow());
        }

        public void Walk(object item)
        {
            _data = item as Dictionary<string, object>;
            _bus.Send(new Message.EnteredRow());
            foreach (var key in _data.Keys)
            {
                _bus.Send(new Message.ColumnNamed(key));
                var itemdata = _data[key];
                IWalker walker = WalkerFactory.GetWalker(_bus, itemdata);
                walker.Walk(itemdata);
            }
            _bus.Send(new Message.LeftRow());
        }
    }
}