﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkOne.Tests
{
    [TestClass]
    public class UserTests : BaseTest
    {
        [TestInitialize]
        public void LoadPage()
        {
            Users.GoTo();
        }

        [TestMethod]
        [Description("Clicks the administrator user, asserts that the available permissions page loaded.")]
        public void ViewAdministratorUserPermissions()
        {
            Users.UserAdministrator.Click();
            Assert.IsTrue(Users.AvailablePermissionsPanel.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'add new user' button, asserts that the lookup field is displayed.")]
        public void AddNewUserLookupField()
        {
            Users.NewUserButton.Click();
            Assert.IsTrue(Users.NewUserPageHeader.Displayed);
        }

        [TestMethod]
        [Description("Clicks the 'add new user' button, clicks the lookup field, asserts that the search icon is displayed.")]
        public void LookupFieldSearchIcon()
        {
            Users.NewUserButton.Click();
            Users.LookupField.Click();
            Assert.IsTrue(Users.SearchIcon.Displayed);
        }

        [TestMethod]
        [Description("Clicks the administrator user, clicks the desired checkbox, asserts that the checkbox is checked.")]
        public void PermissionsCheckboxChecked()
        {
            Users.UserAdministrator.Click();
            Users.Checkbox5.Click();
            Assert.AreEqual(Users.Checkbox5.GetAttribute("aria-checked"), "true");
        }

        [TestMethod]
        [Description("Clicks the delete button, asserts that the 'delete confirmation message' is displayed.")]
        public void DeleteButtonConfirmation()
        {
            Users.DeleteButton.Click();
            Assert.IsTrue(Users.DeleteConfirmationMessage.Displayed);
        }
    }
}
