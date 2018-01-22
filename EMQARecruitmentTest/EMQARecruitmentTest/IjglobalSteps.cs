using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EMQARecruitmentTest
{
    [Binding]
    public sealed class IjglobalSteps : BrowserStepsBase
    {
        public IjglobalSteps(BrowserContext browserContext) : base(browserContext)
        {
        }

        [Then(@"the Url is (.*)")]
        public void ThenTheUrlIs(string url)
        {
            BrowserContext.Browser.Url.Should().Be(url);
        }

        [Then(@"the Page Title is '(.*)'")]
        public void ThenThePageTitleIs(string p0)
        {
            BrowserContext.Browser.Title.Should().Be(p0);
        }

        [Then(@"the league table is displayed")]
        public void ThenTheLeagueTableIsDisplayed()
        {
            BrowserContext.Browser.FindElement(By.Id("leagueTable")).Should().NotBeNull();
        }

        [Then(@"the menu shows the '(.*)' link")]
        public void ThenTheMenuShowsTheLink(string p0)
        {
            Assert.Fail("Unable to find the menu or the link manually");
        }


    }
}
