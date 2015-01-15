using System;

namespace MK6.AutomatedTesting.UI
{
    public abstract class DriverConfiguration
    {
        public readonly DriverType DriverType;

        public readonly string ServerSource;

        public readonly Uri RemoteUrl;

        public readonly string RemoteBrowser;

        public readonly string RemoteBrowserVersion;

        protected DriverConfiguration(
            DriverType type, 
            string serverSource = "", 
            string remoteUrl = "",
            string remoteBrowser = "",
            string remoteBrowserVersion = "")
        {
            this.DriverType = type;
            this.ServerSource = serverSource;
            this.RemoteUrl = string.IsNullOrEmpty(remoteUrl) ? null : new Uri(remoteUrl);
            this.RemoteBrowser = remoteBrowser;
            this.RemoteBrowserVersion = remoteBrowserVersion;
        }
    }
}
