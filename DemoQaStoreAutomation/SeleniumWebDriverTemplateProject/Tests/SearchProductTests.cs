using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages;
using SeleniumWebDriverTemplateProject.Tests.Abstract;

namespace SeleniumWebDriverTemplateProject.Tests
{
    class SearchProductTests : DesktopSeleniumTestFixturePrototype
    {
        public SearchProductTests(Browsers browser) : base(browser)
        {
        }

        [Test]
        public void SearchProductWhiteTest()
        {
            var yourAccountPage = YourAccountPage.NavigateTo(base.Driver);
            Thread.Sleep(6000);
            yourAccountPage.SearchTextBox.SendKeys("White");
            Thread.Sleep(3000);

            var searchProductPage = SearchProductPage.NavigateTo(this.Driver);
            string text = searchProductPage.NameProduct.Text;
            Assert.IsTrue(text.Contains("White"));
            Thread.Sleep(3000);
        }

        [Test]
        public void SearchProductBlackTest()
        {
            var yourAccountPage = YourAccountPage.NavigateTo(base.Driver);
            Thread.Sleep(6000);
            yourAccountPage.SearchTextBox.SendKeys("Black");
            Thread.Sleep(3000);

            var searchProductPage = SearchProductBlackPage.NavigateTo(this.Driver);
            string text = searchProductPage.NameProduct.Text;
            Assert.IsTrue(text.Contains("Black"));
            Thread.Sleep(3000);
        }
    }
}
