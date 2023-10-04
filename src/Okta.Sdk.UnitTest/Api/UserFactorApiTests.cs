using System.Linq;
using System.Net;
using Xunit;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTest.Internal;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using WireMock.Server;

namespace Okta.Sdk.UnitTest.Api
{
    public class UserFactorApiTests
    {
        private readonly WireMockServer _server;

        public UserFactorApiTests()
        {
            _server = WireMockServer.Start();
        }

        public void Dispose()
        {
            _server.Stop();
        }

        [Fact]
        public async Task GetVerifyUserFactorResponseTransactionIdViaLinks()
        {

            var response = @"{
                  ""expiresAt"": ""2015-04-01T15:57:32.000Z"",
                  ""factorResult"": ""WAITING"",
                  ""profile"":{
                     ""credentialId"":""jane.doe@example.com""
                  },
                  ""_links"": {
                    ""poll"": {
                      ""href"": ""https://${yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/opfh52xcuft3J4uZc0g3/transactions/verificationTransactionId"",
                      ""hints"": {
                        ""allow"": [
                          ""GET""
                        ]
                      }
                    },
                    ""cancel"": {
                      ""href"": ""https://${yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/opfh52xcuft3J4uZc0g3/transactions/v2mst.GldKV5VxTrifyeZmWSQguA"",
                      ""hints"": {
                        ""allow"": [
                          ""DELETE""
                        ]
                      }
                    }
                  }
                }";

            var mockClient = new MockAsyncClient(response, HttpStatusCode.OK);
            var userFactorApi = new UserFactorApi(mockClient, new Configuration { BasePath = "https://foo.com" });

            var verifyUserFactorResponse = await userFactorApi.VerifyFactorAsync("foo", "bar");

            var transactionId = verifyUserFactorResponse.Links.Poll.Href.Split('/').Last();

            transactionId.Should().Be("verificationTransactionId");
        }
    }
}
