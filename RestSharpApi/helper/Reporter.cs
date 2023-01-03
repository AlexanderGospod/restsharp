using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpApi.helper
{
    public static class Reporter
    {
        private static ExtentReports extentReport;
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentTest extentTest;

        public static void SetUpReport(dynamic path, string documentTitle, string reportName)
        {
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.EnableTimeline = true;
            htmlReporter.Config.CSS = "css-string";
            htmlReporter.Config.DocumentTitle = "page title";
            htmlReporter.Config.Encoding = "utf-8";
            htmlReporter.Config.JS = "js-string";
            htmlReporter.Config.ReportName = "build name";
            htmlReporter.Config.Theme = Theme.Dark;

            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);
        }

        public static void LogToReport(Status status, string message)
        {
            extentTest.Log(status, message);
        }
        public static void LogToReport(string message)
        {
            extentTest.Info(message);
        }

        public static void CreateTest(string testName)
        {
            extentTest = extentReport.CreateTest(testName);
        }

        public static void FlushReport()
        {
            extentReport.Flush();
        }

        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                extentTest.Pass("Test case passed");
            }
            else
            {
                extentTest.Fail("Test case failed");              
            }
        }
    }
}