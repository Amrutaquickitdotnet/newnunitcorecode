using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using WebDriverManager.DriverConfigs.Impl;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace QuickitdotnetSelenium
{


	
	public class GenerateReport
	{

		static AventStack.ExtentReports.ExtentReports extent;
		public WebDriver driver;
		public ExtentTest test ;

	
		[OneTimeSetUp]
		public void ExtentStart()
		{

			
			extent = new AventStack.ExtentReports.ExtentReports();

			
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();

		}

		[Test]
		public void Login()
		{


			test = extent.CreateTest("Test1").Info("Test Srarted");
			driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
			test.Log(Status.Info, "chrome browser launched");


			Thread.Sleep(6000);
			IWebElement Username = driver.FindElement(By.XPath("//input[@name='username']"));


			Username.SendKeys("Admin");

			IWebElement Password = driver.FindElement(By.XPath("//input[@name='password']"));

			Password.SendKeys("admin12");

			IWebElement LoginButton = driver.FindElement(By.XPath("//button[@type='submit']"));

			LoginButton.Click();

			test.Log(Status.Pass, "User Landing on Dashboard Page");

			test.Log(Status.Error, "Test failed");
		}


		[OneTimeTearDown]
		public void End()
		{

			var Htmlreporter = new ExtentHtmlReporter(@"D:\Trupti\ExtentReports\");
			extent.AttachReporter(Htmlreporter);

			extent.Flush();
			
		}

	}

}
