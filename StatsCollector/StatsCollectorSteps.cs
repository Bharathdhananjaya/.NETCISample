using System;
using TechTalk.SpecFlow;

namespace StatCollector
{
 
    // Dont check in this to Master Branch.
    
    [Binding]
    public class StatsCollectorSteps
    {
        [Given(@"I have the Following Nacre Row")]
        public void GivenIHaveTheFollowingNacreRow(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I Invoke the Stats Collector")]
        public void WhenIInvokeTheStatsCollector()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be as Below")]
        public void ThenTheResultShouldBeAsBelow(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
