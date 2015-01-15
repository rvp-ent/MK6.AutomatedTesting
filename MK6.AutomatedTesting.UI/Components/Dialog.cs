using OpenQA.Selenium;

namespace MK6.AutomatedTesting.UI.Components
{
    public class Dialog : PageElement
    {
        public Dialog(IWebDriver browser, By findBy)
            : base(browser, findBy)
        {
        }
    }
}
