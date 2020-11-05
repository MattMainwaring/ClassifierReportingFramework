using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
                    if (Driver.FindElement(By.XPath("//div[@class='dx-datagrid-checkbox-size dx-show-invalid-badge dx-checkbox dx-widget']")).Enabled == true)
                    {
                        return false;
                        // We use XPath here because the CssSelector equivalent will find all classes that contain our specified class-name, where-as XPath finds ONLY exact matches.
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
        #endregion

        #region misc
        public IWebElement TestConnection
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@role='gridcell'][contains(text(),'TestConnection')]")));
            }
        }
        public IWebElement TestConnectionContent => Driver.FindElement(By.Id("devextreme0"));
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
        public IWebElement SortUpArrow => Driver.FindElement(By.CssSelector(".dx-sort.dx-sort-up"));
        public IWebElement SortDownArrow => Driver.FindElement(By.CssSelector(".dx-sort.dx-sort-down"));
        #endregion

        public Connections(IWebDriver driver) : base(driver) { }

        internal void CreateNewConnection(string name, string server, string database)
        {
            NewConnectionButton.Click();
            NameField.SendKeys(name);
            ServerField.SendKeys(server);
            DatabaseField.SendKeys(database);
            SaveButton.Click();
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/Connections");
            Assert.IsTrue(IsLoaded, "Connections page was not loaded.");
        }
    }
}