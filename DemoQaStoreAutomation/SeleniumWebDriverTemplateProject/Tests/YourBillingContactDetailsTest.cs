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
    class YourBillingContactDetailsTest : DesktopSeleniumTestFixturePrototype
    {
        public YourBillingContactDetailsTest(Browsers browser) : base(browser)
        { }

        [Test]
        public void ContactDetailsTest()
        {
            var contactDetailsInstance = ContactDetailsPage.NavigateTo(base.Driver);
            contactDetailsInstance.FirstName.SendKeys("Penka");
            contactDetailsInstance.LastName.SendKeys("Fileva");
            contactDetailsInstance.Address.SendKeys("Gorubliane");
            contactDetailsInstance.City.SendKeys("Sofia");
            contactDetailsInstance.Undefined.SendKeys("123");
            Thread.Sleep(3000);
            contactDetailsInstance.Country.SendKeys("Bulgaria");
            Thread.Sleep(3000);
            contactDetailsInstance.Phone.SendKeys("0869256125");
           contactDetailsInstance.Email.SendKeys("1penka@abv.bg");
            Thread.Sleep(3000);
            contactDetailsInstance.SaveProfil.Click();
        }
    }
}
