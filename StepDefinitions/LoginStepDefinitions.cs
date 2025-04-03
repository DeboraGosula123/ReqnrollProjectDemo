using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using ReqnrollProjectDemo;
using ReqnrollProjectDemo.Pages;
using ReqnrollProjectDemo.Utils;

namespace ReqnrollProjectDemo.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        private GmailLoginPage loginPage;

        [Given("I navigate to login page")]
        public void GivenINavigateToLoginPage()
        {
            driver = WebDriverSingleton.Instance.Driver;
            driver.Navigate().GoToUrl("https://mail.google.com/");
            loginPage = new GmailLoginPage(driver);
        }

        [When("I enter username and password")]
        public void WhenIEnterUsernameAndPassword()
        {
            loginPage.GmailLogin("Selautomation81@gmail.com", "Jesus123$");
        }

        [When("click on Login button")]
        public void WhenClickOnLoginButton()
        {
            loginPage.GmailLogin("invalid_email@gmail.com", "invalid_password");
        }        

        [When("I choose (.*) and (.*)")]
        public void WhenIEnterUsereAndPassy(String username, string password)
        {
            Console.WriteLine("username" + username);
        }
        [When("I enter {string} and {string}")]
        public void WhenIEnterAnd(string invalidUser, string wrongPass)
        {
            loginPage.GmailLogin("invalid_email@gmail.com", "invalid_password");
        }

        [Then("I should see an error message {string}")]
        public void ThenIShouldSeeAnErrorMessage(string ExpectedErrorMessage)
        {
            String ActualErrorMessage = "Invalid username or password";
            Assert.That(ActualErrorMessage, Is.EqualTo(ExpectedErrorMessage), "Invalid user credentials");
        }
        
    }
}
   
