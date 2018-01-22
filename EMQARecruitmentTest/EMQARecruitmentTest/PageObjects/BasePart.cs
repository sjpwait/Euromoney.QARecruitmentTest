using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EMQARecruitmentTest.PageObjects
{
    public class BasePart
    {
        public BasePart(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public IWebDriver Driver { get; }
    }
}
