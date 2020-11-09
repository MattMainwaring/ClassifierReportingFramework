using FrameworkOne.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace FrameworkOne.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        protected ConnectionsPage Connections { get; set; }
        protected DashboardsPage Dashboards { get; set; }
        protected HomePage Home { get; set; }
        protected PacksPage Packs { get; set; }
        protected ReportsPage Reports { get; set; }
        protected RolesPage Roles { get; set; }
        protected UsersPage Users { get; set; }
        protected TestConnectionPage TestConnection { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            Dashboards = new DashboardsPage(Driver);
            Connections = new ConnectionsPage(Driver);
            Home = new HomePage(Driver);
            Packs = new PacksPage(Driver);
            Reports = new ReportsPage(Driver);
            Roles = new RolesPage(Driver);
            Users = new UsersPage(Driver);
            TestConnection = new TestConnectionPage(Driver);

            Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Quit();
        }
    }
}