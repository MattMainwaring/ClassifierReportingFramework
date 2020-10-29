using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace FrameworkOne.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        protected Connections Connections { get; set; }
        protected Dashboards Dashboards { get; set; }
        protected Home Home { get; set; }
        protected Packs Packs { get; set; }
        protected Reports Reports { get; set; }
        protected Roles Roles { get; set; }
        protected Users Users { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            Dashboards = new Dashboards(Driver);
            Connections = new Connections(Driver);
            Home = new Home(Driver);
            Packs = new Packs(Driver);
            Reports = new Reports(Driver);
            Roles = new Roles(Driver);
            Users = new Users(Driver);

            Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Quit();
        }
    }
}