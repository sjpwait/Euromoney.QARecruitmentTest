using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace EMQARecruitmentTest
{
    internal class TeamMember
    {
        public string FullName { get; set; }
        public string JobTitle { get; internal set; }
        public ReadOnlyCollection<IWebElement> Description { get; internal set; }
        public string PictureUrl { get; internal set; }
    }
}
