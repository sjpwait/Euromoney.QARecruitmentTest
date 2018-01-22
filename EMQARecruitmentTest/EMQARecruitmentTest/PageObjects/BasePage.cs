using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace EMQARecruitmentTest.PageObjects
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public IWebDriver Driver { get; }

        public IWebDriver ClickLink(string linkText, bool openInNewWindow = false)
        {
            var initialHandles = Driver.WindowHandles;
            Driver.FindElement(By.LinkText(linkText)).Click();

            if (openInNewWindow)
            {
                WebDriverWait waitForNewWindow = new WebDriverWait(Driver, new System.TimeSpan(0, 0, 5));
                waitForNewWindow.Until((driver) =>
                {
                    var ih = string.Join("", initialHandles.OrderBy(h => h));
                    var ch = string.Join("", driver.WindowHandles.OrderBy(h => h));
                    return ch != ih;
                });

                WebDriverWait notAboutBlank = new WebDriverWait(Driver, new System.TimeSpan(0, 0, 5));
                notAboutBlank.Until((driver) =>
                {
                    return driver.Url != "about:blank";
                });

                return Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            }
            return Driver;
        }
    }
}
