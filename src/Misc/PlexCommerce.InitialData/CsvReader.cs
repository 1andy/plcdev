using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace PlexCommerce
{
    public static class CsvReader
    {
        public static IEnumerable<object> ReadCsv(Stream stream)
        {
            var parser = new TextFieldParser(stream)
                         {
                             TextFieldType = FieldType.Delimited,
                             Delimiters = new[] { "," },
                             HasFieldsEnclosedInQuotes = true,
                             TrimWhiteSpace = true
                         };

            string[] fields = parser.ReadFields();

            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                var data = (IDictionary<string, object>)new ExpandoObject();

                for (int i = 0; i < fields.Length; i++)
                {
                    data[fields[i]] = row[i];
                }

                yield return data;
            }
        }
    }
}