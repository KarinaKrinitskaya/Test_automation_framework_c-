using NUnit.Framework;  
using TechTalk.SpecFlow;
using TestAutomationFramework.Core.Browser;
using TestAutomationFramework.Core.Helpers;
using TestAutomationFramework.Utilities;

namespace TestAutomationFramework.BDT.Steps.GeneralSteps
{
    [Binding]
    public class TearDownSteps
    {
        [AfterScenario]
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
