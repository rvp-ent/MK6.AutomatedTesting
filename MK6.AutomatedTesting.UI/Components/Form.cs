using OpenQA.Selenium;

namespace MK6.AutomatedTesting.UI.Components
{
    public class Form : PageElement
    {
        public Form(IWebDriver browser, By findBy)
            : base(browser, findBy)
        { }

        public void Submit()
        {
            this.Element.Submit();
        }
    }
}
