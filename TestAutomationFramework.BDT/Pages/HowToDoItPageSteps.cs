using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomationFramework.Core.Browser;
using TestAutomationFramework.TestData;
using TestAutomationFramework.Web.PageObjects.Pages;

namespace TestAutomationFramework.BDT.Pages
{
    [Binding]
    public class HowToDoItPageSteps
    {
        HowWeDoItPage howWeDoItPage = new();
        [When(@"I click the How we do it link on Header")]
        public void WhenIClickTheHowWeDoItLinkOnHeader()
        {
            howWeDoItPage.Load();
        }

        [When(@"I click back")]
        public void WhenIClickBack()
        {
            BrowserFactory.Browser.Refresh();
            BrowserFactory.Browser.Back();
            BrowserFactory.Browser.WaitForPageLoad();
        }
        [Then(@"I check the previous page")]
        public void ThenICheckThePreviousPage()
        {
            Assert.That(BrowserFactory.Browser.Url, Is.EqualTo(PageURLs.HowWeDoIt), "Page is not How to do it!");
        }
    }
}
