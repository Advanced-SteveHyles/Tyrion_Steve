using System;
using System.Collections.Generic;

namespace DebtsModel.CSVEngines.EventDriven.Walkers
{
    public class ArrayWalker : IWalker
    {
        private readonly Bus _bus;
        private object[] _data;

        public ArrayWalker(Bus bus)
        {
            _bus = bus;
            _bus.Send(new Message.NewSubset());
        }

        public void Walk(object item)
        {
            _data = item as object[];
            _bus.Send(new Message.EnteredSet());
            foreach (var value in _data)
            {
                if (value is Dictionary<string,object>)
                {
                    var dw = new TopLevelDictionaryWalker(_bus);
                    dw.Walk(value);
                }
            }
            _bus.Send(new Message.LeftSet());
        }
    }
}