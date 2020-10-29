using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne
{
    public class Home : BasePage
    {
        public bool IsLoaded => Driver.FindElement(By.Id("recentContainer")).Displayed;
        public string MenuSize => Driver.FindElement(By.XPath("//div[@class='dx-drawer-panel-content']")).GetAttribute("style");
        public IWebElement ManageButton
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='dx-icon dx-icon-upload']")));
            }
        }
        public IWebElement PacksButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-product']"));
        public IWebElement RolesButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-group']"));
        public IWebElement DashboardsButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-hierarchy']"));
        public IWebElement ConnectionsButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-link']"));
        public IWebElement ReportsButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-contentlayout']"));
        public IWebElement MenuButton => Driver.FindElement(By.XPath("//div[@class='dx-button-content']"));
        public IWebElement AccountButton => Driver.FindElement(By.ClassName("dx-button-text"));
        public IWebElement LogOutButton => Driver.FindElement(By.XPath("//*[@class='dx-item-content dx-list-item-content'][contains(text(),'Logout')]"));

        public Home(IWebDriver driver) :base(driver) { }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/");
            Assert.IsTrue(IsLoaded, "HomePage was not loaded");
        }
    }
}