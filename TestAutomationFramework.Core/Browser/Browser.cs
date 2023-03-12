using System.Collections.ObjectModel;
using TestAutomationFramework.Core.Helpers;
using TestAutomationFramework.Core.Screenshot;
using TestAutomationFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestAutomationFramework.Elements;
using OpenQA.Selenium.Internal;

namespace TestAutomationFramework.Core.Browser
{
    public class Browser
    {
        private IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ScrollToElement(IWebElement element)
        {
            Logger.Info($"Scroll to element with tag: {element.TagName}");
            ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void Back()
        {
            Logger.Info("Navigate Back");
            _driver.Navigate().Back();
        }

        public void Refresh()
        {
            Logger.Info("Refresh page");
            _driver.Navigate().Refresh();
        }

        public void GoToUrl(string url)
        {
            Logger.Info($"Open url: {url}");
            _driver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            Logger.Info("Quit Browser");
            try
            {
                _driver.Quit();
                _driver.Close();
                _driver = null;
            }

            catch (Exception ex)
            {
                Logger.Error($"Unable to Quit the browser. Reason: {ex.Message}");
            }
        }

        public string Url
        {
            get => _driver.Url;
            set => _driver.Url = value;
        }

        #region Screenshoot

        public void SaveScreenshoot(string screenshotName, string folderPath)
        {
            try
            {
                Logger.Info("Generating of screenshot started.");
                ScreenshotTaker.TakeScreenshot(_driver, screenshotName, folderPath);
                Logger.Info("Generating of screenshot finished.");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to capture screenshot. Exception message {ex.Message}");
            }
        }

        #endregion

        #region Waiters/Actions

        public WebDriverWait Waiters() => new WebDriverWait(_driver, TestSettings.WebDriverTimeOut) { PollingInterval = TimeSpan.FromMilliseconds(1000) };

        public Actions Action => new Actions(_driver);

        #endregion

        #region Element Operations

        public void LoadPage(BasePage.BasePage page)
        {
            GoToUrl(page.PageURL);
            WaitForPageLoad();
        }

        public void WaitForPageLoad() => Waiters().Until(condition => ExecuteScript("return document.readyState").Equals("complete"));


        public IWebElement FindElement(By locator)//extra exeption for waiting
        {
            Logger.Info($"Searching for element{locator.ToString()}");
            //return Waiters().Until(c => _driver.FindElement(locator));
            return Waiters().Until(c =>
            {
                IWebElement elem;
                try
                {
                    elem = _driver.FindElement(locator);
                    return elem != null && elem.Displayed && elem.Enabled ? elem : null;
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by) => Waiters().Until(condition => _driver.FindElements(by));

        #endregion

        public object ExecuteScript(string script, params object[] args)
        {
            try
            {
                return ((IJavaScriptExecutor)_driver).ExecuteScript(script, args);
            }
            catch (WebDriverTimeoutException e)
            {
                // If timeout or any errors
                Logger.Error($"Error: Timeout Exception thrown while running JS Script:{e.Message}-{e.StackTrace}");
            }
            return null;
        }
    }
}
