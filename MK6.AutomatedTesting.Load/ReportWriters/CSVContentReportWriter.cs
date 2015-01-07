using System;
using System.Collections.Generic;
using System.IO;

namespace MK6.AutomatedTesting.Load.ReportWriters
{
    public class CSVContentReportWriter : IReportWriter
    {
        private readonly string _outputFile;

        public CSVContentReportWriter(IDictionary<string, object> environment)
        {
            var fileName = string.Format(
                "{0}-Results.csv",
                ((DateTime)environment[EnvironmentKeys.StartTime]).ToString("yyyyMMddHHmmss"));
            this._outputFile = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        }

        public void Write(IEnumerable<IDictionary<string, string>> results)
        {
            using (var output = new StreamWriter(this._outputFile))
            {
                WriteSummary(output, results);
            }
        }

        private static void WriteSummary(StreamWriter output, IEnumerable<IDictionary<string, string>> results)
        {
            var fields = new List<Tuple<string, Func<IDictionary<string, string>, string>>> {
                new Tuple<string, Func<IDictionary<string, string>, string>>("StartTime", r => r["StartTime"]),
                new Tuple<string, Func<IDictionary<string, string>, string>>("EndTime", r => r["EndTime"]),
                new Tuple<string, Func<IDictionary<string, string>, string>>("WorkerIndex", r => r["WorkerIndex"]),
                new Tuple<string, Func<IDictionary<string, string>, string>>("Iteration", r => r["IterationIndex"]),
                new Tuple<string, Func<IDictionary<string, string>, string>>("Desription", r => r["Description"]),
                new Tuple<string, Func<IDictionary<string, string>, string>>("RequestUrl", r => r["RequestUrl"]),
                new Tuple<string, Func<IDictionary<string, string>, string>>("Status", r => r["StatusCode"]),
                new Tuple<string, Func<IDictionary<string, string>, string>>("ResponseTime", r => r["ResponseTime"]),
                new Tuple<string, Func<IDictionary<string, string>, string>>("Content", r => r["Content"])
            };

            foreach (var field in fields)
            {
                output.Write(field.Item1 + ",");
            }

            output.WriteLine();

            foreach (var result in results)
            {
                foreach (var field in fields)
                {
                    var value = default(string);

                    try
                    {
                        value = Escape(field.Item2(result));
                    }
                    catch
                    {
                        value = string.Empty;
                    }

                    output.Write(@"""" + value + @""",");
                }

                output.WriteLine();
            }
        }

        private static string Escape(string s)
        {
            return s
                .Replace(Environment.NewLine, string.Empty)
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty)
                .Replace("\"", "\"\"");
        }
    }
}
