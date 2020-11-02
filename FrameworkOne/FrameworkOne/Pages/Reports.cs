using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FrameworkOne
{
    public class Reports : BasePage
    {
        public bool IsLoaded
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("bj-reports-Container"))).Displayed;
            }
        }
        public IWebElement SupplierReportPanel => Driver.FindElement(By.Id("SupplierReport"));
        public IWebElement SupplierReportContent
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("dxrd-report-preview-content")));
            }
        }
        public IWebElement SupplierReportEditButton => Driver.FindElement(By.Id("devextreme3"));
        public IWebElement SupplierReportEditPageTitle => Driver.FindElement(By.XPath("//div[@class='bj-page-header'][contains(text(),'SupplierReport')]"));
        public IWebElement CreateReportButton => Driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-rowfield']")); 
        public IWebElement FromTemplateButton 
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='dx-fa-button-label'][contains(text(),'From Template')]")));
            }
        }
        public IWebElement ReportTemplatesContainer => Driver.FindElement(By.Id("importReportsContainer"));
        public IWebElement TagFilterBar => Driver.FindElement(By.Id("reportTagsFilter"));
        public IWebElement ExpandedTagFilterBar => Driver.FindElement(By.ClassName("dx-popup-content"));
        public IWebElement PaletteButton
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dx-icon.dx-icon-palette")));
            }
        }
        public IWebElement NewReportWorkspace
        {
            get
            {
                return Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dxrd-surface-wrapper")));
            }
        }


        public Reports(IWebDriver driver) : base(driver) { }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://msserver2019/Reports");
            Assert.IsTrue(IsLoaded, "The reports page was not loaded.");
        }
    }
}