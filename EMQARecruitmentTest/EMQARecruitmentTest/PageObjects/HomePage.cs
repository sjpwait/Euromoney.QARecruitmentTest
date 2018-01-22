using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EMQARecruitmentTest.PageObjects
{
    class HomePage : MainPage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "a.menu_trigger")]
        private IWebElement MenuButton { get; set; }
        
        public MenuPart OpenMenu()
        {
            MenuButton.Click();
            return new MenuPart(Driver);
        }

        public ManagementTeamPage OpenManagementTeamPage()
        {
            var menu = OpenMenu();
            var whoWeAre = menu.OpenWhoWeAre();
            var managementTeam = whoWeAre.OpenManagementTeam();
            return new ManagementTeamPage(Driver);
        }

        internal PricingDataAndMarketIntelligencePage OpenPricingDataAndMarketIntelligencePage()
        {
            var menu = OpenMenu();
            var ourPortfolio = menu.OpenOurPortfolio();
            var pdmi = ourPortfolio.OpenPricingDataAndMarketIntelligence();
            return new PricingDataAndMarketIntelligencePage(Driver);
        }
    }
}
