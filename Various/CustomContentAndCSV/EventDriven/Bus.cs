using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtsModel.CSVEngines.EventDriven
{
    public class Bus
    {
        private Dictionary<Type, List<Action<Message>>> _bus;

        public Bus(Bus ctx)
        {
            _bus = ctx._bus;
        }
        public Bus()
        {
            _bus = new Dictionary<Type, List<Action<Message>>>();
        }

        public void Subscribe<T>(Action<Message> handler) where T : Message
        {
            if (_bus.ContainsKey(typeof(T)))
            {
                _bus[typeof(T)].Add(handler);
            }
            else
            {
                _bus.Add(typeof(T), new List<Action<Message>>() { handler });
            }
        }
        public void Send(Message message)
        {
            var subscriptions = _bus.Single(kvp => kvp.Key == message.GetType());
            subscriptions.Value.ForEach(action => action(message));
        }
    }
}