using Auction.e2e.Controls.Interfaces.Table;
using Auction.e2e.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.e2e.Controls.Table
{
  class Row : BaseControl, IRow
  {
    protected readonly ITable _table;
    public Row(IWebDriver driver, IWebElement rootElement, ITable table) : base(driver, rootElement)
    {
      _table = table;
    }

    public List<Cell> Cells
    {
      get { return RootElement.FindElements(By.TagName("td")).Select(td => new Cell(Driver, td)).ToList(); }
    }

    public BasePage OpenDetails()
    {
      throw new NotImplementedException();
    }

    void IRow.OpenDetails()
    {
      throw new NotImplementedException();
    }

    void IRow.Expand()
    {
      throw new NotImplementedException();
    }

    private List<IWebElement> _cellElements;
    public ICell this[string headerName]
    {
      get
      {
        var index = _table.Headers.FindIndex(h => h.Text.Trim() == headerName.ToUpper().Trim());

        if (index == -1)
        {
          throw new Exception(string.Format("'{0}' header not found in the table.", headerName));
        }

        if (_cellElements == null)
        {
          _cellElements = RootElement.FindElements(By.TagName("td")).ToList();
        }

        return new Cell(Driver, _cellElements[index]);
      }
    }

    public void Select()
    {
      RootElement.FindElement(By.TagName("a")).Click();
    }

    public bool Disabled
    {
      get
      {
        return this.RootElement.GetAttribute("class").Contains("disabled");
      }
    }
  }
}
