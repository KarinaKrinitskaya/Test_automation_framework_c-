using TestAutomationFramework.Elements;
using TestAutomationFramework.TestData;
using TestAutomationFramework.Web.PageObjects.Pages;

namespace TestAutomationFramework.Tests
{
    public class AdvancedTests : BaseTest
    {
        [Test]
        public void CheckCareersMenuJoinOurTeam() //using IJavaScriptExecutor here
        {
            mainPage.Load();
            mainPage.CareersLink.MouseHover();
            mainPage.CareerJobListingsLink.ClickUsingJS();
            BrowserFactory.Browser.WaitForPageLoad();
            Assert.That(BrowserFactory.Browser.Url, Is.EqualTo(PageURLs.CareersJobListing), "Join our team page is not opened!");
        }

        [Test]
        public void CheckLanguageslist()
        {
            List<string> expectedLanguagesList = new List<string>()
            {
                "Global (English)",
                "Hungary (English)",
                "СНГ (Русский)",
                "Česká Republika (Čeština)",
                "India (English)",
                "Україна (Українська)",
                "Czech Republic (English)",
                "日本 (日本語)",
                "中国 (中文)",
                "DACH (Deutsch)",
                "Polska (Polski)"
            };

            mainPage.Load();
            mainPage.CareerLocationSelectorButton.Click();
            var actualLanguagesList = mainPage.CareerLocationSelectorItems.GetElements().Select(i => i.GetAttribute("innerText"));
            Assert.That(actualLanguagesList, Is.EqualTo(expectedLanguagesList), "List of languages does not match the expected!");
        }

        [Test]
        public void Check20Articlesonpage()
        {
            const int targetCountArticle = 20;
            mainPage.Load();
            mainPage.HeaderSearchUIDiv.Click();
            mainPage.HeaderSearchFrequentItem2.Click();
            mainPage.HeaderSearchFindButton.Click();
            mainPage.SearchResultFooter.ScrollToMe();
            Thread.Sleep(1500);
            var actualCountArticles = mainPage.HeaderSearchResultItems.GetElements().Count;
            Assert.That(actualCountArticles == targetCountArticle, "There are not 20 articles on the one page!");
        }
    }
}