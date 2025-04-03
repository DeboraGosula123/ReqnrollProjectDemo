using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ReqnrollProjectDemo.Pages;
using ReqnrollProjectDemo.Utils;
using SeleniumExtentReports;
using SeleniumExtras.WaitHelpers;

namespace ReqnrollProject1.Tests
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = WebDriverSingleton.Instance.Driver;
            driver.Navigate().GoToUrl("https://www.google.com"); // Ensure navigation

        }

        [Test]
        public void GoogleSearch()
        {
            driver.Manage().Window.Maximize();

            // Create an instance of LoginPage and pass the WebDriver instance
            var loginPage = new LoginPage(driver);

            // Find the search box and enter "Selenium" and click Enter key
            loginPage.EnterSearchText("Selenium");

            // Wait until the search results are loaded
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h3")));

            // Click on the first search result
            loginPage.ClickFirstLink();

            //Validate PageTitle of Current Page
            ValidatePage("Selenium");

            loginPage.ValidatePageTitle1("Selenium automates browsers. That's it!");
        }       

    private void ValidatePage(string expectedTitle)
        {
            string actualTitle = driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Page title does not match.");
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverSingleton.Instance.QuitDriver();
        }
    }
}
