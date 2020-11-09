using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne.Pages
{
    public class TestConnectionPage : BasePage
    {
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

        #region buttons
        public IWebElement DiscardChangesButton => Driver.FindElement(By.CssSelector(".dx-icon.dx-icon-edit-button-cancel"));
        public IWebElement SaveChangesButton => Driver.FindElement(By.CssSelector(".dx-icon.dx-icon-edit-button-save"));
        public IWebElement DoesNotContainButton => Driver.FindElement(By.CssSelector(".dx-icon.dx-icon-filter-operation-not-contains"));
        public IWebElement StartsWithButton => Driver.FindElement(By.CssSelector(".dx-icon.dx-icon-filter-operation-starts-with"));
        #endregion

        #region misc
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
        public IWebElement NoDataResult
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dx-datagrid-nodata")));
            }
        }
        public IWebElement CustomerPanel => Driver.FindElement(By.XPath("//td[contains(text(),'Customer')]"));
        public IWebElement OrderPanel => Driver.FindElement(By.XPath("//td[contains(text(),'Order')]"));
        public IWebElement OrderItemPanel => Driver.FindElement(By.XPath("//td[contains(text(),'OrderItem')]"));
        public IWebElement ProductPanel => Driver.FindElement(By.XPath("//td[contains(text(),'Product')]"));
        public IWebElement SupplierPanel => Driver.FindElement(By.XPath("//td[contains(text(),'Supplier')]"));
        public IWebElement PanelContainer => Driver.FindElement(By.CssSelector(".dx-datagrid.dx-gridbase-container"));
        #endregion

        public TestConnectionPage(IWebDriver driver) : base(driver) { }

        internal void ClickEachCheckbox()
        {
            CustomerCheckbox.Click();
            OrderCheckbox.Click();
            OrderItemCheckbox.Click();
            ProductCheckbox.Click();
            SupplierCheckbox.Click();
        }

        internal string NumberOfSearchResults()
        {
            return PanelContainer.GetAttribute("aria-rowcount");
        }
    }
}
