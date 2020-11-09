using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace FrameworkOne.Tests
{
    [TestClass]
    public class TestConnectionTests : BaseTest
    {
        [TestInitialize]
        public void LoadTestConnection()
        {
            Connections.GoTo();
            Connections.TestConnectionPanel.Click();
        }

        [TestMethod]
        [Description("Clicks the 'all' checkbox twice, each time asserting that all checkboxes were checked and not checked.")]
        public void ClickAllCheckboxInTables()
        {

            TestConnection.AllCheckbox.Click();
            Assert.IsFalse(TestConnection.AreAllChecked);
            TestConnection.AllCheckbox.Click();
            Assert.IsTrue(TestConnection.AreAllChecked);
        }

        [TestMethod]
        [Description("Clicks the 'all' checkbox, clicks each individual checkbox, asserts they are all checked.")]
        public void ClickEachCheckboxInTables()
        {
            TestConnection.ClickEachCheckbox();
            Assert.IsFalse(TestConnection.AreAllChecked);
            TestConnection.ClickEachCheckbox();
            Assert.IsTrue(TestConnection.AreAllChecked, "Not all checkboxes were checked.");
        }

        [TestMethod]
        [Description("Checks to see if the 'discard changes' button works by un-ticking a checkbox and discarding the change via the 'discard changes' button, whilst asserting each time whether all checkboxes are checked or not.")]
        public void DiscardChangesButton()
        {
            TestConnection.OrderItemCheckbox.Click();
            Assert.IsFalse(TestConnection.AreAllChecked);
            TestConnection.DiscardChangesButton.Click();
            Assert.IsTrue(TestConnection.AreAllChecked);
        }

        [TestMethod]
        [Description("Checks to see if the 'save changes' button works by un-ticking and ticking a checkbox, each time clicking 'save changes', refreshing the page and asserting whether all checkboxes are checked/not checked.")]
        public void SaveChangesButton()
        {
            TestConnection.SupplierCheckbox.Click();
            TestConnection.SaveChangesButton.Click();
            Driver.Navigate().Refresh();
            Assert.IsFalse(TestConnection.AreAllChecked);

            TestConnection.SupplierCheckbox.Click();
            TestConnection.SaveChangesButton.Click();
            Driver.Navigate().Refresh();
            Assert.IsTrue(TestConnection.AreAllChecked);
        }

        [TestMethod]
        [Description("Asserts that the tabs selected by default are 'data' and 'tables'.")]
        public void CheckDefaultTabs()
        {
            Assert.AreEqual(TestConnection.CurrentSection, "DATA");
            Assert.AreEqual(TestConnection.CurrentTab, "TABLES");
        }
        [TestMethod]
        [Description("Clicks each individual sub-tab (under the data tab), each time asserting that the correct tab was selected.")]
        public void ClickEachSubTab()
        {
            TestConnection.ViewsTab.Click();
            Assert.AreEqual(TestConnection.CurrentTab, "VIEWS");
            TestConnection.ProceduresTab.Click();
            Assert.AreEqual(TestConnection.CurrentTab, "PROCEDURES");
            TestConnection.TablesTab.Click();
            Assert.AreEqual(TestConnection.CurrentTab, "TABLES");
        }

        [TestMethod]
        [Description("Clicks each individual upper-tab, each time asserting that the correct tab was selected.")]
        public void ClickEachUpperTab()
        {
            TestConnection.PermissionsTab.Click();
            Assert.AreEqual(TestConnection.CurrentSection, "PERMISSIONS");
            TestConnection.ConnectionTab.Click();
            Assert.AreEqual(TestConnection.CurrentSection, "CONNECTION");
            TestConnection.DataTab.Click();
            Assert.AreEqual(TestConnection.CurrentSection, "DATA");
        }

        [TestMethod]
        [Description("Clicks the search field, searches for a specific string (that we know there are no results for), asserts that no 'no data' result is displayed once the search has completed.")]
        public void SearchFieldNoResults()
        {
            TestConnection.SearchField.Click();
            TestConnection.SearchField.SendKeys("no result");
            Assert.IsTrue(TestConnection.NoDataResult.Displayed);
        }

        // SearchField Tests
        // Thread.Sleep is currently the best solution here because there is NO element we can attach an explicit wait to, to know when ONLY search results are being displayed.
        // This is somewhat brittle because if search results take longer than 1 second to process, the test will always pass (regardless of results).
        [TestMethod]
        [Description("Clicks the search field, searches for a specific string, asserts that the element we are expecting is displayed once the search has completed.")]
        public void SearchContains()
        {
            TestConnection.SearchField.Click();
            TestConnection.SearchField.SendKeys("customer");
            Thread.Sleep(1000);
            Assert.IsTrue(TestConnection.CustomerPanel.Displayed);
        }

        [TestMethod]
        [Description("Clicks the search icon, clicks the 'does not contain' option, types in 'order', asserts that all results not containing the word 'order' are displayed and that the total number of results displayed is 3.")]
        public void SearchDoesNotContain()
        {
            TestConnection.SearchIcon.Click();
            TestConnection.DoesNotContainButton.Click();
            TestConnection.SearchField.SendKeys("order");
            Thread.Sleep(1000);
            Assert.IsTrue(TestConnection.CustomerPanel.Displayed &&
                          TestConnection.ProductPanel.Displayed &&
                          TestConnection.SupplierPanel.Displayed);
            Assert.AreEqual(TestConnection.NumberOfSearchResults(), "3");
        }

        [TestMethod]
        [Description("Clicks the search icon, clicks the 'starts with' button, types in 's', asserts that all results that begin with 's' are displayed and that the total number of results displayed is 1.")]
        public void SearchStartsWith()
        {
            TestConnection.SearchIcon.Click();
            TestConnection.StartsWithButton.Click();
            TestConnection.SearchField.SendKeys("s");
            Thread.Sleep(1000);
            Assert.IsTrue(TestConnection.SupplierPanel.Displayed);
            Assert.AreEqual(TestConnection.NumberOfSearchResults(), "1");
        }

        [TestMethod]
        [Description("")]
        public void SearchEndsWith()
        {

        }
    }
}
