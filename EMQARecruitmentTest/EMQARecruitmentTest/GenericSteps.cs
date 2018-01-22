using System;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Firefox;
using EMQARecruitmentTest.PageObjects;
using FluentAssertions;
using System.Linq;

namespace EMQARecruitmentTest
{

    [Binding]
    public class GenericSteps : BrowserStepsBase
    {
        public GenericSteps(BrowserContext browserContext) : base(browserContext)
        {
        }

        [Given(@"I have a browser")]
        public void GivenIHaveABrowser()
        {
            BrowserContext.Browser = new FirefoxDriver();
            //BrowserContext.Browser = new OpenQA.Selenium.PhantomJS.PhantomJSDriver();
        }

        [Given(@"the browser is on EuroMoney")]
        public void GivenTheBrowserIsOnEuroMoney()
        {
            BrowserContext.Browser.Navigate().GoToUrl("http://www.euromoneyplc.com/");
        }

        [When(@"Navigate to management team")]
        public void WhenNavigateToManagementTeam()
        {
            var homePage = new HomePage(BrowserContext.Browser);
            homePage.OpenManagementTeamPage();
        }

        [Then(@"we are taken to the correct page")]
        public void ThenWeAreTakenToTheCorrectPage()
        {
            BrowserContext.Browser.Url.Should().Be("http://www.euromoneyplc.com/who-we-are/management-team");
        }

        [When(@"I Navigate to IJ Global Page")]
        public void WhenINavigateToIJGlobalPage()
        {
            var homePage = new HomePage(BrowserContext.Browser);
            var pdmiPage = homePage.OpenPricingDataAndMarketIntelligencePage();
            pdmiPage.ClickLink("Visit IJ Global", true);
        }


    }
}
