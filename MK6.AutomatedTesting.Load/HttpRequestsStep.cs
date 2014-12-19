using MK6.AutomatedTesting.Load.Requests;
using System.Collections.Generic;
using System.Linq;

namespace MK6.AutomatedTesting.Load
{
    public class HttpRequestsStep : Step
    {
        public readonly IEnumerable<Request> Requests;

        public HttpRequestsStep(params Request[] requests)
        {
            this.Requests = requests ?? Enumerable.Empty<Request>();
        }

        public override RunStepDelegate Runner
        {
            get
            {
                return HttpRequestsStepRunner.Run;
            }
        }
    }
}
