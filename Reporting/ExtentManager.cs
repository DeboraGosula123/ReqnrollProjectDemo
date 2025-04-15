using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;


namespace ReqnrollProjectDemo.Reporting
{
     public static class ExtentManager
     {
        private static AventStack.ExtentReports.ExtentReports _extent;        
        private static ExtentHtmlReporter _htmlReporter;       

           public static AventStack.ExtentReports.ExtentReports GetExtent()
           {
            if (_extent == null)
            {
                // Define the directory and file for the report
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string reportDir = Path.Combine(Directory.GetCurrentDirectory(), "Reports");
                Directory.CreateDirectory(reportDir);

                string reportPath = Path.Combine(reportDir, $"TestReport_{timestamp}.html");

                // Create an instance of the HTML reporter
                _htmlReporter = new ExtentHtmlReporter(reportPath);

                // Optional: Configure HTML reporter theme and other settings
                _htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
                _htmlReporter.Config.ReportName = "Automation Test Report";
                _htmlReporter.Config.DocumentTitle = "UI Test Results";

                // Initialize ExtentReports and attach the HTML reporter
                _extent = new ExtentReports();
                _extent.AttachReporter(_htmlReporter);

                // Add system info for the report
                _extent.AddSystemInfo("Environment", "QA");
                _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
                _extent.AddSystemInfo("User", Environment.UserName);
                _extent.AddSystemInfo("Browser", "Chrome"); // Adjust as necessary
            }

            return _extent;
        }
    }
    }

