using Auction.e2e.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction.e2e.Controls.Dropdown
{
    class Dropdown:BaseControl
    {
        public Dropdown(IWebDriver driver, IWebElement rootElement) : base(driver, rootElement)
        {
        }

        public string SelectedValue
        {
            get
            {
                var value = RootElement.FindElement(By.XPath("./div[contains(@class, 'dropdown-toggler__value')]")).Text;
                return value;
            }
        }

        public bool Expanded
        {
            get { return RootElement.GetAttribute("class").Contains("dropdown-toggler--active"); }
            set
            {
                if (Expanded != value)
                {
                    RootElement.Click();

                    //TODO wait 3 second for animation
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        public List<DropdownOption> Options
        {
            get
            {
                Expanded = true;

                var menuElement = Driver.FindElements(By.XPath("//div[contains(@class, 'dropdown-menu') or contains(@class, 'multiselect-list')]")).First(m => m.Displayed);

                var optionsXpath = ".//li[contains(@class, 'multiselect-option') or contains(@class, 'dropdown-option') or contains(@class, 'h-dropdown-item')]";

                // wait at least one option in dropdown
                try
                {
                    var waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                    waiter.Until(d => menuElement.FindElements(By.XPath(optionsXpath)).Count > 0);
                }
                catch (Exception)
                {
                }

                var options = menuElement.FindElements(By.XPath(optionsXpath))
                    .Select(li => new DropdownOption(Driver, li))
                    .ToList();
                return options;
            }
        }

        public void SearchOption(string optionName)
        {
            Expanded = true;

            var searchElement = Driver.FindElements(By.ClassName("search-input__input")).First(e => e.Displayed);
            searchElement.SendKeys(optionName);

            new BasePage(Driver).WaitSpinner();
        }

        public void Select(params string[] optionNames)
        {
            Expanded = true;

            foreach (var optionName in optionNames)
            {
                var option = Options.FirstOrDefault(o => o.Text == optionName);

                if (option == null)
                {
                    throw new Exception("There is no '{optionName}' option in dropdown.");
                }

                option.Selected = true;
            }

            Expanded = false;
        }

        public void Choose(string optionName)
        {
            Expanded = true;

            var option = Options.FirstOrDefault(o => o.Text == optionName);

            if (option == null)
            {
                throw new Exception("There is no '{optionName}' option in dropdown.");
            }
            option.Choose();

            //TODO: Waiting animation
            System.Threading.Thread.Sleep(2000);
        }
    }
}
