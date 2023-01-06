using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace QuickitdotnetSelenium
{
	public class InLineTestCaseAttribute
	{
		private IWebDriver driver;

		[SetUp]
		public void Setup() {

			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Manage().Window.Maximize();
			driver.Url = "https://bstackdemo.com/";
		}


		[TestCase("OnePlus", "6 Product(s) found.")]

		[TestCase("Google", "3 Product(s) found.")]
		public void Device(String model, String message) {

			DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);

			fluentwait.Timeout = TimeSpan.FromSeconds(7);

			fluentwait.PollingInterval = TimeSpan.FromMilliseconds(250);
			fluentwait.Until(driver => driver.Title == "StackDemo");
			
			   //1st time	   ==> One Plus
			driver.FindElement(By.XPath($"//*[@class='checkmark' and contains(text(), '{model}')]")).Click();



			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
			Thread.Sleep(3000);
			var sel = "//small[@class='products-found']//span";
			//small[@class='products-found']//span
			String searchResult =	driver.FindElement(By.XPath(sel)).Text;
		  Assert.That(message, Is.EqualTo(searchResult));
			Console.WriteLine(message);
			
			// deselection 
			driver.FindElement(By.XPath($"//*[@class='checkmark' and contains(text(), '{model}')]")).Click();



		}

		[TearDown]
		public void teardown() {

			driver.Close();
		}
	}
}
