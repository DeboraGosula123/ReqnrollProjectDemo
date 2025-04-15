using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ReqnrollProjectDemo.Helpers;

namespace ReqnrollProjectDemo.Pages
{
    public class GmailLoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait wait;
        private readonly UIActions _uiActions;

        public GmailLoginPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
           _uiActions = new UIActions(driver);
        }

        private IWebElement emailField => _driver.FindElement(By.Id("identifierId"));
        private IWebElement nextButton => _driver.FindElement(By.XPath("//span[text()='Next']"));
        private IWebElement passwordField => _driver.FindElement(By.XPath("//input[@name=\"Passwd\"]"));
        private IWebElement LoginerrorMessage => _driver.FindElement(By.XPath("//div[text()=\"Couldn’t find your Google Account\"]"));
        private IWebElement PasswordErrorMessage => _driver.FindElement(By.XPath("//span[contains(text(), 'Wrong password')]")); 
        private IWebElement StepVerificationLabel => _driver.FindElement(By.XPath("//span[contains(text(), '2-Step Verification')]"));
        private IWebElement inboxElement => _driver.FindElement(By.XPath("//a[text()='Inbox']"));
        private IWebElement inbox => _driver.FindElement(By.XPath("//a[@title='Inbox']"));

        public void GmailLogin(string email, string password)
        {           
            _uiActions.SendKeys(emailField, email);
             wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Passwd")));
            _uiActions.SendKeys(passwordField, password);
            _uiActions.Click(nextButton);
        }
        public void InvalidLogin(string email, string password)
        {
            _uiActions.SendKeys(emailField, email);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Passwd")));
            _uiActions.SendKeys(passwordField, password);
            IsLoginErrorDisplayed();
        }

        public bool GetInboxVisibility()
        {
            //returns the boolean value of the inbox element
            return inboxElement.Displayed;
        }

        public void IsLoginErrorDisplayed()
        {
            // Retrieving the error message
            string actualMessage = LoginerrorMessage.Text;

            // Expected error message
            string expectedMessage = "Couldn’t find your Google Account";

            // Assert the message
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Couldn’t find your Google Account!");
        }
        public void IsPasswordErrorDisplayed()
        {
            // Retrieving the error message
            string actualMessage = PasswordErrorMessage.Text;

            // Expected error message
            string expectedMessage = "Wrong password";

            // Assert the message
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Wrong password!");
        }

    }
}

