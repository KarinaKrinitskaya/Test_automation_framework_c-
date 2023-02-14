using OpenQA.Selenium;
using TestAutomationFramework.Core.BasePage;
using TestAutomationFramework.Elements;
using TestAutomationFramework.TestData;
using TestAutomationFramework.TestData.ElementLocators;

namespace TestAutomationFramework.Web.PageObjects.Pages
{
    public class CareersPage : BasePage
    {
        public CareersPage() : base(PageURLs.Careers) { }

        public TextInput SearchKeywordInput => new TextInput(By.XPath(CareersLocationsPageLocators.KeywordInput));
        public Button FindButton => new Button(By.XPath(CareersLocationsPageLocators.FindButtonLocator));
        public Link SearchResCarPage => new Link(By.XPath(CareersLocationsPageLocators.SearchResultTitleLinks));
        public ElementsList<HtmlElement> SearchResCarPageItems => new ElementsList<HtmlElement>(By.XPath(CareersLocationsPageLocators.SearchResultTitleLinks));
        public Button LocationArrow => new Button(By.XPath(CareersLocationsPageLocators.LocationSelectionArrow));
        public TextInput LocationInput => new TextInput(By.XPath(CareersLocationsPageLocators.LocationSelectionInput));
        public ElementsList<HtmlElement> CityItems => new ElementsList<HtmlElement>(By.XPath(CareersLocationsPageLocators.LocationOptionGroup));
        public Button LocationInputCountry => new Button(By.XPath(CareersLocationsPageLocators.LocationOptionGroup));
        public ElementsList<HtmlElement> Location => new ElementsList<HtmlElement>(By.XPath(CareersLocationsPageLocators.SearchResultLocation));
        public Button LocationInputCity => new Button(By.XPath(CareersLocationsPageLocators.LocationOptionHighlighted));
        public Button SkillsButton => new Button(By.XPath(CareersLocationsPageLocators.InputButtonSkills));
        public ElementsList<HtmlElement> Skills => new ElementsList<HtmlElement>(By.XPath(CareersLocationsPageLocators.SkillsItems));
        public ElementsList<HtmlElement> SearchItem => new ElementsList<HtmlElement>(By.XPath(CareersLocationsPageLocators.SearchResultItem));
        public HtmlElement SearchNoResMassage => new HtmlElement(By.CssSelector(CareersLocationsPageLocators.ResultMessageError), false);
    }
}
