using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne
{
    public class Roles : BasePage
    {
        public bool IsLoaded
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("permissionsGroupsList"))).Displayed;
            }
        }
        public bool AreRolesSorted
        {
            get
            {
                try
                {
                    var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(300));
                    return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@aria-rowindex='1']//td[contains(text(),'Document Author Role')]"))).Displayed;
                }
                catch 
                {
                    return false;
                }
            }
        }
        public IWebElement DropDownMenu => Driver.FindElement(By.ClassName("dx-dropdowneditor-icon"));
        public IWebElement UsersOption => Driver.FindElement(By.XPath("//div[@class='dx-item-content dx-list-item-content'][contains(text(),'Users')]"));
        public IWebElement SystemManagerRole => Driver.FindElement(By.XPath("//tr[@class='dx-row dx-data-row dx-row-lines'][@aria-rowindex='4']"));
        public IWebElement SystemManagerRoleContent
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("devextreme1")));
            }
        }
        public IWebElement DescriptionColumn => Driver.FindElement(By.Id("dx-col-2"));
        public IWebElement NameColumn => Driver.FindElement(By.Id("dx-col-1"));
        public IWebElement NewRoleButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-add']"));
        public IWebElement NewRoleMenuHeader => Driver.FindElement(By.XPath("//div[contains(text(),'New Role')]"));

        public Roles(IWebDriver driver) : base(driver) { }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/Permissions/Roles");
            Assert.IsTrue(IsLoaded, "Roles page was not loaded.");
        }
    }
}