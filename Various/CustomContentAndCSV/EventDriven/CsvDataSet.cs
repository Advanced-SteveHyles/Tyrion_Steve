using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtsModel.CSVEngines.EventDriven
{
    public class CsvDataSet : ICsvDataSet
    {
        private readonly Stack<string> _breadcrumbs;
        private readonly List<string> _columnSet;

        private CsvDataRow _currentRow;
        private List<CsvDataRow> _currentRows;
        private readonly Stack<CsvDataRow> _liveRows;
        private readonly List<CsvDataRow> _data;

        private readonly StringBuilder _log;

        public CsvDataSet()
        {
            _breadcrumbs = new Stack<string>();
            _columnSet = new List<string>();

            _currentRow = new CsvDataRow();
            _currentRows = new List<CsvDataRow>();
            _liveRows = new Stack<CsvDataRow>();
            _data = new List<CsvDataRow>();

            _log = new StringBuilder();
        }

        public IEnumerable<string> Titles => FinalisedData().LastOrDefault()?.Keys;

        public void Log(string message)
        {
            _log.AppendLine(message);
        }

        public string PrintLog()
        {
            return _log.ToString();
        }

        private string WorkingColumn { get; set; }

        public void AddColumn(string name)
        {
            WorkingColumn = name;
            _columnSet.Add(WorkingColumn);
        }

        public void AddValue(object o)
        {
            _currentRow[WorkingColumn] = o.ToString();
        }

        public List<CsvDataRow> FinalisedData() => _data;

        public void LeftRow()
        {
            var shouldAddRange = _liveRows.Count == 1 && _liveRows.Peek().Keys.Count == 0;
            if (_currentRow.Keys.Count > 0)
            {
                _currentRows.Add(_currentRow);
                _currentRow = new CsvDataRow();
            }

            if (shouldAddRange)
            {
                _data.AddRange(_currentRows);
                _currentRows = new List<CsvDataRow>();
            }
            
        }

        public void EnteredRow()
        {
            _currentRow = new CsvDataRow();
        }

        public void EnteredSet()
        {
            PushToBreadcrumb();
            PushRowToLiveRows();
        }

        private void PushToBreadcrumb()
        {
            _breadcrumbs.Push(WorkingColumn);
        }
        private void PushRowToLiveRows()
        {
            _liveRows.Push(_currentRow);
            _currentRow = new CsvDataRow();
        }

        public void LeftSet()
        {
            PopFromBreadcrumbs();
            MergeLiveRowsWithCurrentRows();
        }

        private void PopFromBreadcrumbs()
        {
            WorkingColumn = _breadcrumbs.Pop();
        }
        private void MergeLiveRowsWithCurrentRows()
        {
            if (_liveRows.Count > 0)
            {
                var backfillrow = _liveRows.Pop();
                _currentRows = _currentRows.Select(row => row.Merge(backfillrow)).ToList();
            }
        }

        public ICsvDataSet Flush()
        {
            _data.AddRange(_currentRows);
            return this as ICsvDataSet;
        }
        private static string Csvify(string s) => "\"" + s.Replace("\"", "\\\"") + "\"";

        public override string ToString()
        {
            if (this.Titles == null) return "No data returned";

            var s = new StringBuilder();
            s.AppendLine(string.Join(",", this.Titles.Select(i => Csvify(i))));

            this.FinalisedData().ForEach(row => s.AppendLine(row.ToString()));
            return s.ToString();
        }
    }
}