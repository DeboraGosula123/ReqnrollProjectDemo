using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ReqnrollProjectDemo.Pages;
using ReqnrollProjectDemo.Utils;
using SeleniumExtentReports;
using SeleniumExtras.WaitHelpers;

namespace ReqnrollProjectDemo.Tests
{
    [TestFixture]
    public class LoginTest : TestBase
    {
        private IWebDriver driver;
        private GoogleSearchPage googleSearchPage;
        private WebDriverWait wait;
        
        [SetUp]
        public void Setup()
        {
            driver = WebDriverSingleton.Instance.Driver;
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        [Test]
        public void GoogleSearch()
        {
            driver.Manage().Window.Maximize();

            // Create an instance of GoogleSearchPage and pass the WebDriver instance
            var googleSearchPage = new GoogleSearchPage(driver);

            // Find the search box and enter "Selenium" and click Enter key
            googleSearchPage.EnterSearchText("Selenium");

            // Wait until the search results are loaded
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h3")));

            // Click on the first search result
            googleSearchPage.ClickFirstLink();

            //Validate PageTitle of Current Page
            googleSearchPage.ValidatePageTitle();
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverSingleton.Instance.QuitDriver();
        }
    }
    public class GoogleSearchPage
    {
        private readonly IWebDriver _driver;

        public GoogleSearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterSearchText(string text)
        {
            var searchBox = _driver.FindElement(By.Name("q"));
            searchBox.SendKeys(text);
            searchBox.SendKeys(Keys.Enter);
        }

        public void ClickFirstLink()
        {
            var firstLink = _driver.FindElement(By.CssSelector("h3"));
            firstLink.Click();
        }

        public void ValidatePageTitle()
        {
            Assert.That(_driver.Title.Contains("Selenium"), Is.True);
        }
    }
}
