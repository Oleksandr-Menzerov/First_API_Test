using RestSharp;
using System;
using TechTalk.SpecFlow;
using System.Text.Json;
using Newtonsoft.Json;
using System.Linq;
using NUnit.Framework;

namespace First_API_Test.StepDefinitions
{
    [Binding]
    public class FirstAPITestsSteps : CommonMethods
    {
        private readonly ScenarioContext _scenarioContext;
        public static RestResponse? _response;

        public FirstAPITestsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I send ""([^""]*)"" request")]
        public static void WhenISendRequest(string method)
        {
            var restClient = new RestClient("https://localhost:7069/");
            var request = new RestRequest("api/rockers", GetMethod(method));
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            //request.AddHeader("Accept", "application/json");

            request.AddHeader("Connection", "keep-alive");
            request.AddParameter("application/json", ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody("");
            //request.AddBody(new Item {    ItemName = someName,    Price = 19.99 });
            _response = restClient.Execute(request);
            //_scenarioContext["response"] = response;
            //_scenarioContext["responseCode"]  = response.StatusCode;
            //_scenarioContext["responseBody"] = response.Content;
        }

        [Then(@"I should get response with (.*) code")]
        public static void ThenIShouldGetResponseWithCode(int code)
        {
            Assert.AreEqual(code, (int)_response.StatusCode, $"Expected code is {code}, but actual is {(int)_response.StatusCode}");
        }

        [Then(@"Response should contain new Id")]
        public static void ThenResponseShouldContainNewId()
        {
            _response.Content.Should().Contain("Id");
            throw new PendingStepException();
        }

        [Then(@"Response should contain instance with given Id")]
        public static void ThenResponseShouldContainInstanceWithGivenId()
        {
            throw new PendingStepException();
        }

        [When(@"I send ""([^""]*)"" request with ""([^""]*)"" and ""([^""]*)"" with given Id")]
        public static void WhenISendRequestWithNameAndBandWithGivenId(string method, string name, string band)
        {
            throw new PendingStepException();
        }

        [When(@"I send ""([^""]*)"" request with given Id")]
        public static void WhenISendRequestWithGivenId(string method)
        {
            throw new PendingStepException();
        }

        [Then(@"Response should contain only an instance with ""([^""]*)"", ""([^""]*)"" and given Id")]
        public static void ThenResponseShouldContainOnlyAnInstanceWithNameBandAndGivenId(string name, string band)
        {
            throw new PendingStepException();
        }

        [When(@"I send ""([^""]*)"" request with ""([^""]*)"" with given Id")]
        public static void WhenISendRequestWithBandWithGivenId(string method, string band)
        {
            throw new PendingStepException();
        }

        [Then(@"Response should not contain instance with given Id")]
        public static void ThenResponseShouldNotContainInstanceWithGivenId()
        {
            throw new PendingStepException();
        }
    }
}
