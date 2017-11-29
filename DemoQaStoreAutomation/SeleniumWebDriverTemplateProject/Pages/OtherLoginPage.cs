using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages.Abstract;

namespace SeleniumWebDriverTemplateProject.Pages
{
    class OtherLoginPage : Page
    {
        [FindsBy(How = How.Id, Using = "user_login")]
        public IWebElement UsernameOrEmailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "user_pass")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "wp-submit")]
        public IWebElement LogIn { get; set; }

        public static OtherLoginPage NavigateTo(IWebDriver driver)
        {
            var loginPageInstance = LoginPage.NavigateTo(driver);
            System.Threading.Thread.Sleep(3000);

            var otherLoginPageInstance = PageFactoryExtensions.InitPage<OtherLoginPage>(driver);
            return otherLoginPageInstance;
        }

        public void OtherLogIn()
        {
            this.UsernameOrEmailAddress.SendKeys(GeneralSettings.Default.UserName);
            this.Password.SendKeys(GeneralSettings.Default.Password);
            this.LogIn.Click();

            // added because of firefox rushing
            System.Threading.Thread.Sleep(3000);
        }
    }
}
