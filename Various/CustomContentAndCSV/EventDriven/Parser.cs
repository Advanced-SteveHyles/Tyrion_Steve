using System.Collections.Generic;
using DebtsModel.CSVEngines.EventDriven.Walkers;

namespace DebtsModel.CSVEngines.EventDriven
{
    public class Parser
    {
        readonly Bus _bus;
        readonly ICsvDataSet _csvDataSet;

        public Parser(Bus bus, ICsvDataSet dataSet)
        {
            this._bus = bus;
            this._csvDataSet = dataSet;
        }


        public ICsvDataSet Parse(Dictionary<string, object> data)
        {
            var csvHandlers = new CsvHandlers(_bus, _csvDataSet);
            csvHandlers.Subscribe();
            var walker = new TopLevelDictionaryWalker(_bus);
            walker.Walk(data);

            return _csvDataSet.Flush();
        }
    }
    
}