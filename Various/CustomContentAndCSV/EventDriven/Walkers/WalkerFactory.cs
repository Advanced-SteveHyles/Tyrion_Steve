using System.Collections.Generic;

namespace DebtsModel.CSVEngines.EventDriven.Walkers
{
    public static class WalkerFactory
    {
        public static IWalker GetWalker(Bus bus, object value)
        {
            if (value is Dictionary<string,object>)
                return new InnerDictionaryWalker(bus);

            if (value is object[])
                return new ArrayWalker(bus);

            return new ItemWalker(bus);
        }
    }
}