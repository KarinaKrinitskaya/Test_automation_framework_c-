using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomationFramework.Web.PageObjects.Pages;

namespace TestAutomationFramework.BDT.Pages
{
    [Binding]
    public class ServicesPageSteps
    {
        ServicesPage servicesPage = new();
        [Then(@"I check all sections is displayed")]
        public void ThenICheckSectionsIsDisplayed()
        {
            Assert.IsTrue(servicesPage.ServicesSectionMain.IsDisplayed(), "Section Tittle is not displayed");
            Assert.IsTrue(servicesPage.SectionServicesList.IsDisplayed(), "Section Services List is not displayed");
            Assert.IsTrue(servicesPage.SectionServicesStrategy.IsDisplayed(), "Section Strategy and Execution is not displayed");
            Assert.IsTrue(servicesPage.SectionServicesHearFromtheCustomer.IsDisplayed(), "Section Hear from the Customer is not displayed");
            Assert.IsTrue(servicesPage.SectionServicesImages.IsDisplayed(), "Section with images is not displayed");
            Assert.IsTrue(servicesPage.SectionServicesContacts.IsDisplayed(), "Section Contacts is not displayed");
        }

    }
}
