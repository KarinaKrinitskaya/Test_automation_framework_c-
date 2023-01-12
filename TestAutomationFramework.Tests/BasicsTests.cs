using TestAutomationFramework.TestData;
using TestAutomationFramework.Web.PageObjects.Pages;

namespace TestAutomationFramework.Tests
{
    public class BasicsTests : BaseTest
    {
        [Test]
        public void CheckNavigationEpamSite()
        {
            mainPage.Load();
            Assert.That(BrowserFactory.Browser.Url, Is.EqualTo(PageURLs.Main), "Incorrect url is present");
        }

        [Test]
        public void CheckBackPreviousPage()
        {
            howWeDoItPage.Load();
            ourWorkPage.Load();
            BrowserFactory.Browser.Refresh();
            BrowserFactory.Browser.Back();
            BrowserFactory.Browser.WaitForPageLoad();
            Assert.That(BrowserFactory.Browser.Url, Is.EqualTo(PageURLs.HowWeDoIt), "Page is not How to do it!");
        }
    }
}