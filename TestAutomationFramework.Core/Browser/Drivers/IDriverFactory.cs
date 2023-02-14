using OpenQA.Selenium;

namespace TestAutomationFramework.Core.Browser
{
    public interface IDriverFactory
    {
        public IWebDriver GetDriver();
    }
}
