using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomationFramework.BDT.Pages;
using TestAutomationFramework.Web.PageObjects.Pages;

namespace TestAutomationFramework.BDT.SharedCompanents
{
    [Binding]
    public class HeaderSteps
    {

        public MainPage landPage = new();

        [Given(@"I navigate to Landing Page of Epam site")]
        public void GivenNavigateToLandingPageEpamSite()
        {
            landPage.Load();
        }

        [Then(@"I check that Header is displayed")]
        public void ThenTheHeaderIsDisplayedOnTheMainPage()
        {
            Assert.IsTrue(landPage.CareersLink.IsDisplayed(), "Header is not displayed");
        }

        [When(@"I click the Hiring Locations link on Header")]
        public void WhenIClickTheHiringLocationsLinkOnHeader()
        {
            landPage.CareersLink.MouseHover();
            landPage.CareerLocationsLink.Click();
        }
        [When(@"I click the Services link on Header")]
        public void WhenIClickTheServicesLinkOnHeader()
        {
            landPage.ServicesLink.Click();
        }

    }
}
