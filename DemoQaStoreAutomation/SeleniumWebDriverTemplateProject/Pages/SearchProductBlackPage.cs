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
    class SearchProductBlackPage :Page
    {
        [FindsBy(How = How.CssSelector, Using = "div.product_grid_item:nth-child(2) > div:nth-child(2) > h2:nth-child(1) > a:nth-child(1)")]
        public IWebElement NameProduct { get; set; }

        //public static string Path { get { return "/?s=White&post_type=wpsc-product"; } }

        public static SearchProductBlackPage NavigateTo(IWebDriver driver)
        {
            string baseURL = "http://store.demoqa.com/?s=Black&post_type=wpsc-product";
            driver.Navigate().GoToUrl(baseURL);

            //driver.Navigate().GoToUrl(baseURL + Path);

            var searchProductBlackInstance = PageFactoryExtensions.InitPage<SearchProductBlackPage>(driver);

            return searchProductBlackInstance;
        }
    }
}
