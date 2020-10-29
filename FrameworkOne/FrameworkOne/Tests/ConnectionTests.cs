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
        [Description("Clicks the test connection and asserts that the correct page loaded.")]
        public void TCID1()
        {
            Connections.TestConnection.Click();
            Assert.IsTrue(Connections.TestConnectionContent.Displayed);
        }

        [TestMethod]
        [Description("Clicks the delete button and asserts that the confirmation message is displayed.")]
        public void TCID2()
        {
            Connections.DeleteButton.Click();
            Assert.IsTrue(Connections.DeleteConfirmationMessage.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'add new' button and asserts that the 'new connection' menu is displayed.")]
        public void TCID3()
        {
            Connections.NewConnectionButton.Click();
            Assert.IsTrue(Connections.NewConnectionMenuHeader.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'add new' button, fills out the fields, clicks save and asserts that the loading widget is displayed.")]
        public void TCID4()
        {
            Connections.CreateNewConnection("TestName", "TestServer", "TestDatabase");
            Assert.IsTrue(Connections.LoadingWidget.Displayed);
        }
    }
}
