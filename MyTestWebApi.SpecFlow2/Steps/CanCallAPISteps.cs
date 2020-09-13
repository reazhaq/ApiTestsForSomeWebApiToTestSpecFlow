using FluentAssertions;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace MyTestWebApi.SpecFlow2.Steps
{
    [Binding]
    public class CanCallAPISteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IRestClient _api;
        private IRestResponse<string> _response;

        public CanCallAPISteps(ScenarioContext scenarioContext, ITestOutputHelper testOutputHelper)
        {
            _scenarioContext = scenarioContext;
            _testOutputHelper = testOutputHelper;
            _api = new RestClient("http://localhost:53134/api/");
        }

        [Given(@"steady state")]
        public void GivenSteadyState()
        {
            _testOutputHelper.WriteLine($"{nameof(GivenSteadyState)} is called");
        }
        
        [When(@"I pass (.*) to the end-point")]
        public void WhenIPassValueToTheEnd_Point(string value)
        {
            _testOutputHelper.WriteLine($"{nameof(WhenIPassValueToTheEnd_Point)} is called");
            var request = new RestRequest("Some");
            request.AddParameter("value", value);
            //request.AddUrlSegment("someValue", value);
            request.AddHeader("accept", "*/*");

            _response = _api.Execute<string>(request);
        }

        [Then(@"I see (.*) in response")]
        public void ThenISeeValueWasTheParamInResponse(string returnValue)
        {
            _testOutputHelper.WriteLine($"{nameof(ThenISeeValueWasTheParamInResponse)} is called");
            _response.StatusCode.Should().Be(HttpStatusCode.OK);
            _response.Content.Should().NotBeNullOrEmpty()
                .And.Be(returnValue);
        }
    }
}
