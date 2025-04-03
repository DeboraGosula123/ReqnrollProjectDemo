using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ReqnrollProjectDemo.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver) => _driver = driver;
        public IWebElement SearchBox => _driver.FindElement(By.XPath("//textarea[@name='q']"));
        public IWebElement PageTitle => _driver.FindElement(By.XPath("//h1[text()=\"Selenium automates browsers. That's it!\"]"));
        public IWebElement Text1 => _driver.FindElement(By.XPath("//p[text()=\"What you do with that power is entirely up to you.\"]"));
        public IWebElement Text2 => _driver.FindElement(By.CssSelector("p:contains(\"Primarily it is for automating web applications for testing purposes, but is certainly not limited to just that.\")"));
        public IWebElement FirstResult => _driver.FindElement(By.CssSelector("h3"));
        public IWebElement FirstResultLink => _driver.FindElement(By.XPath("//h1[contains(text(),\"Selenium automates browsers. That's it!\")]"));

        // Actions: Enter SearchText
        public void EnterSearchText(string enterText)
        {
            SearchBox.SendKeys(enterText);
            SearchBox.SendKeys(Keys.Enter); // Press Enter instead of clicking the search button
        }

        public void ValidatePageTitle1(string pageTitle1)
        {
            pageTitle1 = "Selenium automates browsers. That's it!";
            Assert.That(FirstResultLink.Text.Contains(pageTitle1), Is.True, "Title does not contain the expected text!");
        }

        public void ClickFirstLink()
        {
            FirstResult.Click();
        }
    }
}

