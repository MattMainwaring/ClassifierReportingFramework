using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne
{
    public class Users : BasePage
    {
        public bool IsLoaded => Driver.FindElement(By.Id("userList")).Displayed;
        public IWebElement UserAdministrator => Driver.FindElement(By.XPath("//td[contains(text(),'administrator')]"));
        public IWebElement AvailablePermissionsPanel => Driver.FindElement(By.Id("availbalePermissionGroups"));
        public IWebElement NewUserButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-add']"));
        public IWebElement NewUserPageHeader => Driver.FindElement(By.XPath("//div[contains(text(),'New User')]"));
        public IWebElement LookupField => Driver.FindElement(By.Id("addNewUserLookup"));
        public IWebElement SearchIcon => Driver.FindElement(By.XPath("//div[@class='dx-icon dx-icon-search']"));
        public IWebElement Checkbox5
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@aria-rowindex='5']//div[@role='checkbox']")));
            }
        }
        public IWebElement DeleteButton => Driver.FindElement(By.CssSelector("a[title='Delete']"));
        public IWebElement DeleteConfirmationMessage
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Are you sure you want to delete this record?')]")));
            }
        }

        public Users(IWebDriver driver) : base(driver) { }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/Permissions/Users");
            Assert.IsTrue(IsLoaded, "Users page was not loaded.");
        }
    }
}
