namespace MK6.AutomatedTesting
{
    public delegate void ScriptHookDelegate(IterationContext context);

    public interface Script
    {
        ScriptHookDelegate PreScriptHook { get; }

        Step[] Steps { get; }

        Step[] FinallySteps { get; }

        ScriptHookDelegate PostScriptHook { get; }
    }
}
