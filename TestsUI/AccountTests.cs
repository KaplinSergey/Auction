using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace TestsUI
{
    [TestClass]
    public class AccountTests:SeleniumTest
    {
        public AccountTests()
            : base("MvcPL")
        { }

        [TestMethod]
        public void Login_button_click_should_redirect_to_login_Page_()
        {
            //Arrang
            GoToIndexPage();
            
            
            //Act
            this.ChromeDriver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul.nav.navbar-nav.navbar-right > li:nth-child(2) > a")).Click();
            string resultUrl = this.ChromeDriver.Url;


            //Assert
            Assert.AreEqual(@"http://localhost:37447/Account/Login", resultUrl);
        }
        [TestMethod]
        public void Authorize_and_redirect_to_User_Page_()
        {
            //Arrang
            GoToIndexPage();
            this.ChromeDriver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul.nav.navbar-nav.navbar-right > li:nth-child(2) > a")).Click();

            //Act           
            IWebElement emailTextBox = this.ChromeDriver.FindElement(By.Id("Email"));
            emailTextBox.SendKeys("s.k.85@tut.by");
            IWebElement passwordTextBox = this.ChromeDriver.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys("12345678");
            this.ChromeDriver.FindElement(By.XPath("//form/div/div/input[@value='Login']")).Click();
            string resultUserName = this.ChromeDriver.FindElement(By.XPath("//ul[2]/li[1]/h5")).Text;
            this.ChromeDriver.FindElement(By.CssSelector("ul.navbar-right:last-child a")).Click();
            string resultUrl=this.ChromeDriver.Url;

            //Assert
            Assert.AreEqual("s.k.85@tut.by", resultUserName);
            Assert.AreEqual(@"http://localhost:37447/User/UserPanel", resultUrl);
        }

        [TestMethod]
        public void Search_lots_should_return_lots_list()
        {
            //Arrang
            GoToIndexPage();

            //Act           
            IWebElement searchTextBox = this.ChromeDriver.FindElement(By.Id("lot"));
            searchTextBox.SendKeys("Zte");
            searchTextBox.SendKeys(Keys.Enter);
            IList<IWebElement> resultLotList = this.ChromeDriver.FindElements(By.PartialLinkText("ZTE"));
            //WebDriverWait wait = new WebDriverWait(this.ChromeDriver, TimeSpan.FromSeconds(10));
            //IList<IWebElement> resultLotList = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.PartialLinkText("Zte")));

            //Assert
            Assert.AreEqual(2, resultLotList.Count);
        }


        private void GoToIndexPage()
        {
            this.ChromeDriver.Manage().Window.Maximize();
            this.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            this.ChromeDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/Lot/Index"));
        }

    }
}
