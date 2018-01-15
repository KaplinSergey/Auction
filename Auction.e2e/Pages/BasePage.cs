using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Linq;

namespace Auction.e2e.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateTo(string menuName)
        {
            Driver.FindElement(By.ClassName("link_tabs__labels")).FindElements(By.TagName("a")).First(e => e.Text.ToLower() == menuName.ToLower()).Click();
            WaitSpinner();
        }

        public virtual void WaitSpinner()
        {

            var timeout = TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["timeout"]));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            var waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["loadingTimeout"])));
            waiter.Until(b => b.FindElements(By.XPath("//*[contains(@class, 'spin')]")).Count == 0);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            waiter.Until(b => b.FindElements(By.XPath("//*[text() = 'Loading...']")).Count == 0);

            Driver.Manage().Timeouts().ImplicitWait = timeout;
        }

    }
}
