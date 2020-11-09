using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne.Pages
{
    public class PacksPage : BasePage
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
        public IWebElement ExpandButton
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("dx-datagrid-group-closed")));
            }
        }
        public IWebElement ExpandedMenu
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@class='dx-row dx-row-lines dx-master-detail-row']")));
            }
        } 
        public IWebElement SearchBar => Driver.FindElement(By.ClassName("dx-texteditor-input")); 
        public IWebElement CheckBox
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@role='checkbox']")));
            }
        } 
        public IWebElement DeleteButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-trash']"));
        public IWebElement DeleteConfirmationMessage
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Are you sure you want to delete this pack?')]")));
            }
        }
        public IWebElement PackNameColumn => Driver.FindElement(By.Id("dx-col-3"));
        public IWebElement SortUpArrow => Driver.FindElement(By.CssSelector(".dx-sort.dx-sort-up"));
        public IWebElement SortDownArrow => Driver.FindElement(By.CssSelector(".dx-sort.dx-sort-down"));

        public PacksPage(IWebDriver driver) : base(driver) { }

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