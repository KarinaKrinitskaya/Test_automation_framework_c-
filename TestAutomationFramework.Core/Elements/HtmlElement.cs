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
        public HtmlElement(By locator) : base(locator)
        {

        }

        public HtmlElement(IWebElement element) : base(element)
        {
        }
    }
}
