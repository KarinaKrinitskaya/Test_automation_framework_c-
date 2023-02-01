using TestAutomationFramework.Web.PageObjects.Pages;

namespace TestAutomationFramework.Tests
{
    public abstract class BaseTest
    {
        protected MainPage mainPage;
        protected CareersPage careersPage;
        protected HowWeDoItPage howWeDoItPage;
        protected OurWorkPage ourWorkPage;
        protected CareersLocationsPage careersLocationsPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestSettings.TestContext = TestContext.CurrentContext;
            Logger.Initialize();

            mainPage = new MainPage();
            careersPage = new CareersPage();
            howWeDoItPage = new HowWeDoItPage();
            ourWorkPage = new OurWorkPage();
            careersLocationsPage = new CareersLocationsPage();
        }

        [SetUp]
        public virtual void BeforeTest()
        {
            Logger.Info("Test begin: " + TestContext.CurrentContext.Test.Name);
            mainPage.Load();
        }

        [TearDown]
        public virtual void CleanTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Logger.Error("Test is failed: " + TestContext.CurrentContext.Test.Name);
                BrowserFactory.Browser.SaveScreenshoot(TestContext.CurrentContext.Test.MethodName, Path.Combine(TestContext.CurrentContext.TestDirectory, TestSettings.ScreenShotPath));
            }
            Logger.Info("Test finish");
            BrowserFactory.CloseBrowser();
        }
    }
}
