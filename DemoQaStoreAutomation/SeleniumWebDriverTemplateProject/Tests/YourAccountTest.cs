using NUnit.Framework;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages;
using SeleniumWebDriverTemplateProject.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Tests
{
    class YourAccountTests : DesktopSeleniumTestFixturePrototype
    {
        public YourAccountTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void YourAccountTest()
        {
            var yourAccountInstance = YourAccountPage.NavigateTo(base.Driver);
            var countAsAString1 = yourAccountInstance.PurchaseHistory.Text;
            var countAsAString2 = yourAccountInstance.YourDetails.Text;
            var countAsAString3 = yourAccountInstance.YourDownloads.Text;

            Assert.AreEqual(countAsAString1, "Purchase History");
            Assert.AreEqual(countAsAString2, "Your Details");
            Assert.AreEqual(countAsAString3, "Your Downloads");
        }
    }
}
