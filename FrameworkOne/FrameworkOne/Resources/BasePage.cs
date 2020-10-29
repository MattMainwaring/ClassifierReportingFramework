using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FrameworkOne
{
    public class BasePage
    {
        protected IWebDriver Driver;

        protected WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}