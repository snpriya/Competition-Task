using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompetitionTaskMars;
using CompetitionTaskMars.Pages;
using CompetitionTaskMars.Utilities;
using CompetitionTaskMars.Pages;
using CompetitionTaskMars.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionTaskMars.Utilities
{

    public class CommonDriver
    {
        public static IWebDriver driver;
        SignIn loginPageObj;
        ShareSkill ShareSkillObj;
        ManageListing ManageListingObj;

        //public static int Browser = 2;
        public static String ExcelPath = @"C:\MarsCompetitionTask\Competition-Task\CompetitionTaskMars\CompetitionTaskMars\ExcelData\signIn.xlsx";
        public static string ScreenshotPath = @"C:\MarsCompetitionTask\Competition-Task\CompetitionTaskMars\CompetitionTaskMars\MarsLib\Screenshot\";
        public static string ReportPath = @"C:\MarsCompetitionTask\Competition-Task\CompetitionTaskMars\CompetitionTaskMars\MarsLib\TestReports\";
        public static string SampleWorkPath = @"C:\MarsCompetitionTask\Competition-Task\CompetitionTaskMars\CompetitionTaskMars\MarsLib\AutoIt\autoscript.exe";
        #region reports
        public static AventStack.ExtentReports.ExtentReports extent;
        public static AventStack.ExtentReports.ExtentTest test;
        #endregion

        #region setup and tear down
        [OneTimeSetUp]
        protected void ExtentStart()
        {
            //Initialize report

            string reportName = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + @"Reports"
            + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("_dd-MM-yyyy_HHmm") + Path.DirectorySeparatorChar;

            //start reporters
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportName);
            htmlReporter.Config.DocumentTitle = "Automation Report";//Title of the report
            htmlReporter.Config.ReportName = "Functional Report"; //Name of the report.
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Information need to be display on the report 
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "Test Environment");
            extent.AddSystemInfo("USerName", "sathya");
            extent.AddSystemInfo("Browser", "Chrome");



        }

        [SetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();
           SignIn loginPageObj = new SignIn();

            ShareSkillObj = new ShareSkill();
            driver.Manage().Window.Maximize();
           // driver.Navigate().GoToUrl("http://localhost:5000/");
            loginPageObj.NavigatetoHomepage();
            ShareSkillObj.WelcomeMessageCheck();
            //loginPageObj.TestNegative();
            // profile.welcomeMessage();

        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = GlobalDefinitions.Screenshot.SaveScreenshot(driver, "ScreenShots");
            // log with snapshot
            var exec_status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            string TC_Name = TestContext.CurrentContext.Test.Name;
            string base64 = GlobalDefinitions.Screenshot.GetScreenshot(driver);

            Status logStatus = Status.Pass;
            switch (exec_status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    test.Log(Status.Fail, exec_status + errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    test.Log(Status.Skip, errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Inconclusive:

                    logStatus = Status.Warning;
                    test.Log(Status.Warning, "Test");
                    break;

                case TestStatus.Passed:

                    logStatus = Status.Pass;
                    test.Log(Status.Pass, "Test Passed");
                    break;

                default:
                    break;
            }


            //// Close the driver   
            driver.Close();
            driver.Quit();
        }


        [OneTimeTearDown]
        public void CloseTestRun()
        {
            Thread.Sleep(2000);
            extent.Flush();
            Thread.Sleep(2000);

        }
        #endregion


    }

}