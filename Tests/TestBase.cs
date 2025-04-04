using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReqnrollProjectDemo.Utils;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;

namespace SeleniumExtentReports
{
    public class TestBase
    {
        private static AventStack.ExtentReports.ExtentReports extent;
        private ExtentTest test;
        private static ExtentHtmlReporter htmlReporter;
        protected IWebDriver driver;

        [OneTimeSetUp]
        public static void SetupReport()
        {
            //string reportPath = @"C:\\Users\\Debora Gosula\\source\\repos\\ReqnrollProject1\\HtmlReports\\ExtentReport.html";
            string reportPath = @"E:\\DeboraGosula\\HtmlReports\\ExtentReport.html";
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void StartTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void EndTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            if (status == TestStatus.Failed)
            {
                test.Fail("Test Failed: " + stackTrace);
            }
            else if (status == TestStatus.Passed)
            {
                test.Pass("Test Passed");
            }
            else
            {
                test.Skip("Test Skipped");
            }
        }        

        [OneTimeTearDown]
        public static void TearDownReport()
        {
            if (extent != null)
            {
                extent.Flush(); // This is necessary to generate the report
            }
        }

    }
}
