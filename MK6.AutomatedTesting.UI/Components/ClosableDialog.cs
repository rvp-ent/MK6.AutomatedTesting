using OpenQA.Selenium;

namespace MK6.AutomatedTesting.UI.Components
{
    public class ClosableDialog : Dialog
    {
        public readonly Button CloseButton;

        public ClosableDialog(IWebDriver browser, By findBy, By findCloseButtonBy)
            : base(browser, findBy)
        {
                this.CloseButton = new Button(browser, findCloseButtonBy);
        }
    }
}
