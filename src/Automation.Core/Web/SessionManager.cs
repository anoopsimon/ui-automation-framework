using Automation.Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Core.Web
{
    public class SessionManager
    {
        private IWebDriver driver;
        bool useGrid;
        private string gridUrl;
        private Browser browser;
        public SessionManager(bool useGrid, string gridUrl,Browser browser)
        {
            this.useGrid = useGrid;
            this.gridUrl = gridUrl;
            this.browser = browser;
        }

        private void ValidateRemoteSessionProps() 
        {
            if (useGrid && string.IsNullOrEmpty(gridUrl)) throw new FrameworkException("A Grid URL must be specified to start a Remote WebDriver Session");
        }

        public IWebDriver CreateSession() 
        {
            if (useGrid) return RemoteSession();

             return LocalSession();
        }

        private IWebDriver RemoteSession()
        {
            ValidateRemoteSessionProps();
            switch (browser)
            {
                case Browser.CHROME:
                    this.driver= new RemoteWebDriver(new Uri(gridUrl), ChromeOptions());
                    return driver;
                default:
                    throw new FrameworkException($"{browser} support not implemented");
            }

        }

        private static ChromeOptions ChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--incognito");
            return options;
        }

        public IWebDriver LocalSession()
        {
            this.driver = new ChromeDriver(ChromeOptions()) ;
            return this.driver;
        }


        public DevToolsSession GetDevToolSesion()
        {
            return ((ChromeDriver)this.driver).GetDevToolsSession();
        }



    }
}
