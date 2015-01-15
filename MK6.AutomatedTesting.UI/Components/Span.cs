using OpenQA.Selenium;

namespace MK6.AutomatedTesting.UI.Components
{
    public class Span : PageElement
    {
        public Span(IWebDriver browser, By findBy) : base(browser, findBy)
        {
        }

        public string Text
        {
            get { return Element.Text; }
        }
    }
}
