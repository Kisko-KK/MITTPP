using OpenQA.Selenium;

public class ShoppingCartPage
{
    private readonly IWebDriver driver;

    // Constructor
    public ShoppingCartPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    // Action methods
    public void GoToShoppingCart()
    {
        driver.FindElement(By.CssSelector(".shopping_cart_link")).Click();
    }

    public bool IsItemDisplayedInCart(string itemName)
    {
        By itemLocator = By.XPath($"//div[@class='cart_item' and .//div[@class='inventory_item_name' and text()='{itemName}']]");
        return driver.FindElements(itemLocator).Count > 0;
    }
}
