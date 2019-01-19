using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Utility
{
    public class WebDriverExtensions
    {
        private readonly IWebDriver _driver;
        
        public WebDriverExtensions(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public void WaitForElement(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds <= 0) _driver.FindElement(by);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drv => drv.FindElement(by));
        }
        
        public IWebElement SafeFindElement(string selector)
        {
            try
            {
                return _driver.FindElement(By.CssSelector(selector));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        
        public IEnumerable<IWebElement> SafeFindElements(string selector)
        {
            return _driver.FindElements(By.CssSelector(selector));
        }
    }
}