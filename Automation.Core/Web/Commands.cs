using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Web
{
    public class Commands
    {
        private readonly IWebDriver driver;
        public Commands(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetElement(By locator) 
        {
            return driver.FindElement(locator);
        }
        
        public IEnumerable<IWebElement> GetElements(By locator) 
        {
            return driver.FindElements(locator);
        }

        public void Click(By locator) 
        {
            GetElement(locator).Click();
        }

        public void Type(By locator, string text)
        {
            GetElement(locator).SendKeys(text);
        }
    }
}
