using OpenQA.Selenium;

namespace TestAutomationFramework.Elements
{
    public class BasePanel : BaseElement
    {
        public BasePanel(By locator) : base(locator)
        {

        }

        public BasePanel(IWebElement element) : base(element)
        {

        }
    }
}
