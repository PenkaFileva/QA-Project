using NUnit.Framework;
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
    class BasketIsFull : DesktopSeleniumTestFixturePrototype
    {
        public BasketIsFull(Browsers browser) : base(browser)
        { }

        [Test]
        public void ClearItems()
        {
            var page = ProductCategoryPage.NavigateTo(base.Driver);
            string link = page.CheckOutButton.GetProperty("href");
            this.Driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(6000);
            var checkoutPage = PageFactoryExtensions.InitPage<CheckOutPage>(Driver);
            foreach (var removeButton in checkoutPage.GetRemoveButtons())
            {
                removeButton.Click();
                Thread.Sleep(3000);
            }
        }
    }
}
