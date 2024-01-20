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
        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLoginButton();

        Assert.Equal($"{BaseUrl}inventory.html", driver.Url);
    }

    [Fact]
    public void LoginWithInvalidCredentials_ShouldNotNavigateToProductsPage()
    {
        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("12345678");
        loginPage.ClickLoginButton();

        Assert.NotEqual($"{BaseUrl}inventory.html", driver.Url);
    }
}
