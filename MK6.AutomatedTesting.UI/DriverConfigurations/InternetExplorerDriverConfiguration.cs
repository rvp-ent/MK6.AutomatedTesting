namespace MK6.AutomatedTesting.UI
{
    public class InternetExplorerConfiguration
        : DriverConfiguration
    {
        public InternetExplorerConfiguration(string serverSource)
            : base(DriverType.InternetExplorer, serverSource: serverSource)
        { }
    }
}
