using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EMQARecruitmentTest.PageObjects
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            Menu = new MenuPart(driver);
        }

        public MenuPart Menu { get; set; }

        public class MenuPart : BasePart
        {
            public MenuPart(IWebDriver driver) : base(driver)
            {
            }

            [FindsBy(How = How.LinkText, Using = "Who we are")]
            private IWebElement WhoWeAreLink { get; set; }
            public WhoWeArePart WhoWeAre { get; set; }

            public WhoWeArePart OpenWhoWeAre()
            {
                WhoWeAreLink.Click();
                return new WhoWeArePart(Driver);
            }

            public class WhoWeArePart : BasePart
            {
                public WhoWeArePart(IWebDriver driver) : base(driver)
                {
                }

                [FindsBy(How = How.LinkText, Using = "Management team")]
                private IWebElement ManagementTeamLink { get; set; }

                internal object OpenManagementTeam()
                {
                    ManagementTeamLink.Click();
                    return new ManagementTeamPage(Driver);
                }
            }
        }
    }
}
