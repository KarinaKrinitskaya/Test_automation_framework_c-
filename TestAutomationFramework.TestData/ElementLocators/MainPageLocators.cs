namespace TestAutomationFramework.TestData.ElementLocators
{
    public class MainPageLocators
    {
        public static readonly string LanguageSelectorItems = "//*[@class='location-selector__item']";
        public static readonly string LanguageSelectorButton = "//*[@class='location-selector__button']";

        public static readonly string CareersLocationsLink = "//*[@href='/careers/locations']";
        public static readonly string CareersLink = "//*[@href=\"/careers\"]";
        public static readonly string CareerJobListingsLink = "//*[@href='/careers/job-listings']";
        public static readonly string CareerLocationSelectorButton = "//*[@class='location-selector__button']";
        public static readonly string CareerLocationSelectorItem = "//*[@class='location-selector__item']";

        public static readonly string HeaderSearchUIDiv = "//*[@class='header-search-ui header__control']";
        public static readonly string HeaderSearchFrequentItem2 = "//li[@class='frequent-searches__item'][2]";
        public static readonly string HeaderSearchFindButton = "//form[@action='/search']/child::button[@class='header-search__submit']";
        public static readonly string HeaderSearchResultsItems = "//article[@class='search-results__item']";
        public static readonly string SearchResultFooter = "//*[@class='search-results__footer']";

        public static readonly string CareesTabsTitle = "//*[@class='tabs__title' and contains(@role,'presentation')]";
        public static readonly string HeaderSearchInput = "//*[@class='header-search__input frequent-searches__input']";
        public static readonly string SearchResultTitleLink = "//*[@class='search-results__title-link']";
        public static readonly string TittleH1 = "//h1";
        
    }
}
