using MK6.AutomatedTesting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MK6.AutomatedTesting
{
    public class IterationContext
    {
        public readonly int WorkerIndex;

        public readonly int IterationIndex;

        public readonly Script Script;

        public readonly IDictionary<string, object> Environment;

        public readonly CancellationToken CancellationToken;

        public IterationContext(WorkerContext workerContext, int iterationIndex)
        {
            this.IterationIndex = iterationIndex;
            this.Environment = new Dictionary<string, object>(workerContext.Environment);

            this.Script = workerContext.Script;
            this.WorkerIndex = workerContext.WorkerIndex;
            this.CancellationToken = workerContext.CancellationToken;
        }
    }
}
