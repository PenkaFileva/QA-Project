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
    class MyAccountButtonTests : DesktopSeleniumTestFixturePrototype
    {
        public MyAccountButtonTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void MyAccountButtonTest()
        {
            var myAccountbuttonInstance = HomePage.NavigateTo(base.Driver);
            myAccountbuttonInstance.MyAccountButton.Click();
            Thread.Sleep(4000);
            var yourAccountPage = PageFactoryExtensions.InitPage<YourAccountPage>(this.Driver);
        }
    }
}
