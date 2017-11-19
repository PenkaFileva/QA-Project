using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages;
using SeleniumWebDriverTemplateProject.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Tests
{
    class AllProductTests : DesktopSeleniumTestFixturePrototype
    {
        public AllProductTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void AllProductTest()
        {
            var productPageInstance = ProductCategoryPage.NavigateTo(base.Driver);

            productPageInstance.AllProductButton.Click();
            Thread.Sleep(5000);

            //productPageInstance = PageFactoryExtensions.InitPage<ProductCategoryPage>(this.Driver);

            productPageInstance.GridButton.Click();

            Thread.Sleep(4000);
            productPageInstance.ListButton.Click();
        }
    }
}
