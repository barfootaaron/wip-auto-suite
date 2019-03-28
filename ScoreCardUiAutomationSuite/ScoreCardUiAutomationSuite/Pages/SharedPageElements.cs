using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Protractor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ScoreCardUiAutomationSuite.Generic;

namespace ScoreCardUiAutomationSuite.Pages
{
    public class SharedPageElements
    {
        private readonly NgWebDriver _ngDriver;
        private readonly WebControls _webControls;

        private readonly By navBar = By.XPath("//sc-nav-bar//nav");
        private readonly By navLogo = By.Id("nav-logo");


        public SharedPageElements(WebControls webControls) => _webControls = webControls;


        /* Actions */
        public void ClickNavLogo()
        {
            _webControls.Click(navLogo);
        }

        /* Assertions */
        public void Assert_NavBarIsDisplayed()
        {
            Assert.IsTrue(_webControls.DoesElementExist(navBar));
        }
    }


}