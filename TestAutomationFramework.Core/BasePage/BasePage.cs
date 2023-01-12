using System.Collections.ObjectModel;
using TestAutomationFramework.Core.Browser;
using OpenQA.Selenium;
using System.ComponentModel;

namespace TestAutomationFramework.Core.BasePage
{
    public class BasePage
    {
        public string PageURL { get; private set; }

        public BasePage(string pageURL)
        {
            PageURL = pageURL;
        }

        public void Load()
        {
            BrowserFactory.Browser.LoadPage(this);
        }

        public virtual bool IsOpened()
        {
            throw new NotImplementedException();
        }
    }
}
