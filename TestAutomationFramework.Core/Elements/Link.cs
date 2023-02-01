using OpenQA.Selenium;

namespace TestAutomationFramework.Elements
{
    public class Link : BaseElement
    {
        public string TargetURL { get; private set; }

        public Link(By locator, string targetURL = "") : base(locator)
        {
            TargetURL = targetURL;
        }

        public Link(IWebElement element) : base(element)
        {

        }
    }
}
