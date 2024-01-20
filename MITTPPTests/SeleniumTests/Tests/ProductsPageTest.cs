using MySeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

public class ProductsPageTests : IDisposable
{
    private IWebDriver driver;
    private readonly ProductsPage productPage;
    private const string BaseUrl = "https://www.saucedemo.com/";

    public ProductsPageTests()
    {
        driver = new ChromeDriver();
        productPage = new ProductsPage(driver);
        var loginPage = new LoginPage(driver);

        driver.Navigate().GoToUrl(BaseUrl);

        loginPage.Login("standard_user", "secret_sauce");
    }

    [Fact]
    public void ClickAdd_ShouldDisplayRemoveButton()
    {
        productPage.ClickAddButton("Sauce Labs Backpack");

        Assert.True(productPage.IsRemoveButtonDisplayed("Sauce Labs Backpack"));
    }
    
    public void Dispose()
    {
        driver.Quit();
    }
}
