using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ClassLibrary1;
using Xunit;
using System.Threading;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using ClassLibrary1.Utility;

namespace AppUITests
{
    public class ApplicationContext

    {
        IWebDriver driver;
        protected SeleniumTestContext seleniumTestContext;
        protected UserData testData;
        [Fact]
        public void LaunchApplicationPage()
        {
            String applicationUrl = ConfigurationManager.AppSettings["url"];
            driver = GetDriverType();
            driver.Navigate().GoToUrl(applicationUrl);
            driver.Manage().Window.Maximize();
            seleniumTestContext = new SeleniumTestContext(this.driver);
            testData = TestDataAccess.GetTestData("SignUp");
            Sleep(3000);
        }

        public IWebDriver GetDriverType()
        {
            IWebDriver webDriver = null;
            String browserDriver = ConfigurationManager.AppSettings["browser"];

            if (browserDriver.Equals("chrome"))
            {
                webDriver = new ChromeDriver();
            }
            else if (browserDriver.Equals("Firefox"))
            {
                webDriver = new FirefoxDriver();
            }
            return webDriver;
        }

        public IWebDriver getDriver()
        {
            return driver;
        }
        
        public void Sleep(int seconds)
        {
            try
            {
                Thread.Sleep(seconds);
            }
            catch (Exception exception)
            {
                exception.ToString();
            }
        }
        public void closeSession()
        {
            driver.Quit();
        }
    }
}
