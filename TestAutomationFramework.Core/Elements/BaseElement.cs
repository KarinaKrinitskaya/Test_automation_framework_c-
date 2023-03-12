using TestAutomationFramework.Core.Browser;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using NLog;

namespace TestAutomationFramework.Elements
{
    public abstract class BaseElement : IBaseElement
    {
        protected readonly IWebElement element;

        public By Locator { get; private set; }

        protected BaseElement(By locator)
        {
            Locator = locator;
            element = BrowserFactory.Browser.FindElement(locator);
        }
        protected BaseElement(IWebElement element)
        {
            this.element = element;
        }

        public string GetText() => element.Text.Trim();

        public string GetAttribute(string attributeName) => element.GetAttribute(attributeName);


        public virtual void Click()
        {
            element.Click();
            TestAutomationFramework.Utilities.Logger.Info($"Clicked on {Locator}");
        }

        public void SendKeys(string text)
        {
            element.SendKeys(text);
        }

        public void Clear()
        {
            element.Clear();
        }

        public void MouseHover()
        {
            BrowserFactory.Browser.Action.MoveToElement(element).Build().Perform();
        }

        public void ScrollToMe()
        {
            BrowserFactory.Browser.ScrollToElement(element);
        }

        public bool Exists()
        {
            return element != null;
        }

        public bool IsDisplayed() => element.Displayed;

        public bool IsEnabled() => element.Enabled;

        public int GetWidth() => element.Size.Width;

        public int GetHeight() => element.Size.Height;

        public Point GetLocation() => element.Location;


        public IWebElement FindElement(By by) => element.FindElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => element.FindElements(by);


        public bool IsElementOnView()
        {
            var script = "var elem = arguments[0],                 " +
                         "  box = elem.getBoundingClientRect(),    " +
                         "  cx = box.left + box.width / 2,         " +
                         "  cy = box.top + box.height / 2,         " +
                         "  e = document.elementFromPoint(cx, cy); " +
                         "for (; e; e = e.parentElement) {         " +
                         "  if (e === elem)                        " +
                         "    return true;                         " +
                         "}                                        " +
                         "return false;                            ";
            return (bool)BrowserFactory.Browser.ExecuteScript(script, element);
        }


        public void ClickUsingJS()
        {
            BrowserFactory.Browser.ExecuteScript("arguments[0].click()", element);
        }

        public void DragAndDrop(BaseElement targetElement)
        {
            CreateAction().DragAndDrop(element, targetElement.element).Perform();
        }

        public void DragAndDropToOffset(int offsetX, int offsetY)
        {
            CreateAction().DragAndDropToOffset(element, offsetX, offsetY).Perform();
        }

        private static Actions CreateAction()
        {
            return BrowserFactory.Browser.Action;
        }
    }
}
