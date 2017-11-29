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
    class LogoutTest : DesktopSeleniumTestFixturePrototype
    {
        public LogoutTest(Browsers browser) : base(browser)
        {
        }

        [Test]
        public void Logouttest()
        {
            var yourAccountPage = YourAccountPage.NavigateTo(base.Driver);
            yourAccountPage.Logout.Click();
            Thread.Sleep(10000);

            var logoutPage = PageFactoryExtensions.InitPage<LoginPage>(this.Driver);
            Assert.AreEqual(logoutPage.LoginTextBox.Text, "Log in");
            logoutPage.LoginTextBox.Click();
            Thread.Sleep(6000);
            
            var otherLoginPage = PageFactoryExtensions.InitPage<OtherLoginPage>(this.Driver);
            otherLoginPage.OtherLogIn();
            Thread.Sleep(3000);

            var profilePage = PageFactoryExtensions.InitPage<ProfilPage>(this.Driver);
            //Assert.AreEqual(profilePage.NickNameTextBox.Text, "pepina2111");
            profilePage.Dashboard.Click();
            Thread.Sleep(3000);
            profilePage.OnlineStore.Click();
            Thread.Sleep(3000);
            
            var yourAccountPageIns = PageFactoryExtensions.InitPage<YourAccountPage>(this.Driver);
            
            Thread.Sleep(10000);
            
            Assert.AreEqual(yourAccountPageIns.UserNameTextBox.Text, "pepina2111");
        }
    }
}
