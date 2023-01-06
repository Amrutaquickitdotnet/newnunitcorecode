using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Runtime.Intrinsics.X86;
using NPOI.Util.Collections;

namespace QuickitdotnetSelenium
{
	public class Read_Properties
	{


		IWebDriver driver;
		FileStream fs;
		Properties p;

		[OneTimeSetUp]
		public void Launchbrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Manage().Window.Maximize();

		}

		[Test, Order(1)]
		public void ReadData() {

			string path = @"D:\Trupti\TestData.properties";

			try
			{

				fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
			}
			catch (FileNotFoundException e1) {
				
				Console.WriteLine(e1.ToString());
						 Console.WriteLine(e1.Message);
			}

			p = new Properties();

			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

			p.Load(fs);


		}
		[Test, Order(2)]
		public void Login() {
			driver.Navigate().GoToUrl(p["Url"]);

			driver.FindElement(By.XPath(p["usernameXpath"])).SendKeys(p["usernameValue"]);
			driver.FindElement(By.XPath(p["passwordXpath"])).SendKeys(p["passwordValue"]);
			driver.FindElement(By.XPath(p["buttonLoginXpath"])).Click();

		}
	}
}
