using TestAutomationFramework.TestData;

namespace TestAutomationFramework.Tests
{
    public class ElementaryTests : BaseTest
    {
        [Test]
        public void CheckHeader()
        {
            mainPage.Load();
            Assert.IsTrue(mainPage.CareersLink.IsDisplayed(), "Header is not displayed");
        }

        [Test]
        public void CheckLocPagesOpen()
        {
            mainPage.Load();
            mainPage.CareersLink.MouseHover();
            mainPage.CareerLocationsLink.Click();
            Assert.IsTrue(careersLocationsPage.IsOpened(), "Careers loaction page is not loaded");
            Assert.IsTrue(careersLocationsPage.ApplyCareer.IsDisplayed(), "Button Apply is not displayed");
        }
    }
}