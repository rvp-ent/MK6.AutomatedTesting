using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MK6.AutomatedTesting.UI.Components
{
    public class Button : PageElement
    {
        private readonly IWebDriver _browser;

        public Button(IWebDriver browser, By findBy)
            : base(browser, findBy)
        {
            _browser = browser;
        }

        public void Click()
        {
            Click(TimeSpan.FromSeconds(5));
        }

        public void Click(TimeSpan timeout)
        {
            var wait = new WebDriverWait(_browser, timeout);
            wait.Until(driver =>
            {
                try
                {
                    Element.Click();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
