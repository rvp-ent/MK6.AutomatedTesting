using OpenQA.Selenium;

namespace MK6.AutomatedTesting.UI.Components
{
    public class TextBox : PageElement
    {
        public TextBox(IWebDriver browser, By findBy)
            : base(browser, findBy)
        {
        }

        public string Text
        {
            get
            {
                return this.Element.Text;
            }
            set
            {
                this.Element.SendKeys(value);
            }
        }
    }
}
