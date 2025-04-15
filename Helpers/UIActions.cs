using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ReqnrollProjectDemo.Helpers
{
    public class UIActions
    {
        private readonly IWebDriver _driver;

        public UIActions(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Click(IWebElement element)
        {
            RetryHelper.RetryAction(() => element.Click());
        }

        public void SendKeys(IWebElement element, string text)
        {
            RetryHelper.RetryAction(() =>
            {
                element.Clear();
                element.SendKeys(text);
            });
        }

        public IWebElement WaitForElement(By locator, int timeoutInSeconds = 10)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
