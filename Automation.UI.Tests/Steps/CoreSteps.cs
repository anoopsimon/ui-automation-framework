using Automation.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Automation.UI.Tests.Steps
{
    [Binding]
    public class CoreSteps
    {
        public readonly AppSettings AppSettings;

        public CoreSteps()
        {
            AppSettings = new AppSettings();
        }
        [StepDefinition(@"I launch '(.*)' browser")]
        public void GivenILaunchBrowser(string browserName)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://wwww.bing.com";
            driver.Quit();
            string k = AppSettings["secrets:keyvault"];
            Console.WriteLine(k);
        }
    }
}
