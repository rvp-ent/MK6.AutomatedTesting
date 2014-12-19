namespace MK6.AutomatedTesting.Load
{
    public abstract class LoadTestingScript : Script
    {
        public ScriptHookDelegate PreScriptHook
        {
            get { return LoadTestScriptHookBindings.PreScriptHook; }
        }

        public abstract Step[] Steps { get; }

        public abstract Step[] FinallySteps { get; }

        public ScriptHookDelegate PostScriptHook
        {
            get { return LoadTestScriptHookBindings.PostScriptHook; }
        }
    }
}
