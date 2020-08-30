using FluentAssertions;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
//using Xunit.Abstractions;

namespace MyTestWebApi.SpecFlow.Steps
{
    [Binding]
    public class SomeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        //private readonly ITestOutputHelper _testOutputHelper;
        private readonly RestClient _api;
        private IRestResponse<string> _response;

        //curl -X GET "http://localhost:53134/api/Some?value=sdsd" -H "accept: */*"
        public SomeSteps(ScenarioContext scenarioContext)//, ITestOutputHelper testOutputHelper)
        {
            _scenarioContext = scenarioContext;
            //_testOutputHelper = testOutputHelper;
            _api = new RestClient("http://localhost:53134/api/");
        }

        [Given]
        public void Given_steady_state()
        {
        }

        [When]
        public void When_I_pass_VALUE_to_the_end_point(string value)
        {
            var request = new RestRequest("Some");
            request.AddParameter("value", value);
            //request.AddUrlSegment("someValue", value);
            request.AddHeader("accept", "*/*");

            _response = _api.Execute<string>(request);
            //_testOutputHelper.WriteLine($"{_response}");
        }

        [Then]
        public void Then_I_see_RETURNVALUE_in_response(string returnValue)
        {
            _response.StatusCode.Should().Be(HttpStatusCode.OK);
            _response.Content.Should().NotBeNullOrEmpty()
                .And.Be(returnValue);
        }
    }
}
