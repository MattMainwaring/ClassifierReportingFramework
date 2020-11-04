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
        [Description("Clicks the test connection and asserts that the test connection content page is loaded.")]
        public void ViewTestConnection()
        {
            Connections.TestConnection.Click();
            Assert.IsTrue(Connections.TestConnectionContent.Displayed);
        }

        [TestMethod]
        [Description("Clicks the delete button and asserts that the 'delete confirmation message' is displayed.")]
        public void DeleteButtonConfirmation()
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
        public void SaveNewConnection()
        {
            Connections.CreateNewConnection("TestName", "TestServer", "TestDatabase");
            Assert.IsTrue(Connections.LoadingWidget.Displayed);
        }

        [TestMethod]
        [Description("Clicks the test connection, clicks the 'all' checkbox twice, each time asserting that all checkboxes were checked and not checked.")]
        public void AllCheckbox()
        {
            Connections.TestConnection.Click();
            Connections.AllCheckbox.Click();
            Assert.IsFalse(Connections.AreAllChecked);
            Connections.AllCheckbox.Click();
            Assert.IsTrue(Connections.AreAllChecked);
        }

        [TestMethod]
        [Description("Clicks the test connection, clicks the 'all' checkbox, clicks each individual checkbox, asserts they are all checked.")]
        public void EachCheckbox()
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
        [Description("")]
        public void CurrentTabTables()
        {
            Connections.TestConnection.Click();
            Assert.AreEqual(Connections.CurrentTab, "TABLES");
        }
        [TestMethod]
        [Description("")]
        public void CurrentTabViews()
        {
            Connections.TestConnection.Click();
            Connections.ViewsTab.Click();
            Assert.AreEqual(Connections.CurrentTab, "VIEWS");
        }

        [TestMethod]
        [Description("")]
        public void CurrentTabProcedures()
        {
            Connections.TestConnection.Click();
            Connections.ProceduresTab.Click();
            Assert.AreEqual(Connections.CurrentTab, "PROCEDURES");
        }

        [TestMethod]
        [Description("")]
        public void NewTest ()
        {

        }
    }
}
