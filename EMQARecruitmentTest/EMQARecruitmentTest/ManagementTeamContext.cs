using System.Collections.Generic;

namespace EMQARecruitmentTest
{
    public class ManagementTeamContext
    {
        internal List<TeamMember> ExpectedTeamMembers { get; set; }
        internal List<TeamMember> ActualTeamMembers { get; set; }
    }
}
