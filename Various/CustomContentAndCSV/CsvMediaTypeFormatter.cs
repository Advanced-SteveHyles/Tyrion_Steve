using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using DebtsModel.CSVEngines.EventDriven;

namespace DebtsPortalApi
{
    public class CsvMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public CsvMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        
        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            var parser = new Parser(new Bus(), new CsvDataSet());
            var queryResult = (GraphQL.ExecutionResult)value;
            var data = parser.Parse(queryResult.Data as Dictionary<string, object>);

            using (var writer = new StreamWriter(writeStream))
            {
                //  WriteItem(writer, Convert.ToBase64String(Encoding.UTF8.GetBytes(data.ToString())));                
                writer.Write(data.ToString());
            }
        }
    }
}