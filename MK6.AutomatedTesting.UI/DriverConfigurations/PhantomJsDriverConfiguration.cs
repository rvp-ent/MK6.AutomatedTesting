namespace MK6.AutomatedTesting.UI
{
    public class PhantomJsDriverConfiguration
        : DriverConfiguration
    {
        public PhantomJsDriverConfiguration(string serverSource)
            : base(DriverType.PhantomJS, serverSource: serverSource)
        { }
    }
}
