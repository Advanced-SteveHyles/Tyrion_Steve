namespace DebtsModel.CSVEngines.EventDriven
{
    public class CsvHandlers
    {
        private readonly Bus _bus;
        private readonly ICsvDataSet _csvDataSet;

        public CsvHandlers(Bus bus, ICsvDataSet csvDataSet)
        {
            _bus = bus;
            _csvDataSet = csvDataSet;
        }

        public void Subscribe()
        {
            _bus.Subscribe<Message.ColumnNamed>(AddColumn);
            _bus.Subscribe<Message.RowData>(AddValue);
            _bus.Subscribe<Message.EnteredRow>(EnteredRow);
            _bus.Subscribe<Message.LeftRow>(LeftRow);
            _bus.Subscribe<Message.EnteredSet>(EnteredSet);
            _bus.Subscribe<Message.LeftSet>(LeftSet);
            _bus.Subscribe<Message.NewRow>(NewRow);
            _bus.Subscribe<Message.NewSubset>(NewSubset);
            _bus.Subscribe<Message.NewValuePair>(NewValuePair);
        }

        private void NewRow(Message message)
        {
            _csvDataSet.Log("<NewRow/>");
        }
        private void NewSubset(Message message)
        {
            _csvDataSet.Log("<NewSubset/>");
        }
        private void NewValuePair(Message message)
        {
            _csvDataSet.Log("<NewValuePair/>");
        }

        private void AddValue(Message message)
        {
            Message.RowData obj = message as Message.RowData;
            _csvDataSet.AddValue(obj.Data);
            _csvDataSet.Log("<AddValue>" + obj.Data + "</AddValue>");
        }

        public void AddColumn(Message message)
        {
            Message.ColumnNamed obj = message as Message.ColumnNamed;
            _csvDataSet.AddColumn(obj.Name);
            _csvDataSet.Log("<AddColumn>" + obj.Name + "</AddColumn>");
        }

        public void EnteredRow(Message message)
        {
            Message.EnteredRow obj = message as Message.EnteredRow;
            _csvDataSet.EnteredRow();
            _csvDataSet.Log("<Row>");
        }

        public void LeftRow(Message message)
        {
            Message.LeftRow obj = message as Message.LeftRow;
            _csvDataSet.LeftRow();
            _csvDataSet.Log("</Row>");
        }
        public void EnteredSet(Message message)
        {
            Message.EnteredSet obj = message as Message.EnteredSet;
            _csvDataSet.EnteredSet();
            _csvDataSet.Log("<Set>");
        }
        public void LeftSet(Message message)
        {
            Message.LeftSet obj = message as Message.LeftSet;
            _csvDataSet.LeftSet();
            _csvDataSet.Log("</Set>");
        }
    }
}