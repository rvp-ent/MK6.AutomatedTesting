namespace MK6.AutomatedTesting.UI
{
    public class RemoteDriverConfiguration
        : DriverConfiguration
    {
        public RemoteDriverConfiguration(string remoteUrl, string remoteBrowser, string remoteBrowserVersion)
            : base(DriverType.Remote, remoteUrl: remoteUrl, remoteBrowser: remoteBrowser, remoteBrowserVersion: remoteBrowser)
        { }
    }
}
