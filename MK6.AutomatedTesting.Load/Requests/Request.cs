using System.Collections.Generic;
using System.Net.Http;

namespace MK6.AutomatedTesting.Load.Requests
{
    public abstract class Request
    {
        public readonly string Description;

        public Request()
            : this(string.Empty)
        { }

        public Request(string description)
        {
            this.Description = description ?? string.Empty;
        }

        public abstract HttpRequestMessage GetHttpRequest(IterationContext context);

        public virtual IDictionary<string, object> ExtractContentToEnvironment(
            IterationContext context, 
            IDictionary<string, string> result)
        {
            return new Dictionary<string, object>();
        }
    }
}
