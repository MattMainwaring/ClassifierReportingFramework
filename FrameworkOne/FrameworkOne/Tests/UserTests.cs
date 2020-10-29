using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkOne.Tests
{
    [TestClass]
    public class UserTests : BaseTest
    {
        [TestInitialize]
        public void LoadPage()
        {
            Users.GoTo();
        }

        [TestMethod]
        [Description("Clicks on a user, asserts that the available permissions page loaded.")]
        public void TCID1()
        {
            Users.UserAdministrator.Click();
            Assert.IsTrue(Users.AvailablePermissionsPanel.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'add new user' button, asserts that the lookup field is displayed.")]
        public void TCID2()
        {
            Users.NewUserButton.Click();
            Assert.IsTrue(Users.NewUserPageHeader.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'add new user' button, clicks the lookup field, asserts that the search icon is displayed.")]
        public void TCID3()
        {
            Users.NewUserButton.Click();
            Users.LookupField.Click();
            Assert.IsTrue(Users.SearchIcon.Displayed);
        }

        [TestMethod]
        [Description("")]
        public void TCID4()
        {
            Users.UserAdministrator.Click();
            Users.Checkbox5.Click();
            Assert.AreEqual(Users.Checkbox5.GetAttribute("aria-checked"), "true");
        }
    }
}
