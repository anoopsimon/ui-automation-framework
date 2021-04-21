using Automation.Core;
using Automation.Core.Enums;
using Automation.Core.Web;
using OpenQA.Selenium;
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
            //var session = new SessionManager(false,"",Browser.CHROME);
            var session = new SessionManager(true,"http://localhost:4444/wd/hub",Browser.CHROME);
            var driver= session.CreateSession();
            driver.Url = "https://www.bing.com/";
            //var address = session.GetDevToolSesion().EndpointAddress;
            //Console.WriteLine("address > " + address);
            var commands = new Commands(driver);
            commands.Type(By.CssSelector("#sb_form_q"),"automation");
            commands.Click(By.CssSelector("label[for='sb_form_go']"));
            
        }
    }
}
