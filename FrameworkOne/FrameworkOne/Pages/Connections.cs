using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne
{
    public class Connections : BasePage
    {
        #region booleans
        public bool IsLoaded
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("connectionsList"))).Displayed;
            }
        }
        public bool AreAllChecked
        { 
            get
            {
                try
                {
                    Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("devextreme0")));
                    if (Driver.FindElement(By.XPath("//input[@value='false']")).Enabled == true)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }   
                }
                catch { return true; }
            }
        }
        #endregion

        #region strings
        public string CurrentSection => Driver.FindElements(By.CssSelector(".dx-item.dx-tab.dx-tab-selected span"))[0].Text;
        public string CurrentTab => Driver.FindElements(By.CssSelector(".dx-item.dx-tab.dx-tab-selected span"))[1].Text;
        #endregion

        #region checkboxes
        public IWebElement AllCheckbox
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dx-checkbox-icon")));
            }
        }
        public IWebElement CustomerCheckbox
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AllCheckbox));
                return Driver.FindElements(By.CssSelector(".dx-datagrid-checkbox-size.dx-show-invalid-badge.dx-checkbox.dx-widget"))[0];
            }
        }
        public IWebElement OrderCheckbox
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AllCheckbox));
                return Driver.FindElements(By.CssSelector(".dx-datagrid-checkbox-size.dx-show-invalid-badge.dx-checkbox.dx-widget"))[1];
            }
        }
        public IWebElement OrderItemCheckbox
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AllCheckbox));
                return Driver.FindElements(By.CssSelector(".dx-datagrid-checkbox-size.dx-show-invalid-badge.dx-checkbox.dx-widget"))[2];
            }
        }
        public IWebElement ProductCheckbox
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AllCheckbox));
                return Driver.FindElements(By.CssSelector(".dx-datagrid-checkbox-size.dx-show-invalid-badge.dx-checkbox.dx-widget"))[3];
            }
        }
        public IWebElement SupplierCheckbox
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(AllCheckbox));
                return Driver.FindElements(By.CssSelector(".dx-datagrid-checkbox-size.dx-show-invalid-badge.dx-checkbox.dx-widget"))[4];
            }
        }
        public IWebElement ServiceCredentialsCheckbox => Driver.FindElement(By.ClassName("dx-checkbox-icon"));
        #endregion

        #region tabs
        public IWebElement ProceduresTab
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='dx-item dx-tab']//span[contains(text(),'Procedures')]")));
            }
        }
        public IWebElement TablesTab
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='dx-item dx-tab']//span[contains(text(),'Tables')]")));
            }
        }
        public IWebElement ViewsTab
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='dx-item dx-tab']//span[contains(text(),'Views')]")));
            }
        }
        public IWebElement PermissionsTab => Driver.FindElement(By.XPath("//div[@class='dx-item dx-tab']//span[contains(text(),'Permissions')]"));
        public IWebElement ConnectionTab => Driver.FindElement(By.XPath("//div[@class='dx-item dx-tab']//span[contains(text(),'Connection')]"));
        public IWebElement DataTab => Driver.FindElement(By.XPath("//div[@class='dx-item dx-tab']//span[contains(text(),'Data')]"));
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
        public IWebElement NewConnectionButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-add']"));
        public IWebElement DeleteButton => Driver.FindElement(By.XPath("//a[@class='dx-link dx-link-delete dx-icon-trash dx-link-icon']"));
        public IWebElement NoDelete => Driver.FindElement(By.XPath("//span[@class='dx-button-text'][contains(text(),'No')]"));
        public IWebElement SaveButton => Driver.FindElement(By.XPath("//div[@aria-label='Save']"));
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
        public IWebElement DiscardChangesButton => Driver.FindElement(By.CssSelector(".dx-icon.dx-icon-edit-button-cancel"));
        public IWebElement SaveChangesButton => Driver.FindElement(By.CssSelector(".dx-icon.dx-icon-edit-button-save"));
        #endregion

        #region misc
        public IWebElement TestConnection
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@role='gridcell'][contains(text(),'TestConnection')]")));
            }
        }
        public IWebElement ConnectionContent => Driver.FindElement(By.Id("devextreme0"));
        public IWebElement DeleteConfirmationMessage
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dx-dialog-message'][contains(text(),'Are you sure you want to delete this record?')]")));
            }
        }
        public IWebElement NewConnectionMenuHeader => Driver.FindElement(By.XPath("//div[contains(text(),'New Connection')]"));
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
        public IWebElement SearchIcon
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dx-icon.dx-icon-filter-operation-default")));
            }
        }
        public IWebElement SearchField
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@aria-describedby='dx-col-1']")));
            }
        }
        public IWebElement ProductOption
        {
            get
            {
                // Thread.Sleep is currently the best solution here because there is NO element we can attach an explicit wait to, to know when ONLY search results are being displayed.
                // This is somewhat brittle because if search results take longer than 1 second to process, the test will always pass (regardless of results).
                Thread.Sleep(1000);
                return Driver.FindElement(By.XPath("//td[contains(text(),'Product')]"));
            }
        }
        public IWebElement NoDataResult
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dx-datagrid-nodata")));
            }
        }
        #endregion

        public Connections(IWebDriver driver) : base(driver) { }

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

        internal void ClickEachCheckbox()
        {
            CustomerCheckbox.Click();
            OrderCheckbox.Click();
            OrderItemCheckbox.Click();
            ProductCheckbox.Click();
            SupplierCheckbox.Click();
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/Connections");
            Assert.IsTrue(IsLoaded, "Connections page was not loaded.");
        }
    }
}