using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;

namespace MK6.AutomatedTesting.UI
{
    public static class DriverFactory
    {
        public static IWebDriver Build(DriverConfiguration config)
        {
            switch (config.DriverType)
            {
                case DriverType.Firefox:
                    return new FirefoxDriver();
                case DriverType.Chrome:
                    CopyChromeDriverServerToLocalDirectory(config.ServerSource);
                    return new ChromeDriver();
                case DriverType.InternetExplorer:
                    CopyIEDriverServerToLocalDirectory(config.ServerSource);
                    return new InternetExplorerDriver(
                        Directory.GetCurrentDirectory(),
                        new InternetExplorerOptions
                        {
                            IgnoreZoomLevel = true
                        });
                case DriverType.PhantomJS:
                    CopyPhantomJSServerToLocalDirectory(config.ServerSource);
                    var browser = new PhantomJSDriver();
                    ApplyPhantomJSHack(browser);
                    return browser;
                case DriverType.Remote:
                    return new RemoteWebDriver(
                        config.RemoteUrl,
                        new DesiredCapabilities(new Dictionary<string, object> 
                        { 
                            { "browser", config.RemoteBrowser }, 
                            { "version", config.RemoteBrowserVersion } 
                        }));
                default:
                    throw new ApplicationException(
                        string.Format(
                            "Unable to create a driver of type {0}",
                            config.DriverType.ToString()));
            }
        }

        private static void ApplyPhantomJSHack(IWebDriver browser)
        {
            browser.Manage().Window.Maximize();
        }

        private static void CopyChromeDriverServerToLocalDirectory(string serverSource)
        {
            CopyFileLocally(
                serverSource,
                "chromedriver.exe");
        }

        private static void CopyIEDriverServerToLocalDirectory(string serverSource)
        {
            CopyFileLocally(
                serverSource,
                "IEDriverServer.exe");
        }

        private static void CopyPhantomJSServerToLocalDirectory(string serverSource)
        {
            CopyFileLocally(
                serverSource,
                "phantomjs.exe");
        }

        private static void CopyFileLocally(
            string sourceDirectory,
            string filename)
        {
            MoveFileLocallyIfNeeded(
                Path.Combine(sourceDirectory, filename),
                Path.Combine(Directory.GetCurrentDirectory(), filename));
        }

        private static void MoveFileLocallyIfNeeded(
            string sourceFile,
            string destinationFile)
        {
            if (!File.Exists(destinationFile))
            {
                File.Copy(sourceFile, destinationFile);
            }
        }
    }
}
