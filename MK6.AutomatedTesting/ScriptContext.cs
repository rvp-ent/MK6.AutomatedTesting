using MK6.AutomatedTesting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MK6.AutomatedTesting
{
    public class ScriptContext
    {
        public readonly Script Script;

        public readonly IDictionary<string, object> Environment;

        public readonly CancellationToken CancellationToken;

        public ScriptContext(Script script, IDictionary<string, object> environment)
        {
            this.Script = script;
            this.CancellationToken = (environment[EnvironmentKeys.CancellationTokenSource] as CancellationTokenSource).Token;
            this.Environment = environment;
        }
    }
}
