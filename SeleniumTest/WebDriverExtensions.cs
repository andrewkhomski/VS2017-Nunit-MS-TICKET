using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    public static class WebDriverExtensions
    {
        //executes javascript
        public static IJavaScriptExecutor Scripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }

        /// <summary>
        /// Javascript execution method
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="script">javasctipt to execute</param>
        public static void ExecuteScript(this IWebDriver driver, String script)
        {
            driver.Scripts().ExecuteScript(script);
        }

        /// <summary>
        /// Checks to see if given element is displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by">Target element (By.XPath/By.CssSelector/By.Id)</param>
        /// <returns>True if element displayed, False if element is not displayed</returns>
        public static Boolean ElementIsDisplayed(this IWebDriver driver, By by)
        {
            return driver.FindElement(by).Displayed;
        }
        
        /// <summary>
        /// Enable or change driver default implicit wait
        /// Driver will wait for upto this time for a target element to be displayed
        /// </summary>
        /// <param name="driver"></param>
        public static void EnableImplicitWait(this IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// Disable default driver implicit wait
        /// </summary>
        /// <param name="driver"></param>
        public static void DisableImplicitWait (this IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
        }

        /// <summary>
        /// IE time delay for all actions, the driver executes actions too qickly and seemingly out of order at times...
        /// </summary>
        /// <param name="driver"></param> 
        public static void TimeDelay(this IWebDriver driver)
        {
            driver.Sleep(TimeSpan.FromMilliseconds(90));
        }

        /// <summary>
        /// Scroll to element on page using By selector
        /// </summary>
        /// <param name="driver">Selenium driver</param>
        /// <param name="by">Find elements By selection method (i.e. By.CssSelector("id=123")</param>
        public static void ScrollToElement(this IWebDriver driver, By by)
        {
            IWebElement element;
            element = driver.FindElement(by);
            ScrollToElement(driver, element);
        }
        
        /// <summary>
        /// Scrolls to givent element by javascript; IE needed this to click buttons
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element">target element</param>
        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {                        
            driver.Scripts().ExecuteScript("arguments[0].scrollIntoView(true);", element);
            driver.Sleep(1);
        }

        /// <summary>
        /// System Threading Thread Sleep command extended to driver for simplicity
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="seconds">Number for seconds to wait</param>
        public static void Sleep(this IWebDriver driver, int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }
        public static void Sleep(this IWebDriver driver, TimeSpan seconds)
        {
            System.Threading.Thread.Sleep(seconds);
        }

        /// <summary>
        /// Waits for element to be visible By selector string
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="selector"></param>
        public static void WaitForElement(this IWebDriver driver, string selector)
        {
            driver.WaitForElement(By.CssSelector(selector));
        }

        /// <summary>
        /// Waits for element to be visible By by input method (CssSelector,Xpath,ID)
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        public static void WaitForElement(this IWebDriver driver, By by)
        {
            try
            {
                if (driver.FindElement(by).Displayed)
                    return;
            }
            catch (Exception)
            {
                try
                {
                    // If element is not visible, wait for it to become visible
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                    wait.Until(ExpectedConditions.ElementIsVisible(by));

                    driver.Sleep(1);
                }
                catch (Exception) { }
            }
        }

    }
}
