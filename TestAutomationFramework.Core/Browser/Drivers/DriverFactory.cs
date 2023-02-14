using TestAutomationFramework.Enums;
using OpenQA.Selenium;

namespace TestAutomationFramework.Core.Browser
{
    public static class DriverFactory
    {
        public static IWebDriver GetWebDriver(BrowserType browser)
        {
            IWebDriver createdWebDriver;
            switch (browser)
            {
                case BrowserType.Chrome:
                    createdWebDriver = new ChromeBrowser().GetDriver();
                    break;
                case BrowserType.Firefox:
                    createdWebDriver = new FirefoxBrowser().GetDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser));
            }

            return createdWebDriver;
        }
    }
}
