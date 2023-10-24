using System.Linq;
using System.Net;
using Xunit;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTest.Internal;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using WireMock.Server;
using Okta.Sdk.Model;
using NJsonSchema.Extensions;

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

        [Fact]
        public async Task EnrollRsaFactor()
        {

            var response = @"{
                              ""id"": ""rsabtznMn6cp94ez20g4"",
                              ""factorType"": ""token"",
                              ""provider"": ""RSA"",
                              ""vendorName"": ""RSA"",
                              ""status"": ""ACTIVE"",
                              ""created"": ""2015-11-13T07:05:53.000Z"",
                              ""lastUpdated"": ""2015-11-13T07:05:53.000Z"",
                              ""profile"": {
                                ""credentialId"": ""dade.murphy@example.com""
                              },
                              ""_links"": {
                                ""verify"": {
                                  ""href"": ""https://{yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/rsabtznMn6cp94ez20g4/verify"",
                                  ""hints"": {
                                    ""allow"": [
                                      ""POST""
                                    ]
                                  }
                                },
                                ""self"": {
                                  ""href"": ""https://{yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/rsabtznMn6cp94ez20g4"",
                                  ""hints"": {
                                    ""allow"": [
                                      ""GET"",
                                      ""DELETE""
                                    ]
                                  }
                                },
                                ""user"": {
                                  ""href"": ""https://{yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL"",
                                  ""hints"": {
                                    ""allow"": [
                                      ""GET""
                                    ]
                                  }
                                }
                              }
                            }";

            var mockClient = new MockAsyncClient(response, HttpStatusCode.OK);
            var userFactorApi = new UserFactorApi(mockClient, new Configuration { BasePath = "https://foo.com" });

            var enrollFactorResponse = await userFactorApi.EnrollFactorAsync("foo", new TokenUserFactor
            {
                FactorType = FactorType.Token,
                Provider = "RSA",
                Profile = new TokenUserFactorProfile
                {
                    CredentialId = "foo",
                },
                Verify = new VerifyFactorRequest
                {
                    PassCode = "foo",
                }
            });

            mockClient.ReceivedBody.Should().BeEquivalentTo("{\"profile\":{\"credentialId\":\"foo\"},\"factorType\":\"token\",\"provider\":\"RSA\",\"verify\":{\"passCode\":\"foo\"}}");
            enrollFactorResponse.FactorType.Should().Be(FactorType.Token);
            enrollFactorResponse.Provider.Should().Be(FactorProvider.RSA);
        }

        [Fact]
        public async Task EnrollSymantecFactor()
        {

            var response = @"{
                              ""id"": ""ufvbtzgkYaA7zTKdQ0g4"",
                              ""factorType"": ""token"",
                              ""provider"": ""SYMANTEC"",
                              ""vendorName"": ""SYMANTEC"",
                              ""status"": ""ACTIVE"",
                              ""created"": ""2015-11-13T06:52:08.000Z"",
                              ""lastUpdated"": ""2015-11-13T06:52:08.000Z"",
                              ""profile"": {
                                ""credentialId"": ""VSMT14393584""
                              },
                              ""_links"": {
                                ""verify"": {
                                  ""href"": ""https://{yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/ufvbtzgkYaA7zTKdQ0g4/verify"",
                                  ""hints"": {
                                    ""allow"": [
                                      ""POST""
                                    ]
                                  }
                                },
                                ""self"": {
                                  ""href"": ""https://{yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/ufvbtzgkYaA7zTKdQ0g4"",
                                  ""hints"": {
                                    ""allow"": [
                                      ""GET"",
                                      ""DELETE""
                                    ]
                                  }
                                },
                                ""user"": {
                                  ""href"": ""https://{yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL"",
                                  ""hints"": {
                                    ""allow"": [
                                      ""GET""
                                    ]
                                  }
                                }
                              }
                            }";

            var mockClient = new MockAsyncClient(response, HttpStatusCode.OK);
            var userFactorApi = new UserFactorApi(mockClient, new Configuration { BasePath = "https://foo.com" });

            var enrollFactorResponse = await userFactorApi.EnrollFactorAsync("foo", new TokenUserFactor
            {
                FactorType = FactorType.Token,
                Provider = "SYMANTEC",
                Profile = new TokenUserFactorProfile
                {
                    CredentialId = "foo",
                },
                Verify = new VerifyFactorRequest
                {
                    PassCode = "foo",
                    NextPassCode = "foo",
                }
            });
            
            mockClient.ReceivedBody.Should().BeEquivalentTo("{\"profile\":{\"credentialId\":\"foo\"},\"factorType\":\"token\",\"provider\":\"SYMANTEC\",\"verify\":{\"nextPassCode\":\"foo\",\"passCode\":\"foo\"}}");
            enrollFactorResponse.FactorType.Should().Be(FactorType.Token);
            enrollFactorResponse.Provider.Should().Be(FactorProvider.SYMANTEC);
        }

        [Fact]
        public async Task EnrollYubicoFactor()
        {

            var response = @"{
                              ""id"": ""ykfbty3BJeBgUi3750g4"",
                              ""factorType"": ""token:hardware"",
                              ""provider"": ""YUBICO"",
                              ""vendorName"": ""YUBICO"",
                              ""status"": ""ACTIVE"",
                              ""created"": ""2015-11-13T05:27:49.000Z"",
                              ""lastUpdated"": ""2015-11-13T05:27:49.000Z"",
                              ""profile"": {
                                ""credentialId"": ""000004102994""
                              },
                              ""_links"": {
                                ""verify"": {
                                  ""href"": ""https://{yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/ykfbty3BJeBgUi3750g4/verify"",
                                  ""hints"": {
                                    ""allow"": [
                                      ""POST""
                                    ]
                                  }
                                },
                                ""self"": {
                                  ""href"": ""hhttps://{yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL/factors/ykfbty3BJeBgUi3750g4"",
                                  ""hints"": {
                                    ""allow"": [
                                      ""GET"",
                                      ""DELETE""
                                    ]
                                  }
                                },
                                ""user"": {
                                  ""href"": ""https://{yourOktaDomain}/api/v1/users/00u15s1KDETTQMQYABRL"",
                                  ""hints"": {
                                    ""allow"": [
                                      ""GET""
                                    ]
                                  }
                                }
                              }
                            }";

            var mockClient = new MockAsyncClient(response, HttpStatusCode.OK);
            var userFactorApi = new UserFactorApi(mockClient, new Configuration { BasePath = "https://foo.com" });

            var enrollFactorResponse = await userFactorApi.EnrollFactorAsync("foo", new TokenUserFactor
            {
                FactorType = FactorType.Tokenhardware,
                Provider = "YUBICO",
                Verify = new VerifyFactorRequest
                {
                    PassCode = "foo",
                }
            });

            mockClient.ReceivedBody.Should().BeEquivalentTo("{\"factorType\":\"token:hardware\",\"provider\":\"YUBICO\",\"verify\":{\"passCode\":\"foo\"}}");
            enrollFactorResponse.FactorType.Should().Be(FactorType.Tokenhardware);
            enrollFactorResponse.Provider.Should().Be(FactorProvider.YUBICO);
        }
    }
}
