using OpenQA.Selenium;

namespace MK6.AutomatedTesting.UI.Components
{
    public class Button : PageElement
    {
        public Button(IWebDriver browser, By findBy)
            : base(browser, findBy)
        { }

        public void Click()
        {
            this.Element.Click();
        }
    }
}
