using OpenQA.Selenium;
using System;

namespace MK6.AutomatedTesting.UI.Components
{
    public abstract class PageElement
    {
        protected readonly Func<IWebElement> _elementRetriever;

        public PageElement(IWebDriver browser, By findBy)
        {
            this._elementRetriever = () => browser.FindElement(findBy);
        }

        protected IWebElement Element
        {
            get
            {
                return this._elementRetriever.Invoke();
            }
        }

        public bool IsVisible
        {
            get
            {
                return this.Element.Displayed;
            }
        }
    }
}
