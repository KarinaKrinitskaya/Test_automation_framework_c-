using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomationFramework.Core.Browser
{
    public class ChromeBrowser : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            var service = ChromeDriverService.CreateDefaultService();
            return new ChromeDriver(service, chromeOptions, TimeSpan.FromMinutes(3));
        }
    }
}
