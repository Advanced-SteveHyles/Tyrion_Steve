using System.Collections.Generic;
using System.Linq;

namespace DebtsModel.CSVEngines.EventDriven
{
    public class CsvDataRow : Dictionary<string, object>
    {
        public override string ToString()
        {
            return string.Join(",", this.Values.Select(value => Csvify(value.ToString())).ToList());
        }
        private string Csvify(string s)
        {
            return "\"" + s.Replace("\"", "\\\"") + "\"";
        }

        public CsvDataRow Merge(CsvDataRow priorRow)
        {
            var returnValue = new CsvDataRow();
            foreach (var key in priorRow.Keys.Except(this.Keys))
            {
                returnValue.Add(key,priorRow[key]);
            }
            foreach (var key in this.Keys)
            {
                returnValue.Add(key, this[key]);
            }
            return returnValue;
        }
    }
}