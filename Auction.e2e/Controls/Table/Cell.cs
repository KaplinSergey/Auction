using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.e2e.Controls.Interfaces.Table;

namespace Auction.e2e.Controls.Table
{
  class Cell : BaseControl, ICell
  {
    public Cell(IWebDriver driver, IWebElement rootElement) : base(driver, rootElement)
    {
    }

    public string Text
    {
        get
        {
            return RootElement.Text;
        }
    }

    public void OpenDetails()
    {
      throw new NotImplementedException();
    }

    public void SetValue(string value)
    {
      RootElement.Click();

      var input = RootElement.FindElement(By.TagName("input"));

      input.SendKeys(Keys.Control + "a");
      input.SendKeys(value);
      input.SendKeys(Keys.Enter);
    }
  }
}
