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
        public void TCID1()
        {
            Packs.ExpandButton.Click();
            Assert.IsTrue(Packs.ExpandedMenu.Displayed);
        }

        [TestMethod]
        [Description("Searches a string, then asserts that the relevant text is highlighted on the page.")]
        public void TCID2()
        {
            Packs.Search("Sample");
            Assert.AreEqual(Packs.HighlightedText, "Sample");
        }

        [TestMethod]
        [Description("Clicks the expand button, clicks a checkbox (which un-ticks it), asserts that the checkbox is not ticked.")]
        public void TCID3()
        {
            Packs.ExpandButton.Click();
            Packs.CheckBox.Click();
            Assert.AreEqual(Packs.CheckBox.GetAttribute("aria-checked"), "false");
        }

        [TestMethod]
        [Description("")]
        public void TCID4()
        {
            Packs.ExpandButton.Click();
            Packs.DeleteButton.Click();
            Assert.IsTrue(Packs.DeleteConfirmationMessage.Displayed);
        }
    }
}
