using NUnit.Framework;
using System;
using System.IO;
using Protractor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;


namespace ScoreCardUiAutomationSuite.Generic
{
    public class HookHelper
    {
        public static NgWebDriver GetDriver(Globals.DriverType driverType, bool useHeadless = false)
        {
            NgWebDriver _ngDriver;
            string[] headlessArgs =
            {
                "no-sandbox",
                "headless",
                "disable-gpu",
                "window-size=1920,1080"
            };

            switch (driverType)
            {
                case Globals.DriverType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("window-size=1920,1080");
                    if (useHeadless) { chromeOptions.AddArguments(headlessArgs); }
                    _ngDriver = new NgWebDriver(new ChromeDriver(chromeOptions));
                    break;
                case Globals.DriverType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    if (useHeadless) { firefoxOptions.AddArguments(headlessArgs); }
                    _ngDriver = new NgWebDriver(new FirefoxDriver(firefoxOptions));
                    break;
                //case Globals.DriverType.InternetExplorer:
                //    var internetExplorerOptions = new InternetExplorerOptions();
                //    if (useHeadless) { /* TODO: add options for IE to be in headless mode */ }
                //    _ngDriver = new InternetExplorerDriver(internetExplorerOptions);
                //    break;
                //case Globals.DriverType.MicrosoftEdge:
                //    var edgeOptions = new EdgeOptions();
                //    if (useHeadless) { /* TODO: add options for Edge to be in headless mode */ }
                //    _ngDriver = new EdgeDriver(edgeOptions);
                //    break;
                //case Globals.DriverType.Safari:
                //    var safariOptions = new SafariOptions();
                //    if (useHeadless) { /* TODO: add options for Safari to be in headless mode */ }
                //    _ngDriver = new SafariDriver(safariOptions);
                //    break;
                default:
                    _ngDriver = null;
                    break;
            }

            return _ngDriver;
        }

        public static void IgnoreManualTestingScenarios()
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("ignore")) { return; }
        }

        public static void TakeScreenshot(IWebDriver driver)
        {
            if (ScenarioContext.Current.TestError == null) return;

            try
            {
                var fileNameBase = $"Test_{FeatureContext.Current.FeatureInfo.Title.ToIdentifier()}_{ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier()}_{DateTime.Now:yyyyMMdd_HHmmss}";

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestScreenshots");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                if (driver is ITakesScreenshot takesScreenshot)
                {
                    var screenshot = takesScreenshot.GetScreenshot();
                    var screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");
                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
                    Console.WriteLine("Error Screenshot: ");
                    Console.WriteLine(new Uri(screenshotFilePath).AbsoluteUri);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while taking screenshot: {ex}");
            }
        }
    }
}
