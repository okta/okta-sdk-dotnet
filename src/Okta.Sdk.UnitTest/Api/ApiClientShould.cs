using System;
using System.Linq;
using System.Net;
using Xunit;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTest.Internal;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using RestSharp;

namespace Okta.Sdk.UnitTest.Api
{
    public class ApiClientShould
    {
        [Fact]
        public void SendUserAgent()
        {

            var apiClient = new ApiClient();
            var client = apiClient.GetConfiguredClient(new Configuration(), null);

            client.UserAgent.Should().Contain("okta-sdk-dotnet");

        }
    }
}
