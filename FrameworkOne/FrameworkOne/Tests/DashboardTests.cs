using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkOne.Tests
{
    [TestClass]
    public class DashboardTests : BaseTest
    {
        [TestInitialize]
        public void LoadPage()
        {
            Dashboards.GoTo();
        }
        
        [TestMethod]
        [Description("Clicks a dashboard, asserts that the correct dashboard is loaded.")]
        public void ViewTestDashboard()
        {
            Dashboards.TestDashboardPanel.Click();
            Assert.IsTrue(Dashboards.TestDashboardHeader.Displayed);
        }

        [TestMethod]
        [Description("Clicks the edit button on a dashboard panel, asserts that the edit page is loaded.")]
        public void EditTestDashboard()
        {
            Dashboards.TestDashboardEditButton.Click();
            Assert.IsTrue(Dashboards.TestDashboardEditPageTitle.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'create dashboard' button, asserts that the palette button (create new) is displayed.")]
        public void CreateDashboardMenu()
        {
            Dashboards.CreateDashboardButton.Click(); 
            Assert.IsTrue(Dashboards.PaletteButton.Displayed);
        }

        [TestMethod]
        [Description("Clicks the search bar at the top, asserts that search bar expands below.")]
        public void SearchBarExpanded()
        {
            Dashboards.TagFilterBar.Click();
            Assert.IsTrue(Dashboards.ExpandedTagFilterBar.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'create dashboard' button, asserts that the 'close menu' button is displayed, clicks the 'close menu' button, asserts that it's no longer displayed.")]
        public void CreateDashboardMenuClose()
        {
            Dashboards.CreateDashboardButton.Click();
            Assert.IsTrue(Dashboards.CloseMenuButton.Displayed);
            Dashboards.CloseMenuButton.Click();
            Assert.IsFalse(Dashboards.CloseMenuButton.Displayed);
        }
    }
}
