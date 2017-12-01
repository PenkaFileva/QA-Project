using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages;
using SeleniumWebDriverTemplateProject.Tests.Abstract;

namespace SeleniumWebDriverTemplateProject.Tests
{
    class LoginLogoutTests : DesktopSeleniumTestFixturePrototype
    {
        public LoginLogoutTests(Browsers browser) : base(browser)
        {
        }

        [Test]
        public void LoginLogoutTest()
        {
            var page = LoginPage.NavigateTo(base.Driver);
            Thread.Sleep(6000);

            var userNameTextBox = this.Driver.FindElement(By.Id("log"));
            userNameTextBox.SendKeys("filipova_975@abv.bg");

            var passwordNameTextBox = this.Driver.FindElement(By.Id("pwd"));
            passwordNameTextBox.SendKeys("W12zW3nItU&sAH1f");

            var loginButton = this.Driver.FindElement(By.Id("login"));
            loginButton.Click();
            Thread.Sleep(10000);

            var logoutButton = this.Driver.FindElements(By.Id("account_logout"));
            int buttonCount = logoutButton.Count;
            Assert.IsTrue(buttonCount > 0);
            logoutButton[0].Click();
            Thread.Sleep(6000);

            logoutButton = this.Driver.FindElements(By.Id("account_logout"));
            buttonCount = logoutButton.Count;

            Assert.IsTrue(buttonCount == 0);
        }

        [Test]
        public void RegisterTest()
        {
            //IWebDriver driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("http://store.demoqa.com/wp-login.php?action=register");
            string userName = Faker.Name.First() + Faker.Name.Last();
            string email = userName + "@nosuchmail8579.book";

            var userNameTextBox = this.Driver.FindElement(By.Id("user_login"));
            userNameTextBox.SendKeys(userName);

            var emailTextBox = this.Driver.FindElement(By.Id("user_email"));
            emailTextBox.SendKeys(email);

            var registerButton = this.Driver.FindElement(By.Id("wp-submit"));
            registerButton.Click();

            Thread.Sleep(6000);
            //var messages = this.Driver.FindElements(By.ClassName("message"));
            //int messigesCount = messages.Count;
            //Assert.IsTrue(messigesCount > 0);
            //или
            IWebElement message = this.Driver.FindElement(By.ClassName("message"));
            Assert.AreEqual("Registration complete. Please check your email.", message.Text);
        }

        [Test]
        public void SearchWhiteTest()
        {
            //IWebDriver driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("http://store.demoqa.com/");
            string searchText = "White";
            var searchTextBox = this.Driver.FindElement(By.ClassName("search"));
            searchTextBox.SendKeys(searchText);
            searchTextBox.SendKeys(Keys.Enter);

            Thread.Sleep(4000);
            var searchResults = this.Driver.FindElements(By.CssSelector(".prodtitle a"));
            for (int i = 0; i < searchResults.Count; i++)
            {
                string currentSearchReasult = searchResults[i].Text;
                Assert.IsTrue(currentSearchReasult.Contains(searchText));
            }
        }

        [Test]
        public void SearchBlackTest()
        {
            //IWebDriver driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("http://store.demoqa.com/");
            string searchText = "Black";
            var searchTextBox = this.Driver.FindElement(By.ClassName("search"));
            searchTextBox.SendKeys(searchText);
            searchTextBox.SendKeys(Keys.Enter);

            Thread.Sleep(4000);
            var searchResults = this.Driver.FindElements(By.CssSelector(".prodtitle a"));
            for (int i = 0; i < searchResults.Count; i++)
            {
                string currentSearchReasult = searchResults[i].Text;
                Assert.IsTrue(currentSearchReasult.Contains(searchText));
            }
        }
    }
}
