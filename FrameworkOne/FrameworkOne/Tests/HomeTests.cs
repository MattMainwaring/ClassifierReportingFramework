﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [Description("Clicks the Dashboards button and asserts that the dashboards was loaded.")]
        public void LoadDashboardsPage()
        {
            Home.DashboardsButton.Click();
            Assert.IsTrue(Dashboards.IsLoaded);
        }

        [TestMethod]
        [Description("Clicks the Reports button and asserts that the reports page was loaded.")]
        public void LoadsReportsPage()
        {
            Home.ReportsButton.Click();
            Assert.IsTrue(Reports.IsLoaded);
        }

        [TestMethod]
        [Description("Clicks the Packs button, clicks the Manage button and asserts that the packs page was loaded.")]
        public void LoadPacksPage()
        {
            Home.PacksButton.Click();
            Home.ManageButton.Click();
            Assert.IsTrue(Packs.IsLoaded);
        }

        [TestMethod]
        [Description("Clicks the Roles button and asserts that the roles page was loaded.")]
        public void LoadRolesPage()
        {
            Home.RolesButton.Click();
            Assert.IsTrue(Roles.IsLoaded);
        }

        [TestMethod]
        [Description("Clicks the Connections button and asserts that the connections page was loaded.")]
        public void LoadConnectionsPage()
        {
            Home.ConnectionsButton.Click();
            Assert.IsTrue(Connections.IsLoaded);
        }

        [TestMethod]
        [Description("Asserts that the navigation-menu changes size when clicking the hide/expand button.")]
        public void NavigationMenuResize()
        {
            var currentMenuSize = Home.MenuSize;
            Home.MenuButton.Click();
            var newMenuSize = Home.MenuSize;
            Assert.AreNotEqual(currentMenuSize, newMenuSize,
                "The menu size does not change when clicking the hide/expand button.");
        }

        [TestMethod]
        [Description("Clicks the Account button and asserts that the Logout option is displayed.")]
        public void AccountButtonLogout()
        {
            Home.AccountButton.Click();
            Assert.IsTrue(Home.LogOutButton.Displayed);
        }
    }
}
