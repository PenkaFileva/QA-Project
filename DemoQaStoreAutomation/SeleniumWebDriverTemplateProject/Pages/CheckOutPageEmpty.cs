using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriverTemplateProject.Pages.Abstract;

namespace SeleniumWebDriverTemplateProject.Pages
{
    class CheckOutPageEmpty : Page
    {
        [FindsBy(How = How.ClassName, Using = "count")] 
        public IWebElement CheckOutEmptyBox { get; set; }
    }
}
