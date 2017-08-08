using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Auction.e2e
{
    class DriverFactory
    {       
        public static IWebDriver New()
        {
            BrowserType browserType;
            Enum.TryParse(ConfigurationManager.AppSettings["browser"], out browserType);

            IWebDriver browser = null;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    browser = new ChromeDriver();
                    break;               
            }
            browser.Manage().Window.Maximize();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["timeout"]));

            return browser;
        }
    }
    public enum BrowserType
    {
        Chrome,
        Firefox,
        Remote
    }
}
