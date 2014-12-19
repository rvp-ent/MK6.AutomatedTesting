using System.Collections.Generic;

namespace MK6.AutomatedTesting
{
    public interface IReportWriter
    {
        void Write(IEnumerable<IDictionary<string, string>> results);
    }
}
