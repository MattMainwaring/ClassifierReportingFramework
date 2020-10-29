using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne
{
    public class Packs : BasePage
    {
        public bool IsLoaded
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("importPackageContainer"))).Displayed;
            }
        }
        public string HighlightedText
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("dx-datagrid-search-text"))).Text;
            }
        }
        public IWebElement ExpandButton => Driver.FindElement(By.ClassName("dx-datagrid-group-closed"));
        public IWebElement ExpandedMenu
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@class='dx-row dx-row-lines dx-master-detail-row']")));
            }
        } // Needs ID
        public IWebElement SearchBar => Driver.FindElement(By.ClassName("dx-texteditor-input")); // Needs ID
        public IWebElement CheckBox
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='checkbox']")));
            }
        } // Needs ID
        public IWebElement DeleteButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-trash']"));
        public IWebElement DeleteConfirmationMessage
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Are you sure you want to delete this pack?')]")));
            }
        }

        public Packs(IWebDriver driver) : base(driver) { }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/Templates/Import");
            Assert.IsTrue(IsLoaded, "Roles page was not loaded.");
        }

        internal void Search(string searchText)
        {
            SearchBar.Click();
            SearchBar.SendKeys(searchText);
        }
    }
}