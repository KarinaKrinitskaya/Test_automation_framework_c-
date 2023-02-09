using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.BDT.SharedCompanents;
using TestAutomationFramework.Web.PageObjects.Pages;
using TestAutomationFramework.TestData;

namespace TestAutomationFramework.BDT.Pages
{
    [Binding]
    public class CareersPageSteps
    {
        public CareersLocationsPage careersPage = new();

        [Then(@"I check the apply button is desplayed")]
        public void ThenICheckTheApplyButtonIsDesplayed()
        {
            Assert.IsTrue(careersPage.IsOpened(), "Careers loaction page is not loaded");
            Assert.IsTrue(careersPage.ApplyCareer.IsDisplayed(), "Button Apply is not displayed");
        }

    }
}
