using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
     public class SeleniumTestContext
    {
        IWebDriver driver;
        public SeleniumTestContext(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void clickOnLinkText(String linkText)
        {
            IWebElement registerLink = driver.FindElement(By.LinkText(linkText));
            registerLink.Click();
            Sleep(3000);
        }
       
        public void clickOnButton(String buttonText)
        {
            IWebElement button = driver.FindElement(By.Name(buttonText));
            button.Click();
            Sleep(3000);
        }
        public void getText(String buttonText)
        {
            IWebElement button = driver.FindElement(By.Name(buttonText));
            button.Click();
            Sleep(5000);
        }
        public void EnterTextInTextField(String nameText,String textToEnter)
        {
            IWebElement textField;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
                textField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(nameText)));
                           
                textField.Clear();
                textField.SendKeys(textToEnter);
            }
            catch (Exception timeoutException) {
                
            }
            
        }
        public void selectValueFromDropdown(String dropdownId, String itemToBeSelected)
        {
            IWebElement webElement = driver.FindElement(By.Id(dropdownId));
            try
            {
               
                    SelectElement selectObject = new SelectElement(webElement);
                    selectObject.SelectByValue(itemToBeSelected);
                    Sleep(2000);
                  
             }
            catch (Exception timeoutException)
            {

            }

        }
        public void Sleep(int seconds)
        {
            try
            {
                Thread.Sleep(seconds);
            }
            catch(Exception exception)
            {
                exception.ToString();
            }
        }
    }
}
