using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Protractor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using BoDi;

namespace ScoreCardUiAutomationSuite.Generic
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private NgWebDriver _ngDriver;
        private WebControls _webControls;

        public Hooks(IObjectContainer container)
        {
            _objectContainer = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            HookHelper.IgnoreManualTestingScenarios();

            _ngDriver = HookHelper.GetDriver(Globals.DriverType.Chrome, false);

            _objectContainer.RegisterInstanceAs<NgWebDriver>(_ngDriver);

            _ngDriver.Navigate().GoToUrl("http://localhost:4200/");

        }
        [AfterScenario]
        public void CleanUp()
        {
            _ngDriver.Close();
            _ngDriver.Dispose();
        }
    }
}
