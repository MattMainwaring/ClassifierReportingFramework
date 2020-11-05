using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [Description("Clicks the test connection and asserts that the test connection content page is loaded.")]
        public void ViewTestConnection()
        {
            Connections.TestConnection.Click();
            Assert.IsTrue(Connections.TestConnectionContent.Displayed);
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
        [Description("")]
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
        [Description("Clicks the 'add new connection' button, fills out the text fields, clicks the save button and asserts that the loading widget is displayed.")]
        public void CreateAndSaveNewConnection()
        {
            Connections.CreateNewConnection("TestName", "TestServer", "TestDatabase");
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
            Connections.AllCheckbox.Click();
            Connections.CustomerCheckbox.Click();
            Connections.OrderCheckbox.Click();
            Connections.OrderItemCheckbox.Click();
            Connections.ProductCheckbox.Click();
            Connections.SupplierCheckbox.Click();
            Assert.IsTrue(Connections.AreAllChecked, "Not all checkboxes were checked.");
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
        public void ClickEachTab()
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
        public void ClickPermissionsTab ()
        {
            Connections.TestConnection.Click();
            Connections.PermissionsTab.Click();
            Assert.AreEqual(Connections.CurrentSection, "PERMISSIONS");
            Connections.ConnectionTab.Click();
            Assert.AreEqual(Connections.CurrentSection, "CONNECTION");
            Connections.DataTab.Click();
            Assert.AreEqual(Connections.CurrentSection, "DATA");
        }
    }
}
