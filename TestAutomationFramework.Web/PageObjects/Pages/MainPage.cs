using TestAutomationFramework.Core.BasePage;
using TestAutomationFramework.Elements;
using TestAutomationFramework.Web.PageObjects.Panels;
using OpenQA.Selenium;
using TestAutomationFramework.TestData;
using TestAutomationFramework.TestData.ElementLocators;

namespace TestAutomationFramework.Web.PageObjects.Pages
{
    public class MainPage : BasePage
    {
        public MainPage() : base(PageURLs.Main) { }

        public Button LanguageSelectorButton => new Button(By.XPath(MainPageLocators.LanguageSelectorButton));

        public Link CareersLink => new Link(By.XPath(MainPageLocators.CareersLink));

        public Link CareerLocationsLink => new Link(By.XPath(MainPageLocators.CareersLocationsLink));

        public Link CareerJobListingsLink => new Link(By.XPath(MainPageLocators.CareerJobListingsLink));

        public Button CareerLocationSelectorButton => new Button(By.XPath(MainPageLocators.CareerLocationSelectorButton));

        public ElementsList<HtmlElement> CareerLocationSelectorItems => new ElementsList<HtmlElement>(By.XPath(MainPageLocators.CareerLocationSelectorItem));

        public ElementsList<HtmlElement> CareerTabsTitle => new ElementsList<HtmlElement>(By.XPath(MainPageLocators.CareesTabsTitle));

        

        public HtmlElement HeaderSearchUIDiv => new HtmlElement(By.XPath(MainPageLocators.HeaderSearchUIDiv));

        public HtmlElement HeaderSearchFrequentItem2 => new HtmlElement(By.XPath(MainPageLocators.HeaderSearchFrequentItem2));

        public Button HeaderSearchFindButton => new Button(By.XPath(MainPageLocators.HeaderSearchFindButton));

        public ElementsList<HtmlElement> HeaderSearchResultItems => new ElementsList<HtmlElement>(By.XPath(MainPageLocators.HeaderSearchResultsItems));

        public HtmlElement SearchResultFooter => new HtmlElement(By.XPath(MainPageLocators.SearchResultFooter));

        public TextInput SearchHeaderInput => new TextInput(By.XPath(MainPageLocators.HeaderSearchInput));

        public Link SearchResultTitleLink => new Link(By.XPath(MainPageLocators.SearchResultTitleLink));

        public HtmlElement MainTittle => new HtmlElement(By.XPath(MainPageLocators.TittleH1));

        public override bool IsOpened()
        {
            return CareersLink.IsDisplayed();
        }
    }
}
