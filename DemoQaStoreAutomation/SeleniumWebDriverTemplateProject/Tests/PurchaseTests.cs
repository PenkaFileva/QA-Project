﻿using NUnit.Framework;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages;
using SeleniumWebDriverTemplateProject.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumWebDriverTemplateProject.Tests
{
    class PurchaseTests : DesktopSeleniumTestFixturePrototype
    {
        public PurchaseTests(Browsers browser) : base(browser)
        { }

        [Test]
        public void BuyEveryItemFromTheFirstPage()
        {
            var productPageInstance = ProductCategoryPage.NavigateTo(base.Driver);

            var products = productPageInstance.GetProducts();

            int totalPriceFromProductCategoryPage = 0;

            for (int i = 0; i < products.Count(); i = i + 1)
            {
                string rawPrice = products[i].PriceTextBox.Text;
                string priceAsString = Regex.Match(rawPrice, @"\d+").Value;
                int priceAsInt = Convert.ToInt32(priceAsString);

                totalPriceFromProductCategoryPage += priceAsInt;

                products[i].AddToCartButton.Click();
                System.Threading.Thread.Sleep(6000);
            }

            // navigate to checkout page
            string url = productPageInstance.CheckOutLink.GetAttribute("href");
            Driver.Navigate().GoToUrl(url);

            System.Threading.Thread.Sleep(4000);
            var checkOutPageInstance = PageFactoryExtensions.InitPage<CheckOutPage>(Driver);

            int totalPriceFromCheckoutPage = checkOutPageInstance.GetSubTotal();
            int totalProductFromCheckoutPage = checkOutPageInstance.GetTotal();

            Assert.AreEqual(totalProductFromCheckoutPage, totalPriceFromCheckoutPage);
            System.Threading.Thread.Sleep(4000);

            //navigate to purchase information page
            checkOutPageInstance.ContiniueButton.Click();
            var purchaseInformationPageInstance = PageFactoryExtensions.InitPage<PurchaseInformationPage>(this.Driver);
            System.Threading.Thread.Sleep(4000);

            int totalItemPriceFromPurchaseInformationPage = purchaseInformationPageInstance.GetItemCost();
            int totalPriceFromPurchaseInformationPage = purchaseInformationPageInstance.GetTotalPrice();
            int totalShippingFromPurchaseInformationPage = purchaseInformationPageInstance.GetTotalShiping();

            Assert.AreEqual(totalPriceFromPurchaseInformationPage, 
                totalItemPriceFromPurchaseInformationPage + totalShippingFromPurchaseInformationPage);

            //navigate to TransactionResultPage
            purchaseInformationPageInstance.PurchaseButton.Click();
            System.Threading.Thread.Sleep(5000);
            var transactionResultPageInstance = PageFactoryExtensions.InitPage<TransactionResultPage>(Driver);

            string transactionResultText = transactionResultPageInstance.TransactionResultTextBox.Text;

            Assert.AreEqual("Transaction Results", transactionResultText);
        }
    }
}
