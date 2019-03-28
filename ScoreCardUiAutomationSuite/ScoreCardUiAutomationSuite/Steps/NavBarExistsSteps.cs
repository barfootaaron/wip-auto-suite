using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Protractor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ScoreCardUiAutomationSuite.Pages;
using ScoreCardUiAutomationSuite.Generic;

namespace ScoreCardUiAutomationSuite.Steps
{
    [Binding]
    public class NavBarExistsSteps
    {
        public NgWebDriver _ngDriver;
        private readonly WebControls _webControls;

        private readonly SharedPageElements _sharedPageElements;

        public NavBarExistsSteps(NgWebDriver ngDriver)
        {
            this._ngDriver = ngDriver;
            _webControls = new WebControls(ngDriver);

            _sharedPageElements = new SharedPageElements(_webControls);
        }


        [When(@"I view my '(.*)'")]
        public void WhenIViewMy(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see the '(.*)' displayed with the FPS Logo")]
        public void ThenIShouldSeeTheDisplayedWithTheFPSLogo(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
