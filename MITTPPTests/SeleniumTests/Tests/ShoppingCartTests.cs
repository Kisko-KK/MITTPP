using System;
using MySeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumTests
{
    public class ShoppingCartTests : IDisposable
    {
        private IWebDriver driver;
        private readonly ProductsPage productPage;
        private readonly ShoppingCartPage shoppingCartPage;
        private const string BaseUrl = "https://www.saucedemo.com/";

        public ShoppingCartTests()
        {
            driver = new ChromeDriver();
            productPage = new ProductsPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);
            var loginPage = new LoginPage(driver);

            driver.Navigate().GoToUrl(BaseUrl);

            loginPage.Login("standard_user", "secret_sauce");
        }

        [Fact]
        public void AddItemToCart_VerifyDisplayingInShoppingCart()
        {
            productPage.ClickAddButton("Sauce Labs Backpack");

            shoppingCartPage.GoToShoppingCart();

            Assert.True(shoppingCartPage.IsItemDisplayedInCart("Sauce Labs Backpack"));

        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
