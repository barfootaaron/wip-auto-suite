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
    public class NavBarLinksSteps
    {
        private readonly NgWebDriver _ngDriver;
        private readonly WebControls _webControls;

        private readonly SharedPageElements _sharedPageElements;

        public NavBarLinksSteps(NgWebDriver ngDriver, WebControls webControls)
        {
            _ngDriver = ngDriver;
            _webControls = webControls;

            _sharedPageElements = new SharedPageElements(webControls);
        }

        [Given(@"I am at the scorecard app root page '(.*)'")]
        public void GivenIAmAtTheScorecardAppRootPage(string rootUrl)
        {
            //_ngDriver.Url = "http://localhost:4200/";
            return;
        }
        
        [When(@"I click on the FPS logo in the nav")]
        public void WhenIClickOnTheFPSLogoInTheNav()
        {
            _sharedPageElements.ClickNavLogo();
        }
        
        [Then(@"I should be directed to the FPS local dev login page '(.*)'")]
        public void ThenIShouldBeDirectedToTheFPSLocalDevLoginPage(string p0)
        {
            Assert.AreEqual("https://localdev.psperformancesuite.com/", _ngDriver.Url);
        }

        [Given(@"I am viewig the '(.*)'")]
        public void GivenIAmViewigThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on the '(.*)' in the nav")]
        public void WhenIClickOnTheInTheNav(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be directed to the '(.*)'")]
        public void ThenIShouldBeDirectedToThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
