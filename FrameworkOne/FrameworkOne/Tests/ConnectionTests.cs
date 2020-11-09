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
            Connections.TestConnectionPanel.Click();
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

        
    }
}
