using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MK6.AutomatedTesting.UI
{
    public static class DataTableLoader
    {
        public static DataTable LoadTabDelimited(IEnumerable<string> lines)
        {
            var data = new DataTable();

            if(lines == null || !lines.Any())
            {
                return data;
            }

            var headers = lines.First().Split('\t').Select(h => h.Trim());
            foreach (var header in headers)
            {
                data.Columns.Add(header);
            }

            var records = lines.Skip(1);

            foreach (var record in records)
            {
                data.Rows.Add(record.Split('\t').Select(r => r.Trim()).ToArray());
            }

            return data;
        }
    }
}
