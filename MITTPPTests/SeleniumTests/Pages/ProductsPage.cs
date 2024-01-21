using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace MySeleniumTests.Pages
{
    public class ProductsPage
    {
        private IWebDriver driver;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAddButton(string productName)
        {
            string specificXPath = $"//*[@id='add-to-cart-{productName.Replace(" ", "-").ToLower()}']";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            By productLocator = By.XPath(specificXPath);
            IWebElement addButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(productLocator));

            addButton.Click();
        }

        public bool IsRemoveButtonDisplayed(string productName)
        {
            string specificXPath = $"//*[@id='remove-{productName.Replace(" ", "-").ToLower()}']";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            By removeButtonLocator = By.XPath(specificXPath);

            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(removeButtonLocator)).Any();
        }
    }
}
