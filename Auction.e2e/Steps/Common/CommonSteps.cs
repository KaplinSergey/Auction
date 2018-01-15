using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using System.Diagnostics;
using System.Configuration;
using Auction.e2e.Pages.Login;
using Auction.e2e.Pages.Lots;

namespace Auction.e2e.Steps.Common
{
    [Binding]
    class CommonSteps : TechTalk.SpecFlow.Steps
    {
        private static bool _isFirstLogin = true;
        private static readonly object FirstLoginLockObject = new object();

        [Given(@"I am logged in as ""(.*)"" in Auction")]
        public void GivenIAmLoggedInAsInAuction(string userName)
        {
            var browser = DriverFactory.New();

            this.ScenarioContext.Set(browser, "browser");

            browser.Navigate().GoToUrl("http://localhost:37447/Account/Login");

            var loginPage = new LoginPage(browser)
            {
                UserName = "s.k.85@tut.by",
                Password = "12345678"
            };

            var loginButtonClicked = false;
            lock (FirstLoginLockObject)
            {
                if (_isFirstLogin)
                {
                    loginPage.Login();
                    loginButtonClicked = true;

                    _isFirstLogin = false;
                }
            }

            if (!loginButtonClicked)
            {
                loginPage.Login();
            }

            var newPage = new LotsPage(browser);
            newPage.WaitSpinner();

            this.ScenarioContext.Set(newPage, "page");
        }

        [When(@"I visit ""(.*)""")]
        public void WhenIVisit(string url)
        {
            var browser = this.ScenarioContext.Get<IWebDriver>("browser");
            browser.Navigate().GoToUrl("http://localhost:37447/" + url);

            var newPage = this.ScenarioContext.Get<LotsPage>("page");
            //var newPage = PageFinder.Find(browser, url);
            newPage.WaitSpinner();
            this.ScenarioContext.Set(newPage, "page");
        }
    }
}
