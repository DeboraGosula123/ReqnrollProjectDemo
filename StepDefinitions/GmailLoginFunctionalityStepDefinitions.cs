using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollProjectDemo.Pages;
using ReqnrollProjectDemo.Utils;

namespace ReqnrollProjectDemo.StepDefinitions
{
    [Binding]
    public class VerifyGmailLoginFunctionalityStepDefinitions
    {
        private IWebDriver driver;
        private GmailLoginPage loginPage;

        [SetUp]
        [Given("I navigate to Gmail login page")]
        public void GivenINavigateToGmailLoginPage()
        {
            driver = WebDriverSingleton.Instance.Driver;
            driver.Navigate().GoToUrl("https://mail.google.com/");
            loginPage = new GmailLoginPage(driver);
        }

        [When("I enter valid email and password")]
        public void WhenIEnterValidEmailAndPassword()
        {
            loginPage.GmailLogin("Selautomation81@gmail.com", "Jesus123$");            
        }

        [Then("I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            loginPage.IsInboxVisible();
        }

        [When("I enter invalid email and password")]
        public void WhenIEnterInvalidEmailAndPassword()
        {
            loginPage.InvalidLogin("Selautomation181@gmail.com", "invalid_password");
            
        }

        [Then("I  should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            loginPage.IsLoginErrorDisplayed();
        }       
                
        [When(@"I enter email ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterEmailAndPassword(string email, string password)
        {
            loginPage.GmailLogin(email, password);
        }
    }
}
