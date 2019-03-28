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
    public class BaseSteps
    {
        private readonly NgWebDriver _ngDriver;
        private readonly WebControls _webControls;

        private readonly SharedPageElements _sharedPageElements;

        public BaseSteps(NgWebDriver ngDriver)
        {
            _ngDriver = ngDriver;
            _webControls = new WebControls(_ngDriver);

            _sharedPageElements = new SharedPageElements(_webControls);
        }

        [Given(@"I am logged in as a scorecard user")]
        public void GivenIAmLoggedInAsAScorecardUser()
        {
            Console.WriteLine("Logged in as a scorecard user");
        }




    }
}
