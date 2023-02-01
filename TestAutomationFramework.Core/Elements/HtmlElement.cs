using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAutomationFramework.Elements
{
    public class HtmlElement : BaseElement
    {
        public HtmlElement(By locator, bool ensureDisplayed = true) : base(locator, ensureDisplayed)
        {

        }

        public HtmlElement(IWebElement element) : base(element)
        {
        }
    }
}
