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
    class ProfilPage : Page
    {
        [FindsBy(How = How.ClassName, Using = "wp-menu-name")]
        public IWebElement Dashboard { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#wp-admin-bar-site-name > a")]
        public IWebElement OnlineStore { get; set; }

        [FindsBy(How = How.ClassName, Using = "display-name")]
        public IWebElement DisplayNameTextBox { get; set; }

        public static ProfilPage NavigateTo(IWebDriver driver)
        {
            var otherLoginPage = OtherLoginPage.NavigateTo(driver);
            otherLoginPage.OtherLogIn();

            var profilPageInstance = PageFactoryExtensions.InitPage<ProfilPage>(driver);

            return profilPageInstance;
        }
    }
}
