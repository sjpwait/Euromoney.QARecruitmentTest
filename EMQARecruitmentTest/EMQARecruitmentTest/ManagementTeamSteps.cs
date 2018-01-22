using System.Linq;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;
using EMQARecruitmentTest.PageObjects;
using FluentAssertions;
using System.Net;
using System.Net.Http;

namespace EMQARecruitmentTest
{
    [Binding]
    public class ManagementTeamSteps : BrowserStepsBase
    {
        
        public ManagementTeamContext ManagementTeamContext { get; }

        public ManagementTeamSteps(BrowserContext browserContext, ManagementTeamContext managementTeamContext) : base(browserContext)
        {
            ManagementTeamContext = managementTeamContext;
        }

        [Then(@"each team member has a section")]
        public void ThenEachTeamMemberHasASection(Table table)
        {
            ManagementTeamContext.ExpectedTeamMembers = table.CreateSet<TeamMember>().ToList();

            var managementPage = new ManagementTeamPage(BrowserContext.Browser);
            ManagementTeamContext.ActualTeamMembers = managementPage.GetTeamMembers().ToList();

            ManagementTeamContext.ActualTeamMembers.ToList().Count.Should().Be(ManagementTeamContext.ExpectedTeamMembers.Count);
        }


        [Then(@"each team member has Name")]
        public void ThenEachTeamMemberHasName()
        {
            ManagementTeamContext.ActualTeamMembers.ForEach(t => t.FullName.Should().NotBeNullOrEmpty());
        }

        [Then(@"each team member has Job Title")]
        public void ThenEachTeamMemberHasJobTitle()
        {
            ManagementTeamContext.ActualTeamMembers.ForEach(t => t.JobTitle.Should().NotBeNullOrEmpty());
        }

        [Then(@"each team member has Picture")]
        public void ThenEachTeamMemberHasPicture()
        {
            ManagementTeamContext.ActualTeamMembers.ForEach(t => {
                var picture = new WebClient().DownloadData(t.PictureUrl);
                picture.Should().NotBeNullOrEmpty();
            });
        }

        [Then(@"each team member has Description")]
        public void ThenEachTeamMemberHasDescription()
        {
            ManagementTeamContext.ActualTeamMembers.ForEach(t => t.Description.Should().NotBeNullOrEmpty());
        }


    }
}
