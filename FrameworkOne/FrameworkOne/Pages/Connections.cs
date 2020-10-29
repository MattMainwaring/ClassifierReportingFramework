﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne
{
    public class Connections : BasePage
    {
        public bool IsLoaded
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("connectionsList"))).Displayed;
            }
        }
        public IWebElement TestConnection => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[@role='gridcell'][contains(text(),'TestConnection')]")));
        public IWebElement TestConnectionContent => Driver.FindElement(By.Id("devextreme0"));
        public IWebElement DeleteButton => Driver.FindElement(By.XPath("//a[@class='dx-link dx-link-delete dx-icon-trash dx-link-icon']"));
        public IWebElement DeleteConfirmationMessage => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dx-dialog-message'][contains(text(),'Are you sure you want to delete this record?')]")));
        public IWebElement NewConnectionButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-add']"));
        public IWebElement NewConnectionMenuHeader => Driver.FindElement(By.XPath("//div[contains(text(),'New Connection')]"));
        public IWebElement NameField
        {
            get
            {
                var nameField = Driver.FindElements(By.ClassName("dx-texteditor-input"))[0];
                return Wait.Until(ExpectedConditions.ElementToBeClickable(nameField));
            }
        }
        public IWebElement ServerField
        {
            get
            {
                var serverField = Driver.FindElements(By.ClassName("dx-texteditor-input"))[1];
                return Wait.Until(ExpectedConditions.ElementToBeClickable(serverField));
            }
        }
        public IWebElement DatabaseField
        {
            get
            {
                var descField = Driver.FindElements(By.ClassName("dx-texteditor-input"))[2];
                return Wait.Until(ExpectedConditions.ElementToBeClickable(descField));
            }
        }
        public IWebElement SaveButton => Driver.FindElement(By.XPath("//div[@aria-label='Save']"));
        public IWebElement LoadingWidget
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dx-loadpanel-indicator dx-loadindicator dx-widget']")));
            }
        }

        public Connections(IWebDriver driver) : base(driver) { }

        internal void CreateNewConnection(string name, string server, string database)
        {
            NewConnectionButton.Click();
            NameField.SendKeys(name);
            ServerField.SendKeys(server);
            DatabaseField.SendKeys(database);
            SaveButton.Click();
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/Connections");
            Assert.IsTrue(IsLoaded, "Connections page was not loaded.");
        }
    }
}