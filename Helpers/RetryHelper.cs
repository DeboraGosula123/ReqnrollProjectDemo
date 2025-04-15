using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ReqnrollProjectDemo.Helpers
{
    public static class RetryHelper
    {
        public static void RetryAction(Action action, int maxAttempts = 3, int delayInMilliseconds = 1000)
        {
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                try
                {
                    action();
                    return;
                }
                catch (WebDriverException ex) when (
                    ex is ElementClickInterceptedException ||
                    ex is StaleElementReferenceException ||
                    ex is ElementNotInteractableException)
                {
                    attempts++;
                    if (attempts >= maxAttempts)
                        throw;

                    Thread.Sleep(delayInMilliseconds);
                }
            }
        }
    }
}
