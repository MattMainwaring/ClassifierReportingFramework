using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkOne.Tests
{
    [TestClass]
    public class PackTests : BaseTest
    {
        [TestInitialize]
        public void LoadPage()
        {
            Packs.GoTo();
        }

        [TestMethod]
        [Description("Checks that the expand button works.")]
        public void ExpandButton()
        {
            Packs.ExpandButton.Click();
            Assert.IsTrue(Packs.ExpandedMenu.Displayed);
        }

        [TestMethod]
        [Description("Searches a string, then asserts that the relevant text is highlighted on the page.")]
        public void SearchTextHighlighted()
        {
            Packs.Search("Sample");
            Assert.AreEqual(Packs.HighlightedText, "Sample");
        }

        [TestMethod]
        [Description("Clicks the expand button, clicks a checkbox (which un-ticks it), asserts that the checkbox is not ticked.")]
        public void CheckboxUncheck()
        {
            Packs.ExpandButton.Click();
            Packs.CheckBox.Click();
            Assert.AreEqual(Packs.CheckBox.GetAttribute("aria-checked"), "false");
        }

        [TestMethod]
        [Description("Clicks the expand button, clicks the delete button, asserts that the delete confirmation message is displayed.")]
        public void DeleteButtonConfirmation()
        {
            Packs.ExpandButton.Click();
            Packs.DeleteButton.Click();
            Assert.IsTrue(Packs.DeleteConfirmationMessage.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'pack name' column twice, asserts each time that the correct sorting arrow is displayed.")]
        public void PackNameColumnSorting()
        {
            Packs.PackNameColumn.Click();
            Assert.IsTrue(Packs.SortUpArrow.Displayed);
            Packs.PackNameColumn.Click();
            Assert.IsTrue(Packs.SortDownArrow.Displayed);
        }

    }
}
