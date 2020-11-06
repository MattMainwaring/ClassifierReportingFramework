using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace FrameworkOne.Tests
{
    [TestClass]
    public class ConnectionTests : BaseTest
    {
        [TestInitialize]
        public void LoadPage()
        {
            Connections.GoTo();
        }

        [TestMethod]
        [Description("Clicks the test connection and asserts that a connection content page is loaded.")]
        public void ViewTestConnection()
        {
            Connections.TestConnection.Click();
            Assert.IsTrue(Connections.ConnectionContent.Displayed);
        }

        [TestMethod]
        [Description("Clicks the delete button and asserts that the 'delete confirmation message' is displayed.")]
        public void DeleteConfirmation()
        {
            Connections.DeleteButton.Click();
            Assert.IsTrue(Connections.DeleteConfirmationMessage.Displayed);   
        }

        [TestMethod]
        [Description("Clicks the 'add new connection' button and asserts that the 'add new connection' menu is displayed.")]
        public void NewConnectionMenu()
        {
            Connections.NewConnectionButton.Click();
            Assert.IsTrue(Connections.NewConnectionMenuHeader.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'add new connection' button, clicks the 'custom string' slider, asserts that the connection string field is then displayed.")]
        public void CustomStringButton()
        {
            Connections.NewConnectionButton.Click();
            Connections.CustomStringButton.Click();
            Assert.IsTrue(Connections.ConnectionStringField.Displayed);
        }

        [TestMethod]
        [Description("Clicks the name column twice, asserting each time that the correct arrow icon is displayed (showing which way the connections are sorted).")]
        public void NameColumnSorting()
        {
            Connections.NameColumn.Click();
            Assert.IsTrue(Connections.SortUpArrow.Displayed);
            Connections.NameColumn.Click();
            Assert.IsTrue(Connections.SortDownArrow.Displayed);
        }

        [TestMethod]
        [Description("Clicks the connection column twice, asserting each time that the correct arrow icon is displated (showing which way the connections are sorted).")]
        public void ConnectionColumnSorting()
        {
            Connections.ConnectionColumn.Click();
            Assert.IsTrue(Connections.SortUpArrow.Displayed);
            Connections.ConnectionColumn.Click();
            Assert.IsTrue(Connections.SortDownArrow.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'add new connection' button, fills out the text fields, clicks the 'use service credentials' checkbox, fills out the username/password fields, clicks the save button and asserts that the loading widget is displayed.")]
        public void CreateAndSaveNewConnection()
        {
            Connections.CreateNewConnection("TestName", "TestServer", "TestDatabase", "TestUsername", "TestPassword");
            Assert.IsTrue(Connections.LoadingWidget.Displayed);
        }

        [TestMethod]
        [Description("Clicks the test connection, clicks the 'all' checkbox twice, each time asserting that all checkboxes were checked and not checked.")]
        public void ClickAllCheckboxInTables()
        {
            Connections.TestConnection.Click();

            Connections.AllCheckbox.Click();
            Assert.IsFalse(Connections.AreAllChecked);
            Connections.AllCheckbox.Click();
            Assert.IsTrue(Connections.AreAllChecked);
        }

        [TestMethod]
        [Description("Clicks the test connection, clicks the 'all' checkbox, clicks each individual checkbox, asserts they are all checked.")]
        public void ClickEachCheckboxInTables()
        {
            Connections.TestConnection.Click();

            Connections.ClickEachCheckbox();
            Assert.IsFalse(Connections.AreAllChecked);
            Connections.ClickEachCheckbox();
            Assert.IsTrue(Connections.AreAllChecked, "Not all checkboxes were checked.");
        }

        [TestMethod]
        [Description("Checks to see if the 'discard changes' button works by un-ticking a checkbox and discarding the change via the 'discard changes' button, whilst asserting each time whether all checkboxes are checked or not.")]
        public void DiscardChangesButton()
        {
            Connections.TestConnection.Click();

            Connections.OrderItemCheckbox.Click();
            Assert.IsFalse(Connections.AreAllChecked);
            Connections.DiscardChangesButton.Click();
            Assert.IsTrue(Connections.AreAllChecked);
        }

        [TestMethod]
        [Description("Checks to see if the 'save changes' button works by un-ticking and ticking a checkbox, each time clicking 'save changes', refreshing the page and asserting whether all checkboxes are checked/not checked.")]
        public void SaveChangesButton()
        {
            Connections.TestConnection.Click();

            Connections.SupplierCheckbox.Click();
            Connections.SaveChangesButton.Click();
            Driver.Navigate().Refresh();
            Assert.IsFalse(Connections.AreAllChecked);

            Connections.SupplierCheckbox.Click();
            Connections.SaveChangesButton.Click();
            Driver.Navigate().Refresh();
            Assert.IsTrue(Connections.AreAllChecked);
        }

        [TestMethod]
        [Description("Clicks the test connection and asserts that the tabs selected by default are 'data' and 'tables'.")]
        public void CheckDefaultTabs()
        {
            Connections.TestConnection.Click();
            Assert.AreEqual(Connections.CurrentSection, "DATA");
            Assert.AreEqual(Connections.CurrentTab, "TABLES");
        }
        [TestMethod]
        [Description("Clicks the test connection, clicks each individual sub-tab (under the data tab), each time asserting that the correct tab was selected.")]
        public void ClickEachSubTab()
        {
            Connections.TestConnection.Click();
            Connections.ViewsTab.Click();
            Assert.AreEqual(Connections.CurrentTab, "VIEWS");
            Connections.ProceduresTab.Click();
            Assert.AreEqual(Connections.CurrentTab, "PROCEDURES");
            Connections.TablesTab.Click();
            Assert.AreEqual(Connections.CurrentTab, "TABLES");
        }

        [TestMethod]
        [Description("Clicks the test connection, clicks each individual upper-tab, each time asserting that the correct tab was selected.")]
        public void ClickEachUpperTab ()
        {
            Connections.TestConnection.Click();
            Connections.PermissionsTab.Click();
            Assert.AreEqual(Connections.CurrentSection, "PERMISSIONS");
            Connections.ConnectionTab.Click();
            Assert.AreEqual(Connections.CurrentSection, "CONNECTION");
            Connections.DataTab.Click();
            Assert.AreEqual(Connections.CurrentSection, "DATA");
        }

        [TestMethod]
        [Description("Clicks the test connection, clicks the search field, searches for a specific string, asserts that the element we are expecting is displayed once the search has completed.")]
        public void SearchFieldResults()
        {
            Connections.TestConnection.Click();
            Connections.SearchField.Click();
            Connections.SearchField.SendKeys("product");
            Assert.IsTrue(Connections.ProductOption.Displayed); // check ProductOption for more info
        }

        [TestMethod]
        [Description("Clicks the test connection, clicks the search field, searches for a specific string (that we know there are no results for), asserts that no 'no data' result is displayed once the search has completed.")]
        public void SearchFieldNoResults()
        {
            Connections.TestConnection.Click();
            Connections.SearchField.Click();
            Connections.SearchField.SendKeys("no result");
            Assert.IsTrue(Connections.NoDataResult.Displayed);
        }

        [TestMethod]
        [Description("")]
        public void RenameMe()
        {
            Connections.TestConnection.Click();
            Connections.SearchIcon.Click();
            
        }
    }
}
