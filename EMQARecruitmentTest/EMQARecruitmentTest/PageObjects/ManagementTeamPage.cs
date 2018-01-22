using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace EMQARecruitmentTest.PageObjects
{
    public class ManagementTeamPage : BasePage
    {
        public ManagementTeamPage(IWebDriver driver) : base(driver)
        {
        }

        internal IEnumerable<TeamMember> GetTeamMembers()
        {
            var teamMemberElements = Driver.FindElements(By.CssSelector("div.w_content_generic"));

            foreach (var member in teamMemberElements)
            {
                yield return new TeamMember
                {
                    FullName = member.FindElement(By.TagName("h2")).Text,
                    JobTitle = member.FindElement(By.TagName("h5")).Text,
                    Description = member.FindElements(By.TagName("p")),
                    PictureUrl = member.FindElement(By.TagName("img")).GetAttribute("src")
                };
            }
        }
    }
}
