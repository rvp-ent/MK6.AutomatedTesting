using MK6.AutomatedTesting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MK6.AutomatedTesting
{
    public class WorkerContext
    {
        public readonly int WorkerIndex;

        public readonly Script Script;

        public readonly IDictionary<string, object> Environment;

        public readonly IList<IDictionary<string, string>> Results;

        public readonly CancellationToken CancellationToken;

        public WorkerContext(
            ScriptContext scriptContext,
            int workerIndex)
        {
            this.WorkerIndex = workerIndex;
            this.Environment = new Dictionary<string, object>(scriptContext.Environment);
            this.Results = new List<IDictionary<string, string>>();

            this.CancellationToken = scriptContext.CancellationToken;
            this.Script = scriptContext.Script;
        }
    }
}
