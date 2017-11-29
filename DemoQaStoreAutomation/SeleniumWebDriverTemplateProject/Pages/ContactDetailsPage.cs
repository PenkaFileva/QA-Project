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
    class ContactDetailsPage : Page
    {
        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_2")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_3")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_4")]
        public IWebElement Address { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_5")]
        public IWebElement City { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_6")]
        public IWebElement Undefined { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_7")]
        public IWebElement Country { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_18")]
        public IWebElement Phone { get; set; }

        [FindsBy(How = How.Id, Using = "wpsc_checkout_form_9")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#post-31 > div > div > form > table:nth-child(3) > tbody > tr > td > input[type=\"submit\"]:nth-child(2)")] //.myaccount > form:nth-child(2) > table:nth-child(3) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1) > input:nth-child(2)
        public IWebElement SaveProfil { get; set; }//input[name="submit"]//#post-31 > div > div > form > table:nth-child(3) > tbody > tr > td > input[type="submit"]:nth-child(2)

        public static ContactDetailsPage NavigateTo(IWebDriver driver)
        {
            var yourAccountPageInstance = YourAccountPage.NavigateTo(driver);
            yourAccountPageInstance.YourDetails.Click();
            

            var contactDetailsPageInstance = PageFactoryExtensions.InitPage<ContactDetailsPage>(driver);

            return contactDetailsPageInstance;
        }
    }
}
