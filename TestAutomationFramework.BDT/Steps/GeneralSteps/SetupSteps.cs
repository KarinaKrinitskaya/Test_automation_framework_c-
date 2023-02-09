using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomationFramework.Core.Helpers;
using TestAutomationFramework.Utilities;
using TestAutomationFramework.Web.PageObjects.Pages;

namespace TestAutomationFramework.BDT.Steps.GeneralSteps
{
    
    [Binding]
    public class SetupSteps
    {
        [BeforeFeature(Order = 1)]
        public static void OneTimeSetUp()
        {
            TestSettings.TestContext = TestContext.CurrentContext;
            Logger.Initialize(TestSettings.LogsPath);
        }

        [BeforeScenario]
        public virtual void BeforeTest()
        {
            Logger.Info("Test begin: " + TestContext.CurrentContext.Test.Name);
            MainPage mainPage = new MainPage();
            mainPage.Load();
        }
    }
}
