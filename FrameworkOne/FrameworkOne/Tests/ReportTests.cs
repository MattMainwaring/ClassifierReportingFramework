using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkOne.Tests
{
    [TestClass]
    public class ReportTests : BaseTest
    {
        [TestInitialize]
        public void LoadPage()
        {
            Reports.GoTo();
        }

        [TestMethod]
        [Description("Clicks a report, asserts that the report is loaded.")]
        public void TCID1()
        {
            Reports.SupplierReportPanel.Click();
            Assert.IsTrue(Reports.SupplierReportContent.Displayed);
        }

        [TestMethod]
        [Description("Clicks the edit button on a report, asserts that the edit page is loaded.")]
        public void TCID2()
        {
            Reports.SupplierReportEditButton.Click();
            Assert.IsTrue(Reports.SupplierReportEditPageTitle.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'create new report' button, clicks the 'from template' button, asserts that the correct page loaded.")]
        public void TCID3()
        {
            Reports.CreateReportButton.Click();
            Reports.FromTemplateButton.Click();
            Assert.IsTrue(Reports.ReportTemplatesContainer.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'create new report' button, clicks the 'create new' button (palette icon), asserts that the correct page loaded.")]
        public void TCID4()
        {
            Reports.CreateReportButton.Click();
            Reports.PaletteButton.Click();
            Assert.IsTrue(Reports.NewReportWorkspace.Displayed);
        }

        [TestMethod]
        [Description("Clicks the search bar, then asserts that the extended search bar is displayed.")]
        public void TCID5()
        {
            Reports.TagFilterBar.Click();
            Assert.IsTrue(Reports.ExpandedTagFilterBar.Displayed);
        }
    }
}
