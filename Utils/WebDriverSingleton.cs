using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace ReqnrollProjectDemo.Utils
{
    public class WebDriverSingleton
    {
        private static WebDriverSingleton _instance;
        private static readonly object _lock = new object();
        private IWebDriver _driver;

        private WebDriverSingleton()
        {
            InitializeDriver();
        }

        private void InitializeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");  // Open in maximized mode
            options.AddArgument("--disable-popup-blocking"); // Ensure no pop-ups block execution
            options.AddArgument("--disable-gpu"); // Optional: Helps in some environments

            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Ensure elements are found properly
        }

        public static WebDriverSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new WebDriverSingleton();
                        }
                    }
                }
                return _instance;
            }
        }

        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
                _instance = null;
            }
        }
        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
            WebDriverSingleton.Instance.QuitDriver();
        }
    }
}
