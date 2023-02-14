using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestAutomationFramework.Core.Browser
{
    public class FirefoxBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--start-maximized");
            var service = FirefoxDriverService.CreateDefaultService();
            return new FirefoxDriver(service, firefoxOptions, TimeSpan.FromMinutes(3));
        }
    }
}
