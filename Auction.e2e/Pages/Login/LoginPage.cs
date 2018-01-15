using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.e2e.Pages.Login
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        public string UserName
        {
            set
            {
                var el = Driver.FindElement(By.Name("Email"));
                el.Clear();
                el.SendKeys(value);
            }
        }

        public string Password
        {
            set
            {
                var el = Driver.FindElement(By.Name("Password"));
                el.Clear();
                el.SendKeys(value);
            }
        }

        public void Login()
        {
            Driver.FindElement(By.Id("loginButton")).Click();
        }

        public string ErrorMessage
        {
            get { return Driver.FindElements(By.CssSelector(".field-validation-error")).Select(e => e.Text).Aggregate((a, b) => a + "\n" + b); }
        }
    }
}
