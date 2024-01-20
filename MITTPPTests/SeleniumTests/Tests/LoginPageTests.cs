using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

public class LoginPageTests : IDisposable
{
    private IWebDriver driver;
    private readonly LoginPage loginPage;
    private const string BaseUrl = "https://www.saucedemo.com/";

    public LoginPageTests()
    {
        driver = new ChromeDriver();

        loginPage = new LoginPage(driver);

        driver.Navigate().GoToUrl(BaseUrl);
    }
    public void Dispose()
    {
        driver.Quit();
    }
    
    [Fact]
    public void LoginWithValidCredentials_ShouldNavigateToProductsPage()
    {
        loginPage.Login("standard_user", "secret_sauce");

        Assert.Equal($"{BaseUrl}inventory.html", driver.Url);
    }

    [Fact]
    public void LoginWithInvalidCredentials_ShouldNotNavigateToProductsPage()
    {
        loginPage.Login("standard_user", "wrong_password");

        Assert.NotEqual($"{BaseUrl}inventory.html", driver.Url);
    }
    
}
