
using OpenQA.Selenium;

namespace TestAutomationFramework.Elements
{
    public class Dropdown : BaseElement
    {
        public Dropdown(By locator) : base(locator)
        {

        }

        public Dropdown(IWebElement element) : base(element)
        {
        }
    }
}
