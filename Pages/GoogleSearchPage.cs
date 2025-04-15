using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ReqnrollProjectDemo.Pages
{
    public class GoogleSearchPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait wait;

        public GoogleSearchPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement SearchBox => _driver.FindElement(By.XPath("//textarea[@name='q']"));
        private IWebElement PageTitle => _driver.FindElement(By.XPath("//h1[text()=\"Selenium automates browsers. That's it!\"]"));
        private IWebElement Text1 => _driver.FindElement(By.XPath("//p[text()=\"What you do with that power is entirely up to you.\"]"));
        private IWebElement Text2 => _driver.FindElement(By.XPath("//p[contains(text(), 'Primarily it is for automating web applications')]"));
        private IWebElement FirstResult => _driver.FindElement(By.CssSelector("h3"));
        private IWebElement FirstResultLink => _driver.FindElement(By.XPath("//h1[contains(text(),\"Selenium automates browsers. That's it!\")]"));
        
        // Actions: Enter SearchText
        public void EnterSearchText(string enterText)
        {
            SearchBox.SendKeys(enterText);
            SearchBox.SendKeys(Keys.Enter); 
        }        

        public void ClickFirstLink()
        {
            FirstResult.Click();
        }
        
        public void ValidatePageTitle(string expectedTitle)
        {
            Assert.That(_driver.Title, Is.EqualTo(expectedTitle), "Title does not contain the expected text!");
        }        

     }
}

