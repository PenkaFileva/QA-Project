using NUnit.Framework;
using SeleniumWebDriverTemplateProject.Helpers;
using SeleniumWebDriverTemplateProject.Pages;
using SeleniumWebDriverTemplateProject.Tests.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumWebDriverTemplateProject.Tests
{
    class CheckoutButtonTest : DesktopSeleniumTestFixturePrototype
    {
        public CheckoutButtonTest(Browsers browser) : base(browser)
        { }

        [Test]
        public void EmptyBasketTest()
        {
            var checkoutPageInstance = ProductCategoryPage.NavigateTo(base.Driver);
            Thread.Sleep(5000);
            checkoutPageInstance.CheckOutButton.Click();
            Thread.Sleep(5000);
            var checkOutPageIns = PageFactoryExtensions.InitPage<CheckOutPage>(Driver);
            var countAsAString = checkOutPageIns.CountItemCheckout.Text;
            var countAsAnInteger = Convert.ToInt32(countAsAString);

            //if (countAsAnInteger > 0)
            //{
                //foreach (var removeButton in checkOutPageIns.GetRemoveButtons())
                //{
                //    removeButton.Click();
                //    Thread.Sleep(10000);
                //}
            //}
            var removeButtons = checkOutPageIns.GetRemoveButtons();
            for (int i = removeButtons.Count -1; i >= 0; i--)
            {
                if (removeButtons.Count == 1)
                {
                    removeButtons[i].Click();
                    Thread.Sleep(10000);
                    var checkOutPageEmptyIns = PageFactoryExtensions.InitPage<CheckOutPageEmpty>(this.Driver);
                    var checkOutPageEmptyInsStr = checkOutPageEmptyIns.CheckOutEmptyBox.Text;
                    string checkOutPageEmptyInsString = Regex.Match(checkOutPageEmptyInsStr, @"\d+").Value;
                    int subTotalAsInt = Convert.ToInt32(checkOutPageEmptyInsString);
                    if (subTotalAsInt == 0)
                    {
                        break;   
                    }
                }
                else
                {
                    removeButtons[i].Click();
                    Thread.Sleep(10000);

                    checkOutPageIns = PageFactoryExtensions.InitPage<CheckOutPage>(Driver);
                    removeButtons = checkOutPageIns.GetRemoveButtons();

                    Thread.Sleep(2000);
                }
            }
        }
    }
}
