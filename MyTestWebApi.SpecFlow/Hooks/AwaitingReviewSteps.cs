using TechTalk.SpecFlow;

namespace MyTestWebApi.SpecFlow.Hooks
{
    [Binding]
    [Scope(Tag = "awaitingReviewBeforeStartingWork")]
    public class AwaitingReviewSteps
    {
        [Given(".*")]
        [When(".*")]
        [Then(".*")]
        public void Empty()
        {

        }

    }
}
