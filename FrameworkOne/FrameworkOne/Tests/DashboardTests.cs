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
        [Description("Clicks a dashboard, asserts that the dashboard loaded.")]
        public void TCID1()
        {
            Dashboards.TestDashboardPanel.Click();
            Assert.IsTrue(Dashboards.TestDashboardHeader.Displayed);
        }

        [TestMethod]
        [Description("Clicks the edit button on a dashboard, asserts that the edit page loaded.")]
        public void TCID2()
        {
            Dashboards.TestDashboardEditButton.Click();
            Assert.IsTrue(Dashboards.TestDashboardEditPageTitle.Displayed);
        }

        [TestMethod]
        [Description("Clicks the create button in the top right, asserts that the palette button is visible in the drop-down menu.")]
        public void TCID3()
        {
            Dashboards.CreateDashboardButton.Click(); 
            Assert.IsTrue(Dashboards.PaletteButton.Displayed);
        }

        [TestMethod]
        [Description("Clicks the search bar at the top, asserts that search bar expands below.")]
        public void TCID4()
        {
            Dashboards.TagFilterBar.Click();
            Assert.IsTrue(Dashboards.ExpandedTagFilterBar.Displayed);
        }
    }
}
