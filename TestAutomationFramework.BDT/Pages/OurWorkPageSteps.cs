using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationFramework.Core.Browser;
using TestAutomationFramework.TestData;
using TestAutomationFramework.Web.PageObjects.Pages;

namespace TestAutomationFramework.BDT.Pages
{
    [Binding]
    public class OurWorkPageSteps
    {
        OurWorkPage ourWorkPage = new();
        [When(@"I click the Our work")]
        public void WhenIClickTheOurWork()
        {
            ourWorkPage.Load();
        }

    }
}
