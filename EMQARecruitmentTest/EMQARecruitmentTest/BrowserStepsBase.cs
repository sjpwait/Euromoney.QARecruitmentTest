using TechTalk.SpecFlow;

namespace EMQARecruitmentTest
{
    [Binding]
    public class BrowserStepsBase
    {
        public BrowserContext BrowserContext { get; }
        public BrowserStepsBase(BrowserContext browserContext)
        {
            BrowserContext = browserContext;
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            //BrowserContext.Browser.Close();
        }
    }
}
