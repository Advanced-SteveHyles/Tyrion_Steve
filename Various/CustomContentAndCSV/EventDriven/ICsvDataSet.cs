using System.Collections.Generic;

namespace DebtsModel.CSVEngines.EventDriven
{
    public interface ICsvDataSet
    {
        IEnumerable<string> Titles { get; }
        void Log(string message);
        string PrintLog();
        void AddColumn(string name);
        void AddValue(object o);
        List<CsvDataRow> FinalisedData();
        void LeftRow();
        void EnteredRow();
        void EnteredSet();
        void LeftSet();
        ICsvDataSet Flush();
    }
}