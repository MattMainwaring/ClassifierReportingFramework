using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne.Pages
{
    public class ConnectionsPage : BasePage
    {
        #region booleans
        public bool IsLoaded
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("connectionsList"))).Displayed;
            }
        }
        #endregion

        #region checkboxes
        public IWebElement ServiceCredentialsCheckbox => Driver.FindElement(By.ClassName("dx-checkbox-icon"));
        #endregion

        #region fields
        public IWebElement NameField
        {
            get
            {
                var nameField = Driver.FindElements(By.ClassName("dx-texteditor-input"))[0];
                return Wait.Until(ExpectedConditions.ElementToBeClickable(nameField));
            }
        }
        public IWebElement ServerField
        {
            get
            {
                var serverField = Driver.FindElements(By.ClassName("dx-texteditor-input"))[1];
                return Wait.Until(ExpectedConditions.ElementToBeClickable(serverField));
            }
        }
        public IWebElement DatabaseField
        {
            get
            {
                var descField = Driver.FindElements(By.ClassName("dx-texteditor-input"))[2];
                return Wait.Until(ExpectedConditions.ElementToBeClickable(descField));
            }
        }
        public IWebElement UsernameField
        {
            get
            {
                var userField = Driver.FindElements(By.ClassName("dx-texteditor-input"))[3];
                return Wait.Until(ExpectedConditions.ElementToBeClickable(userField));
            }
        }
        public IWebElement PasswordField
        {
            get
            {
                var passField = Driver.FindElements(By.ClassName("dx-texteditor-input"))[4];
                return Wait.Until(ExpectedConditions.ElementToBeClickable(passField));
            }
        }
        public IWebElement ConnectionStringField
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-dx_placeholder='Connection String']")));
            }
        }
        #endregion

        #region buttons
        public IWebElement CustomStringButton
        {
            get
            {
                // We may need an explicit wait here that waits until 'dx-field-item-content dx-field-item-content-location-bottom' is not intercepting the click i.e. invisible or not there etc.
                // .ElementToBeClickable does not work on it's own, as the specified element becomes clickable before the intercepting element has gone away.
                // For now, Thread.Sleep seems most appropriate here.
                Thread.Sleep(200);
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dx-switch-wrapper")));
            }
        }
        public IWebElement NewConnectionButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-add']"));
        public IWebElement DeleteButton => Driver.FindElement(By.XPath("//a[@class='dx-link dx-link-delete dx-icon-trash dx-link-icon']"));
        public IWebElement NoDelete => Driver.FindElement(By.XPath("//span[@class='dx-button-text'][contains(text(),'No')]"));
        public IWebElement SaveButton => Driver.FindElement(By.XPath("//div[@aria-label='Save']"));
        #endregion

        #region misc
        public IWebElement TestConnectionPanel
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@role='gridcell'][contains(text(),'TestConnection')]")));
            }
        }
        public IWebElement DeleteConfirmationMessage
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dx-dialog-message'][contains(text(),'Are you sure you want to delete this record?')]")));
            }
        }
        public IWebElement LoadingWidget
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dx-loadpanel-indicator dx-loadindicator dx-widget']")));
            }
        }
        public IWebElement NameColumn => Driver.FindElement(By.Id("dx-col-1"));
        public IWebElement ConnectionColumn => Driver.FindElement(By.Id("dx-col-2"));
        public IWebElement SortUpArrow => Driver.FindElement(By.CssSelector(".dx-sort.dx-sort-up"));
        public IWebElement SortDownArrow => Driver.FindElement(By.CssSelector(".dx-sort.dx-sort-down"));
        public IWebElement NewConnectionMenuHeader => Driver.FindElement(By.XPath("//div[contains(text(),'New Connection')]"));
        public IWebElement ConnectionContent => Driver.FindElement(By.Id("devextreme0"));
        #endregion

        public ConnectionsPage(IWebDriver driver) : base(driver) { }

        internal void CreateNewConnection(string name, string server, string database, string user, string pass)
        {
            NewConnectionButton.Click();
            NameField.SendKeys(name);
            ServerField.SendKeys(server);
            DatabaseField.SendKeys(database);
            ServiceCredentialsCheckbox.Click();
            UsernameField.SendKeys(user);
            PasswordField.SendKeys(pass);
            SaveButton.Click();
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/Connections");
            Assert.IsTrue(IsLoaded, "Connections page was not loaded.");
        }
    }
}