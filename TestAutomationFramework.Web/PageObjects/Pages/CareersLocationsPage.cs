using OpenQA.Selenium;
using TestAutomationFramework.Core.BasePage;
using TestAutomationFramework.Elements;
using TestAutomationFramework.TestData;
using TestAutomationFramework.TestData.ElementLocators;

namespace TestAutomationFramework.Web.PageObjects.Pages
{
    public class CareersLocationsPage : BasePage
    {
        public Link ApplyCareer => new Link(By.XPath(CareersLocationsPageLocators.ApplyCareerButton));

        public CareersLocationsPage() : base(PageURLs.CareersLocations) { }

        public override bool IsOpened()
        {
            return ApplyCareer.IsDisplayed();
        }
    }
}
