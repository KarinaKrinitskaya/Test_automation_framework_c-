using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.BasePage;
using TestAutomationFramework.Elements;
using TestAutomationFramework.TestData;
using TestAutomationFramework.TestData.ElementLocators;

namespace TestAutomationFramework.Web.PageObjects.Pages
{
    public class ServicesPage : BasePage
    {
        public Link ServicesSectionMain  => new Link(By.CssSelector(ServiesPageLocators.ServicesTittle));
        public HtmlElement SectionServicesList => new HtmlElement(By.CssSelector(ServiesPageLocators.ServicesListSection));
        public HtmlElement SectionServicesStrategy => new HtmlElement(By.CssSelector(ServiesPageLocators.ServicesStrategySection));
        public HtmlElement SectionServicesHearFromtheCustomer => new HtmlElement(By.CssSelector(ServiesPageLocators.ServicesHearFromtheCustomerSection));
        public HtmlElement SectionServicesImages => new HtmlElement(By.CssSelector(ServiesPageLocators.ServicesImagesSection));

        public HtmlElement SectionServicesContacts => new HtmlElement(By.CssSelector(ServiesPageLocators.ServicesContactsSection));
        public ServicesPage() : base(PageURLs.Services) { }
    }
}
