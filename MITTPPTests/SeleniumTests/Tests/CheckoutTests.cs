using MySeleniumTests.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Tests
{
    public class CheckoutTests : IDisposable
    {
        private IWebDriver driver;
        private readonly ProductsPage productPage;
        private readonly ShoppingCartPage shoppingCartPage;
        private readonly CheckoutPage checkoutPage;
        private readonly LoginPage loginPage;
        private const string BaseUrl = "https://www.saucedemo.com/";

        public CheckoutTests()
        {
            driver = new ChromeDriver();
            productPage = new ProductsPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);
            checkoutPage = new CheckoutPage(driver);
            loginPage = new LoginPage(driver);

            driver.Navigate().GoToUrl(BaseUrl);

            loginPage.Login("standard_user", "secret_sauce");
        }

        [Fact]
        public void AddTwoItemsToCart_VerifyCheckout()
        {
            productPage.ClickAddButton("Sauce Labs Backpack");
            productPage.ClickAddButton("Sauce Labs Bike Light");

            shoppingCartPage.GoToShoppingCart();

            checkoutPage.GoToCheckout();

            checkoutPage.InputUserInfo("Ante", "Antic", "12345");

            checkoutPage.FinishCheckout();
        }

        [Fact]
        public void AddTwoItemsToCart_VerifyCheckoutPrice()
        {
            productPage.ClickAddButton("Sauce Labs Backpack");
            productPage.ClickAddButton("Sauce Labs Bike Light");

            shoppingCartPage.GoToShoppingCart();

            checkoutPage.GoToCheckout();

            checkoutPage.InputUserInfo("Ante", "Antic", "12345");

            string totalPrice = checkoutPage.GetTotalPrice();

            Assert.Equal("Total: $43.18", totalPrice);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
