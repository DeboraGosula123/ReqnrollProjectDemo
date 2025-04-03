using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReqnrollProjectDemo.Utils;

namespace ReqnrollProjectDemo.Hooks
{
    public class Hooks
    {
        private IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = WebDriverSingleton.Instance.Driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverSingleton.Instance.QuitDriver();
        }
    }
}
