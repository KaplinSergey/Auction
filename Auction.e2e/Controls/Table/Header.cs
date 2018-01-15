using Auction.e2e.Controls.Interfaces.Table;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.e2e.Controls.Table
{
  class Header : BaseControl, IHeader
  {
    public Header(IWebDriver driver, IWebElement rootElement) : base(driver, rootElement)
    {
    }

    public string Text
    {
        get
        {
            return RootElement.Text;
        }
    }
  }
}
