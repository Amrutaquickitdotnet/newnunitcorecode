using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using WebDriverManager.DriverConfigs.Impl;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace QuickitdotnetSelenium
{


	[TestFixture]
	public class GenerateReportGoogle
	{

		static ExtentReports extent;
		public WebDriver driver;
		ExtentTest test ;


		[OneTimeSetUp]
		public void ExtentStart()
		{
			

			extent = new ExtentReports();

			 extent.AddSystemInfo("Environment", "Test Environment");
			


		}



		[Test]
		public void Login()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();


			test = extent.CreateTest("Test1").Info("Test Srarted");
			driver.Navigate().GoToUrl("https://www.google.com");
			test.Log(Status.Info, "chrome browser launched");
			try
			{
				Thread.Sleep(6000);
				IWebElement Username = driver.FindElement(By.Name("qe"));


				Username.SendKeys("Quickitdotnet");



				//test.Log(Status.Pass, "Search Page");

			}
			catch
			{
				test.Log(Status.Skip, "Test failed");
			}



		}

											   
		[OneTimeTearDown]	 // Once your step has (Test Case) 	  been completed 
		public void End()
		{

			var Htmlreporter = new ExtentHtmlReporter(@"D:\Trupti\ExtentReports\");
			extent.AttachReporter(Htmlreporter);

		 	extent.Flush();	 // Thread -Safe 
		}

	}

}
