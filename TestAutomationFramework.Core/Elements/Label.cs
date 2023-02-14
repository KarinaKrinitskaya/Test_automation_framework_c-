
using OpenQA.Selenium;

namespace TestAutomationFramework.Elements
{
    public class Label : BaseElement
    {
        public Label(By locator) : base(locator)
        {

        }

        public Label(IWebElement element) : base(element)
        {
        }
    }
}
