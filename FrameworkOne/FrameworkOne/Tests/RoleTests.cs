using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkOne.Tests
{
    [TestClass]
    public class RoleTests : BaseTest
    {
        [TestInitialize]
        public void LoadPage()
        {
            Roles.GoTo();
        }

        [TestMethod]
        [Description("Clicks the drop-down menu, clicks the Users option, asserts that the Users page has loaded.")]
        public void TCID1()
        {
            Roles.DropDownMenu.Click();
            Roles.UsersOption.Click();
            Assert.IsTrue(Users.IsLoaded);
        }

        [TestMethod]
        [Description("Clicks the system manager role, asserts that the correct page is displayed.")]
        public void TCID2()
        {
            Roles.SystemManagerRole.Click();
            Assert.IsTrue(Roles.SystemManagerRoleContent.Displayed);
        }  

        [TestMethod]
        [Description("Clicks the description column and asserts that the roles were sorted.")]
        public void TCID3()
        {
            Assert.IsFalse(Roles.AreRolesSorted);
            Roles.DescriptionColumn.Click();
            Assert.IsTrue(Roles.AreRolesSorted);
        }

        [TestMethod]
        [Description("Clicks the name column and asserts that the roles were sorted.")]
        public void TCID4()
        {
            Assert.IsFalse(Roles.AreRolesSorted);
            Roles.NameColumn.Click();
            Assert.IsTrue(Roles.AreRolesSorted);
        }

        [TestMethod]
        [Description("Clicks the 'add new role' button, asserts that the new role menu is displayed.")]
        public void TCID5()
        {
            Roles.NewRoleButton.Click();
            Assert.IsTrue(Roles.NewRoleMenuHeader.Displayed);
        }
    }
}
