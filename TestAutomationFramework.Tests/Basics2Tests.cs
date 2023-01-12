using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TestAutomationFramework.TestData;
using TestAutomationFramework.Web.PageObjects.Pages;
using OpenQA.Selenium.DevTools.V106.DOM;

namespace TestAutomationFramework.Tests
{
    public class Basics2Tests : BaseTest
    {
        [Test]
        public void CheckListAvailableCountries()
        {
            List<string> webElemList = new List<string>() { "AMERICAS", "EMEA", "APAC" };

            mainPage.Load();
            mainPage.CareersLink.Click();
            var actualCountriesList = mainPage.CareerTabsTitle.GetElements().Select(i => i.GetAttribute("innerText")); 

            Assert.That(actualCountriesList, Is.EqualTo(webElemList), "List of countries doesn't have: Americas, EMEA, APAC");
        }

        [Test]
        public void CheckSearchInputAutomation()
        {
            mainPage.Load();
            mainPage.HeaderSearchUIDiv.Click();
            mainPage.SearchHeaderInput.SendKeys("Automation");
            mainPage.HeaderSearchFindButton.Click();
            Assert.That(BrowserFactory.Browser.Url, Is.EqualTo(PageURLs.SearchAutomation), "Search doesn't work!");
            bool isContains = BrowserFactory.Browser.Url.Contains("Automation");
            Assert.IsTrue(isContains, "Text was not found");
        }

        [Test]
        public void CheckSearchInputBusinessAnalysis()
        {
            mainPage.Load();
            mainPage.HeaderSearchUIDiv.Click();
            mainPage.SearchHeaderInput.SendKeys("Business Analysis");
            mainPage.HeaderSearchFindButton.Click();
            Assert.That(BrowserFactory.Browser.Url, Is.EqualTo(PageURLs.SearchBusinessAnalysis), "Search doesn't work!");
            var expectedRes = mainPage.SearchResultTitleLink.GetText();
            mainPage.SearchResultTitleLink.Click();
            var actualRes = mainPage.MainTittle.GetText();

            Assert.That(actualRes, Is.EqualTo(expectedRes), "The title of the article does not match the title from the search!");
        }
  
    }
}
