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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Threading.Tasks;

namespace ScoreCardUiAutomationSuite.Generic
{
    public class WebControls
    {
        private readonly NgWebDriver _ngDriver;
        private readonly WebDriverWait _wait;

        public WebControls(NgWebDriver ngDriver)
        {
            _ngDriver = ngDriver;
            PageFactory.InitElements(ngDriver, this);

            _wait = new WebDriverWait(ngDriver, TimeSpan.FromSeconds(10));

        }
        #region Gets/Returns
        public NgWebElement ReturnElement(By by)
        {
            //_wait.Until(ExpectedConditions.ElementExists(by));
            return _ngDriver.FindElement(by);
        }

        public IEnumerable<NgWebElement> ReturnElements(By by)
        {
            //_wait.Until(ExpectedConditions.ElementExists(by));
            return _ngDriver.FindElements(by);
        }

        internal string GetText(By by)
        {
            return _ngDriver.FindElement(by).Text;
        }

        internal string GetInput(By by)
        {
            return _ngDriver.FindElement(by).GetAttribute("value");
        }
        #endregion

        #region Actions
        public void HoverAndClick(By by)
        {
            var action = new Actions(_ngDriver);
            var button = ReturnElement(by);
            action.MoveToElement(button).Click(button).Build().Perform();
        }

        public void Click(By by)
        {
            _ngDriver.FindElement(by).Click();
        }

        public void ClickOnCoordinate(By by, int xcoordinate, int ycoordinate)
        {
            var element = _ngDriver.FindElement(by);
            var builder = new Actions(_ngDriver);

            builder.MoveByOffset(xcoordinate, ycoordinate).Perform();
            builder.Click(element);
            builder.Build().Perform();
            WaitForPageToLoad();
        }

        internal void EnterText(By by, string text)
        {
            _ngDriver.FindElement(by).SendKeys(text);
        }

        internal void ClearText(By by)
        {
            _ngDriver.FindElement(by).Clear();
        }

        internal void EnterText(NgWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public void ScrollToElement(By by)
        {
            var element = ReturnElement(by);
            ((IJavaScriptExecutor)_ngDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        #endregion

        #region Assertions
        public bool IsElementDisplayed(By by)
        {
            return _ngDriver.FindElement(by).Displayed;
        }

        public bool DoesElementExist(By by)
        {
            try
            {
                _ngDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementVisible(NgWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public void AssertIsElementDisplayed(By by)
        {
            Assert.IsTrue(_ngDriver.FindElement(by).Displayed);
        }
        public void AssertElementIsNotDisplayed(By by)
        {
            Assert.IsFalse(DoesElementExist(by));
        }

        public void AssertValueIsFalse(bool value)
        {
            Assert.IsFalse(value);
        }
        #endregion

        #region Waits
        // May not need these with NgWebDriver, needed when testing ng apps with standard WebDriver 
        //public void WaitForFinishedLoading()
        //{
        //    _wait.Until<bool>(d =>
        //    {
        //        var loadingIcon = ReturnElement(_sharedPageElements.loadingIcon);
        //        return bool.Parse(loadingIcon.GetAttribute("aria-hidden"));
        //    });
        //    WaitFor(TimeSpan.FromSeconds(1));
        //}



        public void WaitForPageToLoad()
        {
            WaitFor(TimeSpan.FromSeconds(4));
        }

        public void WaitFor(TimeSpan timeSpan)
        {
            Task.Delay(timeSpan).Wait();
        }
        #endregion
    }



}
