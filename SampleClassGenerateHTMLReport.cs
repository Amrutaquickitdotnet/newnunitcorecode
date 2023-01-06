using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
 

namespace QuickitdotnetSelenium
{
	 
	public class SampleClassGenerateHTMLReport
	{
		private static ExtentReports extent;
		private static ExtentHtmlReporter htmlReporter;
		private static ExtentTest test;

		[OneTimeSetUp]
		public void ClassInitialize()
		{
			// create the reporter
			htmlReporter = new ExtentHtmlReporter("extent.html");
			htmlReporter.Config.Theme = Theme.Dark;

			// create the ExtentReports object
			extent = new ExtentReports();
			extent.AttachReporter(htmlReporter);
		}

		[SetUp]
		public void TestInitialize()
		{
			// create a test
			test = extent.CreateTest("MyTestMethod");
		}

		[Test]
		public void MyTestMethod()
		{
			// log a status message
			test.Log(Status.Info, "This is my test method");

			// perform some assertions
			Assert.IsTrue(1 + 1 == 2);
			Assert.IsFalse(1 + 1 == 3);
		}

		[TearDown]
		public void TestCleanup()
		{
			// log a status message
			test.Log(Status.Info, "This is my test cleanup method");
		}

		[OneTimeTearDown]
		public void ClassCleanup()
		{
			// log a status message
			test.Log(Status.Info, "This is my class cleanup method");

			// flush the report to disk
			extent.Flush();
		}
	}
}
