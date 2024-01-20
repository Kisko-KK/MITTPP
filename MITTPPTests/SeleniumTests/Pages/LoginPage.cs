using OpenQA.Selenium;

public class LoginPage
{
    private IWebDriver driver;

    private By usernameInput = By.Id("user-name");
    private By passwordInput = By.Id("password");
    private By loginButton = By.Id("login-button");

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Login(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);
        ClickLoginButton();
    }
    private void EnterUsername(string username)
    {
        driver.FindElement(usernameInput).SendKeys(username);
    }

    private void EnterPassword(string password)
    {
        driver.FindElement(passwordInput).SendKeys(password);
    }

    private void ClickLoginButton()
    {
        driver.FindElement(loginButton).Click();
    }
}
