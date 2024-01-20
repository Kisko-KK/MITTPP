using OpenQA.Selenium;

public class LoginPage
{
    private IWebDriver driver;

    // Locators
    private By usernameInput = By.Id("user-name");
    private By passwordInput = By.Id("password");
    private By loginButton = By.Id("login-button");

    // Constructor
    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    // Action methods
    public void EnterUsername(string username)
    {
        driver.FindElement(usernameInput).SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        driver.FindElement(passwordInput).SendKeys(password);
    }

    public void ClickLoginButton()
    {
        driver.FindElement(loginButton).Click();
    }
}
