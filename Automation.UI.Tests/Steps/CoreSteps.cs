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
        [StepDefinition(@"I launch '(.*)' browser")]
        public void GivenILaunchBrowser(string browserName)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://wwww.bing.com";
            driver.Quit();
            string k = new AppSettings()["secrets:keyvault"];
            Console.WriteLine(k);
        }
    }
}
