namespace MK6.AutomatedTesting.UI
{
    public class ChromeDriverConfiguration
        : DriverConfiguration
    {
        public ChromeDriverConfiguration(string serverSource)
            : base(DriverType.Chrome, serverSource: serverSource)
        { }
    }
}
