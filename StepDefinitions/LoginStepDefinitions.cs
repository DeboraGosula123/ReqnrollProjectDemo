using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using ReqnrollProjectDemo;

namespace ReqnrollProjectDemo.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        
        [Given("I navigate to login page")]
        public void GivenINavigateToLoginPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com");            
        }

        [When("I enter username and password")]
        public void WhenIEnterUsernameAndPassword()
        {
            Console.WriteLine("I navigate to login page");
        }

        [When("click on Login button")]
        public void WhenClickOnLoginButton()
        {
            Console.WriteLine("I navigate to login page");
        }

        [Then("I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            Console.WriteLine("I navigate to login page");
        }

        [When("I choose (.*) and (.*)")]
        public void WhenIEnterUsereAndPassy(String username, string password)
        {
            Console.WriteLine("username" + username);
        }
        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
