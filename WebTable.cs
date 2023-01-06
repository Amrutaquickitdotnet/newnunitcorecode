using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace QuickitdotnetSelenium
{
	public class WebTable
	{
		IWebDriver driver;

		[OneTimeSetUp]
		public void Launchbrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Manage().Window.Maximize();

		}
		[Test, Order(1)]
		public void Test_Table()
		{
			driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites");

			Thread.Sleep(5000);

			var ElementTable = driver.FindElement(By.XPath("//table[@class='wikitable sortable jquery-tablesorter']"));

			IList<IWebElement> ListTrElement = new List<IWebElement>(ElementTable.FindElements(By.TagName("tr")));

			// Traverse Each row 

			String strRowData = "";
			//Fetch all row of the table 
			// Tr => number of rows whereas Td represent no of
			foreach (var EleTr in ListTrElement)
			{

				IList<IWebElement> ListTdElement = new List<IWebElement>(EleTr.FindElements(By.TagName("td")));

				if (ListTdElement.Count > 0)
				{
					foreach (var ElemTd in ListTdElement)
					{

						strRowData = strRowData + ElemTd.Text + "\t";

					}
				Console.WriteLine(strRowData);

				}
				else
				{
					//Console.WriteLine("*****This is header row*******" + "\n");
				Console.WriteLine(ListTrElement[0].Text.Replace(" ", "\t"));
					
					Console.WriteLine(strRowData);
					strRowData = String.Empty;
				}
				Console.WriteLine(" ");

			}
		}
	}

}                               
	

