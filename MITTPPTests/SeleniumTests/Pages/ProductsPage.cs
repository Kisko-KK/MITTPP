using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

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
            Thread.Sleep(1000);

            By productLocator = By.XPath(specificXPath);
            driver.FindElement(productLocator).Click();
        }

        public bool IsRemoveButtonDisplayed(string productName)
        {
            string specificXPath = $"//*[@id='remove-{productName.Replace(" ", "-").ToLower()}']";
            Thread.Sleep(1000);

            IReadOnlyCollection<IWebElement> removeButtons = driver.FindElements(By.XPath(specificXPath));

            return removeButtons.Any() && removeButtons.First().Displayed;
        }
    }
}
