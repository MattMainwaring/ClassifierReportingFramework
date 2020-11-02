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
        [Description("Clicks the 'add new connection' button, fills out the text fields, clicks the save button and asserts that the loading widget is displayed.")]
        public void SaveNewConnection()
        {
            Connections.CreateNewConnection("TestName", "TestServer", "TestDatabase");
            Assert.IsTrue(Connections.LoadingWidget.Displayed);
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
    }
}
