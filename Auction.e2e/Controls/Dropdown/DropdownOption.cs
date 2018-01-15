using OpenQA.Selenium;

namespace Auction.e2e.Controls.Dropdown
{
    public class DropdownOption:BaseControl
    {
        public DropdownOption(IWebDriver driver, IWebElement rootElement) : base(driver, rootElement)
        {
        }

        public string Text
        {
            get
            {
                return RootElement.Text;
            }
        }

        public bool Selected
        {
            get { return RootElement.FindElement(By.TagName("button")).GetAttribute("class").Contains("checked"); }
            set
            {
                if (Selected != value)
                {
                    RootElement.FindElement(By.TagName("button")).Click();
                }
            }
        }

        public void Choose()
        {
            this.Scroll();

            RootElement.Click();
        }

        private void Scroll()
        {
            (new OpenQA.Selenium.Interactions.Actions(Driver)).MoveToElement(RootElement).Perform();
            //TODO Wait animation
            System.Threading.Thread.Sleep(2000);
        }
    }
}
