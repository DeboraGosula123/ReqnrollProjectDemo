using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace ReqnrollProjectDemo.Drivers
{
    public static class WebDriverFactory
    {
        private static ThreadLocal<IWebDriver> threadLocalDriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver(string browser = "chrome")
        {
            if (threadLocalDriver.Value == null)
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                        threadLocalDriver.Value = new ChromeDriver();
                        break;

                    case "chrome-headless":
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--headless");
                        chromeOptions.AddArgument("--window-size=1920,1080");
                        threadLocalDriver.Value = new ChromeDriver(chromeOptions);
                        break;

                    case "firefox":
                        threadLocalDriver.Value = new FirefoxDriver();
                        break;

                    case "edge":
                        threadLocalDriver.Value = new EdgeDriver();
                        break;

                    // Add more browsers as needed
                    default:
                        throw new ArgumentException($"Unsupported browser: {browser}");
                }
            }
            return threadLocalDriver.Value;
        }

        public static void QuitDriver()
        {
            if (threadLocalDriver.Value != null)
            {
                threadLocalDriver.Value.Quit();
                threadLocalDriver.Value.Dispose();
                threadLocalDriver.Value = null;
            }
        }
    }
}