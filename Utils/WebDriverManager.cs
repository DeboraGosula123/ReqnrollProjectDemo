using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ReqnrollProject1.Drivers
{
    public class WebDriverManager
    {
        private static WebDriverManager _instance; // Singleton instance
        private IWebDriver _driver; // WebDriver instance

        // Private constructor to prevent object instantiation
        private WebDriverManager() { }

        // Public method to get the Singleton instance
        public static WebDriverManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WebDriverManager();
            }
            return _instance;
        }

        // Method to initialize WebDriver
        public IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
            }
            return _driver;
        }

        // Method to close the driver
        public void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null; // Reset instance after quitting
            }
        }
    }
}

