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
	public class InLineRangeAttribute
	{
		private IWebDriver driver;

		[OneTimeSetUp]
		public void Setup() {

			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Manage().Window.Maximize();
			driver.Url = "https://bstackdemo.com/";
		}


		[Test]

		public void Checkquantity([Values(".bag__quantity")]String selector, [Range(2,3,1)] int value) {


			DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);

			fluentwait.Timeout = TimeSpan.FromSeconds(7);

			fluentwait.PollingInterval = TimeSpan.FromMilliseconds(250);
			fluentwait.Until(driver => driver.Title == "StackDemo");

			driver.FindElement(By.CssSelector($"{selector} .shelf-item:nth-of-type({value}) .shelf-item__buy-btn")).Click();
			Thread.Sleep(5000);

			int cartQty = Int32.Parse(driver.FindElement(By.CssSelector(".float-cart__header .bag__quantity")).Text);

			//Assertion 

			//Assert.That(cartQty, Is.EqualTo(value-1));


		}

		[TearDown]
		public void teardown() {

			driver.Close();
		}
	}
}
