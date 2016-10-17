using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;

namespace DesignPatternsModule
{
	public class SeleniumLib
	{
		IWebDriver driver;

		static SeleniumLib instance;
		SeleniumLib() { }
		public static SeleniumLib getInstance()
		{
			if (instance == null) { instance = new SeleniumLib(); }
			return instance;
		}
		public void InitDriver()
		{
			var driverTypeName = ConfigurationManager.AppSettings.Get("bt");
			Type type = typeof(IWebDriver).Assembly.GetType(string.Format("OpenQA.Selenium.{0}.{0}Driver", driverTypeName));
			try
			{
				driver = (IWebDriver)Activator.CreateInstance(type);
			}
			catch (ArgumentNullException e) { throw new Exception("Type cannot be recognized. Specify webdriver type in App.config correctly. Ex: Chrome"); }
		}
		public void CloseDriver() {
			driver.Close();		
		}

	}

}
