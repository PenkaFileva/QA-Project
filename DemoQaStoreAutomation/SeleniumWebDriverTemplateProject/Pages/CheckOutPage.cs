﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriverTemplateProject.Pages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Pages
{
    class CheckOutPage : Page
    {
        [FindsBy(How = How.ClassName, Using = "checkout_cart")]
        public IWebElement CheckOutCartRoot { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".step2 span")] //.step2 > span:nth-child(1)
        public IWebElement ContiniueButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".yourtotal span")]//.yourtotal > span:nth-child(1)//.yourtotal > span:nth-child(1)
        public IWebElement SubTotalTextBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "count")]
        public IWebElement CountItemCheckout { get; set; }

        public int GetSubTotal()
        {
            string rawSubTotal = this.SubTotalTextBox.Text;
            string subTotalAsString = Regex.Match(rawSubTotal, @"\d+").Value;
            int subTotalAsInt = Convert.ToInt32(subTotalAsString);

            return subTotalAsInt;
        }

        public int GetTotal()
        {
            int totalProducts = 0;

            var totals = GetTotalTextBoxes();
            for (int i = 0; i < totals.Count; i++)
            {
                string currentTotal = totals[i].Text;
                string currentTotalAsString = Regex.Match(currentTotal, @"\d+").Value;
                int subTotalAsInt = Convert.ToInt32(currentTotalAsString);
                totalProducts += subTotalAsInt;
            }
           
            return totalProducts;
        }

        public List<IWebElement> GetProductNames()
        {
            var productNames = this.CheckOutCartRoot.FindElements(By.CssSelector(".wpsc_product_name a"));

            return productNames.ToList<IWebElement>();
        }

        public List<IWebElement> GetQuantityTextBoxes()
        {
            var quantityTextBoxes = this.CheckOutCartRoot.FindElements(By.Name("quantity"));

            return quantityTextBoxes.ToList<IWebElement>();
        }

        public List<IWebElement> GetUpdateButtons()
        {
            var quantityTextBoxes = this.CheckOutCartRoot.FindElements(By.CssSelector("value~=[Update]"));

            return quantityTextBoxes.ToList<IWebElement>();
        }

        public List<IWebElement> GetPriceTextBoxes()
        {
            var priceTextBoxes = this.CheckOutCartRoot.FindElements(By.CssSelector("td:nth-child(4) > span:nth-child(1)"));

            return priceTextBoxes.ToList<IWebElement>();
        }

        public List<IWebElement> GetTotalTextBoxes()
        {
            var totalCheckBoxes = this.CheckOutCartRoot.FindElements(By.CssSelector(".wpsc_product_price > span > span"));
       
            return totalCheckBoxes.ToList<IWebElement>();
        }

        public List<IWebElement> GetRemoveButtons()
        {
            var totalCheckBoxes = this.CheckOutCartRoot.FindElements(By.CssSelector(".remove > input:nth-child(4)")); //.adjustform.remove > input:nth-child(4) ili .remove > input:nth-child(4)

            return totalCheckBoxes.ToList<IWebElement>();
        }
    }
}
