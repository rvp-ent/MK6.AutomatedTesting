using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MK6.AutomatedTesting.UI
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindUntilVisible(this IWebDriver browser, By by, TimeSpan timeout)
        {
            var wait = new WebDriverWait(browser, timeout);
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static bool TryFindUntilVisible(this IWebDriver browser, By by, TimeSpan timeout, out IWebElement element)
        {
            try
            {
                element = FindUntilVisible(browser, by, timeout);
                return true;
            }
            catch(NoSuchElementException)
            {
                element = null;
                return false;
            }
        }
    }
}
