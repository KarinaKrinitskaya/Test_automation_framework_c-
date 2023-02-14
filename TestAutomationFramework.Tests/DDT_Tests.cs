using System;
using System.Numerics;
using TestAutomationFramework.TestData;
using TestAutomationFramework.TestData.Models;
using TestAutomationFramework.Utilities.Parser;
using TestAutomationFramework.Web.PageObjects.Pages;

namespace TestAutomationFramework.Tests
{
    //[Parallelizable(ParallelScope.All)]
	public class DDT_Tests : BaseTest
	{
      

        [Test]
        [TestCaseSource(nameof(GetKeywordInput))]
        public void CheckSearchInputJoinOrTeam(KeywordInputModel keyword)
        {
            mainPage.Load();
            mainPage.CareersLink.MouseHover();
            mainPage.CareerJobListingsLink.ClickUsingJS();
            careersPage.SearchKeywordInput.SendKeys(keyword.InputKeyword);
            careersPage.FindButton.Click();
            var first3Items = careersPage.SearchResCarPageItems.GetElements().Take(3);
            var actualRes = first3Items.Select(x => x.GetText());
            
            foreach (var item in actualRes)
            {
                
                Logger.Info(item);
                Assert.That(item.Contains(keyword.InputKeyword, StringComparison.OrdinalIgnoreCase), "Text was not found");
            }
        }

        [Test]
        [TestCaseSource(nameof(GetLocationInput))]
        public void CheckSearchJoinOrTeamCountry(LocationInputModel location)
        {
            mainPage.Load();
            mainPage.CareersLink.MouseHover();
            mainPage.CareerJobListingsLink.ClickUsingJS();
            careersPage.LocationArrow.Click();
            careersPage.LocationInput.SendKeys(location.InputCountry);
            careersPage.LocationInputCountry.Click();
            var cityList = careersPage.CityItems.GetElements();

            foreach (var elem in cityList)
            {
                var textElem = elem.GetText();
                if(textElem == location.InputCity)
                {
                    elem.Click();
                    break;
                }
            }
            careersPage.FindButton.Click();
            var first3Items = careersPage.Location.GetElements().Take(3);


            
            var actualRes = first3Items.Select(x => x.GetText());

            foreach (var item in actualRes)
            {
                Assert.That(item.Contains(location.InputCountry, StringComparison.OrdinalIgnoreCase), "Text was not found");
            }
        }

        [Test]
        [TestCaseSource(nameof(GetSkillInput))]
        public void CheckSearchJoinOrTeamSkills(SkillInputModel skill)
        {
            mainPage.Load();
            mainPage.CareersLink.MouseHover();
            mainPage.CareerJobListingsLink.ClickUsingJS();
            careersPage.SkillsButton.Click();

            var skillsList = careersPage.Skills.GetElements();

            
            foreach (var elem in skillsList)
            {
                var textElem = elem.GetText();
                string[] words = textElem.Split(" ");

                foreach(var word in words)
                {
                    if (word == skill.InputSkill)
                    {
                        elem.Click();
                        break;
                    }
                }
            }

            var firstItems = careersPage.SearchResCarPageItems.GetElements().Take(1);

            var actualRes = firstItems.Select(x => x.GetText());

            foreach (var item in actualRes)
            {
                Assert.That(item.Contains(skill.InputSkill,StringComparison.OrdinalIgnoreCase), "Text was not found");
            }
        }

        [Test]
        [TestCaseSource(nameof(GetAllParamInput))]
        public void CheckSearchAllParam(InputAllParametrsModel param)
        {
            mainPage.Load();
            mainPage.CareersLink.MouseHover();
            mainPage.CareerJobListingsLink.ClickUsingJS();
            careersPage.SearchKeywordInput.SendKeys(param.InputKeyword);
            careersPage.LocationArrow.Click();
            careersPage.LocationInput.SendKeys(param.InputCountry);
            careersPage.LocationInputCountry.Click();
            var cityList = careersPage.CityItems.GetElements();

            foreach (var elem in cityList)
            {
                var textElem = elem.GetText();
                if (textElem == param.InputCity)
                {
                    elem.Click();
                    break;
                }
            }
            careersPage.SkillsButton.Click();
            var skillsList = careersPage.Skills.GetElements();
            foreach (var elem in skillsList)
            {
                var textElem = elem.GetText();
               
                    if (textElem == param.InputSkill)
                    {
                        elem.Click();
                        break;
                    }
            }

            var actualCountArticles = careersPage.SearchItem.GetElements().Count;
            Assert.That(actualCountArticles != 0, "There are not result!");
        }

        [Test]
        [TestCaseSource(nameof(GetErrorMessageInput))]
        public void CheckNoResuilMessage(InputForErrorMessageModel param)
        {
            mainPage.Load();
            mainPage.CareersLink.MouseHover();
            mainPage.CareerJobListingsLink.ClickUsingJS();
            careersPage.SearchKeywordInput.SendKeys(param.InputKeyword);
            careersPage.LocationArrow.Click();
            careersPage.LocationInput.SendKeys(param.InputCountry);
            careersPage.LocationInputCountry.Click();
            var cityList = careersPage.CityItems.GetElements();

            foreach (var elem in cityList)
            {
                var textElem = elem.GetText();
                if (textElem == param.InputCity)
                {
                    elem.Click();
                    break;
                }
            }
            careersPage.FindButton.Click();
            var expRes = "Sorry, your search returned no results. Please try another combination.";
            var actualres = careersPage.SearchNoResMassage.GetText();
            Logger.Info("FOUND TEXEEETEEXT: " + actualres);
            Assert.That(actualres == expRes, "There are not error massage!");
        }

        private static List<KeywordInputModel> GetKeywordInput()
        {
            return JSONparser.DeserializeJsonToObjects<KeywordInputModel>(@"/Users/karinakrinickaa/Projects/IT-academy/Test_Automation_Framework_C#/TestAutomationFramework.TestData/InputsKeyword.json").ToList();
        }

        private static List<LocationInputModel> GetLocationInput()
        {
            return JSONparser.DeserializeJsonToObjects<LocationInputModel>(@"/Users/karinakrinickaa/Projects/IT-academy/Test_Automation_Framework_C#/TestAutomationFramework.TestData/InputsLocation.json").ToList();
        }

        private static List<SkillInputModel> GetSkillInput()
        {
            return JSONparser.DeserializeJsonToObjects<SkillInputModel>(@"/Users/karinakrinickaa/Projects/IT-academy/Test_Automation_Framework_C#/TestAutomationFramework.TestData/InputsSkills.json").ToList();
        }

        private static List<InputAllParametrsModel> GetAllParamInput()
        {
            return JSONparser.DeserializeJsonToObjects<InputAllParametrsModel>(@"/Users/karinakrinickaa/Projects/IT-academy/Test_Automation_Framework_C#/TestAutomationFramework.TestData/InputsAllParametrs.json").ToList();
        }
        private static List<InputForErrorMessageModel> GetErrorMessageInput()
        {
            return JSONparser.DeserializeJsonToObjects<InputForErrorMessageModel>(@"/Users/karinakrinickaa/Projects/IT-academy/Test_Automation_Framework_C#/TestAutomationFramework.TestData/InputForErrorMessage.json").ToList();
        }
    }
}

