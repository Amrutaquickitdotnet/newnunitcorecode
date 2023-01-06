using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace QuickitdotnetSelenium
{
	internal class DatePicker
	{
		WebDriver driver;

		[OneTimeSetUp]
		public void Launchbrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Manage().Window.Maximize();

		}


		[Test]
		[Order(1)]
		public void SelectDate()
		{
			driver.Url = "https://seleniumpractise.blogspot.com/2016/08/how-to-handle-calendar-in-selenium.html";
			Thread.Sleep(3000);

			driver.FindElement(By.XPath("//*[text() ='Date: ']/input")).Click();
			List<IWebElement> tablecontent = new List<IWebElement>( driver.FindElements(By.XPath("//table[@class='ui-datepicker-calendar']//td")));
			//get all the dates
			Thread.Sleep(2000);
			foreach(IWebElement element in tablecontent)
			{
				string date = element.Text;

				if (date.Equals("29")) 
				{
					element.Click();

					break;
				
				}
				

			}
			//driver.Close();

		}
	}
}
