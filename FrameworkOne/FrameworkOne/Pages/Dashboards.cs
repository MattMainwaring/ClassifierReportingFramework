using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne
{
    public class Dashboards : BasePage
    {
        public bool IsLoaded
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("bj-dashboards-Container"))).Displayed;
            }
        }
        public IWebElement HomeIcon => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-home']"));
        public IWebElement TestDashboardPanel => Driver.FindElement(By.Id("Test Dashboard"));
        public IWebElement TestDashboardHeader 
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dx-dashboard-ellipsis'][contains(text(),'Test Dashboard')]")));
            }
        }
        public IWebElement TestDashboardEditButton => Driver.FindElement(By.Id("devextreme4"));
        public IWebElement TestDashboardEditPageTitle => Driver.FindElement(By.XPath("//div[@class='bj-page-header'][contains(text(),'Order Country of Orgin Dashboard')]"));
        public IWebElement CreateDashboardButton => Driver.FindElement(By.ClassName("dx-fa-button-icon"));
        public IWebElement PaletteButton
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@class='dx-icon dx-icon-palette']")));
            }
        }
        public IWebElement TagFilterBar => Driver.FindElement(By.Id("dashboardFilterForm"));
        public IWebElement ExpandedTagFilterBar => Driver.FindElement(By.ClassName("dx-popup-content"));
        public IWebElement CloseMenuButton => Driver.FindElement(By.CssSelector(".dx-icon.dx-icon-close"));

        public Dashboards(IWebDriver driver) : base(driver) { }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/Dashboards");
            Assert.IsTrue(IsLoaded, "Dashboards page was not loaded");
        }
    }
}