using Auction.e2e.Controls.Interfaces.Table;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Auction.e2e.Controls.Table
{
    class Table : BaseControl, ITable
    {
        public Table(IWebDriver driver, IWebElement rootElement)
            : base(driver, rootElement)
        {
        }

        public List<IHeader> Headers
        {
            get
            {
                return
                    RootElement.FindElement(By.TagName("thead"))
                        .FindElements(By.TagName("th"))
                        .Select(th => (IHeader)new Header(Driver, th))
                        .ToList();
            }
        }

        public List<IRow> Rows
        {
            get
            {
                return
                    RootElement.FindElement(By.TagName("tbody"))
                        .FindElements(By.TagName("tr"))
                        .Select(th => (IRow)new Row(Driver, th, this))
                        .ToList();
            }
        }
    }
}
