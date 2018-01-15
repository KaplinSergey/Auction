using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Auction.e2e.Controls
{
    public class BaseControl
    {
        protected IWebDriver Driver;
        protected IWebElement RootElement;

        public BaseControl(IWebDriver driver, IWebElement rootElement)
        {
            Driver = driver;
            RootElement = rootElement;
        }
    }
}
