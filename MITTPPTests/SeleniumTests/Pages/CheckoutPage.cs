using OpenQA.Selenium;

public class CheckoutPage
{
    private readonly IWebDriver driver;

    // Locators
    private By firstNameInput = By.Id("first-name");
    private By lastNameInput = By.Id("last-name");
    private By zipCodeInput = By.Id("postal-code");
    private By checkoutButton = By.Id("checkout");
    private By finishButton = By.Id("finish");
    private By continueButton = By.Id("continue");

    private By orderConfirmationContainer = By.Id("checkout_complete_container");

    // Constructor
    public CheckoutPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    // Action methods
    public void GoToCheckout()
    {
        driver.FindElement(checkoutButton).Click();
    }

    public void InputUserInfo(string firstName, string lastName, string zipCode)
    {
        driver.FindElement(firstNameInput).SendKeys(firstName);
        driver.FindElement(lastNameInput).SendKeys(lastName);
        driver.FindElement(zipCodeInput).SendKeys(zipCode);

        driver.FindElement(continueButton).Click();
    }

    public void FinishCheckout()
    {
        driver.FindElement(finishButton).Click();
    }

    public string GetOrderConfirmation()
    {
        Thread.Sleep(300);

        IWebElement confirmationContainerElement = driver.FindElement(orderConfirmationContainer);

        string confirmationText = confirmationContainerElement.Text;

        return confirmationText;
    }
}
