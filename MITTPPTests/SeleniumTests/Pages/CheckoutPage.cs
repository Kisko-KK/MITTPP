using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


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
    private By totalPriceLocator = By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[8]");


    public CheckoutPage(IWebDriver driver)
    {
        this.driver = driver;
    }

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
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        IWebElement confirmationContainerElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(orderConfirmationContainer));

        string confirmationText = confirmationContainerElement.Text;

        return confirmationText;
    }

    public string GetTotalPrice()
    {
        // Use WebDriverWait to wait for the element to be present
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(totalPriceLocator));

        // Find the total price element
        IWebElement totalPriceElement = driver.FindElement(totalPriceLocator);

        string totalPriceText = totalPriceElement.Text;

        return totalPriceText;
    }



}
