using NUnit.Framework;
using OpenQA.Selenium;
using ReqnrollProjectDemo.Utilities;

namespace ReqnrollProjectDemo.Hooks
{
    [SetUpFixture]
    public class Hooks
    {
        private IWebDriver driver;        
        
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            AppLogger.Init();
            AppLogger.Info("=== Test Suite Execution Started ===");
        }
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

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            AppLogger.Info("=== Test Suite Execution Completed ===");
            AppLogger.Close();
        }
    }
}
