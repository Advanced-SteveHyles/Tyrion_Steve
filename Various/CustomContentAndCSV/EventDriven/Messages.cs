namespace DebtsModel.CSVEngines.EventDriven
{
    public abstract class Message
    {
        public class ColumnNamed : Message
        {
            public ColumnNamed(string name) { Name = name; }
            public string Name { get; } 
        }

        public class RowData : Message
        {
            public RowData(object data) { Data = data; }
            public object Data { get; }
        }
        public class EnteredRow : Message { }
        public class LeftRow : Message { }
        public class EnteredSet : Message { }
        public class LeftSet : Message { }

        public class NewValuePair: Message { }
        public class NewRow : Message { }
        public class NewSubset : Message { }


    }
}