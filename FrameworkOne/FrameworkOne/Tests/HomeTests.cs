using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkOne.Tests
{
    [TestClass]
    public class HomePageTests : BaseTest
    {
        [TestInitialize]
        public void LoadPage()
        {
            Home.GoTo();
        }

        [TestMethod]
        [Description("Clicks the Dashboards button and asserts that the correct page was loaded.")]
        public void TCID1()
        {
            Home.DashboardsButton.Click();
            Assert.IsTrue(Dashboards.IsLoaded);
        }

        [TestMethod]
        [Description("Clicks the Reports button and asserts that the correct page was loaded.")]
        public void TCID2()
        {
            Home.ReportsButton.Click();
            Assert.IsTrue(Reports.IsLoaded);
        }

        [TestMethod]
        [Description("Clicks the Packs button, clicks the Manage button and asserts that the correct page was loaded.")]
        public void TCID3()
        {
            Home.PacksButton.Click();
            Home.ManageButton.Click();
            Assert.IsTrue(Packs.IsLoaded);
        }

        [TestMethod]
        [Description("Clicks the Roles button and asserts that the correct page was loaded.")]
        public void TCID4()
        {
            Home.RolesButton.Click();
            Assert.IsTrue(Roles.IsLoaded);
        }

        [TestMethod]
        [Description("Clicks the Connections button and asserts that the correct page was loaded.")]
        public void TCID5()
        {
            Home.ConnectionsButton.Click();
            Assert.IsTrue(Connections.IsLoaded);
        }

        [TestMethod]
        [Description("Asserts that the navigation-menu size changes when clicking the hide/expand button.")]
        public void TCID6()
        {
            var currentMenuSize = Home.MenuSize;
            Home.MenuButton.Click();
            var newMenuSize = Home.MenuSize;
            Assert.AreNotEqual(currentMenuSize, newMenuSize,
                "The menu size does not change when clicking the hide/expand button.");
        }

        [TestMethod]
        [Description("Clicks the Account button and asserts that the Logout button is displayed.")]
        public void TCID7()
        {
            Home.AccountButton.Click();
            Assert.IsTrue(Home.LogOutButton.Displayed);
        }
    }
}
