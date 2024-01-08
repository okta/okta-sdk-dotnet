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
using WireMock.ResponseBuilders;
using Newtonsoft.Json.Linq;

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

        [Fact]
        public async Task EnrollOVFactor()
        {

            var response = @"{
                                ""id"": ""emfnf3gSScB8xXoXK0g3"",
                                ""factorType"": ""email"",
                                ""provider"": ""OKTA"",
                                ""vendorName"": ""OKTA"",
                                ""status"": ""PENDING_ACTIVATION"",
                                ""_links"": {
                                    ""activate"": {
                                        ""href"": ""https://{yourOktaDomain}/api/v1/users/00umvfJKwXOQ1mEL50g3/factors/emfnf3gSScB8xXoXK0g3/lifecycle/activate"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""POST""
                                            ]
                                        }
                                    },
                                    ""resend"": [
                                        {
                                            ""name"": ""email"",
                                            ""href"": ""https://{yourOktaDomain}/api/v1/users/00umvfJKwXOQ1mEL50g3/factors/emfnf3gSScB8xXoXK0g3/resend"",
                                            ""hints"": {
                                                ""allow"": [
                                                    ""POST""
                                                ]
                                            }
                                        }
                                    ],
                                    ""self"": {
                                        ""href"": ""https://{yourOktaDomain}/api/v1/users/00umvfJKwXOQ1mEL50g3/factors/emfnf3gSScB8xXoXK0g3"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""GET""
                                            ]
                                        }
                                    },
                                    ""user"": {
                                        ""href"": ""https://{yourOktaDomain}/api/v1/users/00umvfJKwXOQ1mEL50g3"",
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

            var enrollFactorResponse = await userFactorApi.EnrollFactorAsync("foo",
                new EmailUserFactor
                {
                    FactorType = FactorType.Email,
                    Profile = new EmailUserFactorProfile
                    {
                        Email = "test@gmail.com"
                    }
                });

            mockClient.ReceivedBody.Should().BeEquivalentTo("{\"profile\":{\"email\":\"test@gmail.com\"},\"factorType\":\"email\"}");
            enrollFactorResponse.FactorType.Should().Be(FactorType.Email);
            enrollFactorResponse.Provider.Should().Be(FactorProvider.OKTA);
        }

        [Fact]
        public async Task EnrollCustomTotpFactor()
        {

            var response = @"{
                                ""id"": ""chf20l33Ks8U2Zjba0g4"",
                                ""factorType"": ""token:hotp"",
                                ""provider"": ""CUSTOM"",
                                ""vendorName"": ""Entrust Datacard"",
                                ""status"": ""ACTIVE"",
                                ""created"": ""2019-07-22T23:22:36.000Z"",
                                ""lastUpdated"": ""2019-07-22T23:22:36.000Z"",
                                ""_links"": {
                                    ""self"": {
                                        ""href"": ""https://{yourOktaDomain}/api/v1/users/00utf43LCCmTJVcsK0g3/factors/chf20l33Ks8U2Zjba0g4"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""GET"",
                                                ""DELETE""
                                            ]
                                        }
                                    },
                                    ""verify"": {
                                        ""href"": ""https://{yourOktaDomain}/api/v1/users/00utf43LCCmTJVcsK0g3/factors/chf20l33Ks8U2Zjba0g4/verify"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""POST""
                                            ]
                                        }
                                    },
                                    ""user"": {
                                        ""href"": ""https://{yourOktaDomain}/api/v1/users/00utf43LCCmTJVcsK0g3"",
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

            var enrollFactorResponse = await userFactorApi.EnrollFactorAsync("foo",
                new CustomHotpUserFactor
                {
                    FactorType = FactorType.Tokenhotp,
                    Provider = FactorProvider.CUSTOM,
                    FactorProfileId = "fpr20l2mDyaUGWGCa0g4",
                    Profile = new CustomHotpUserFactorProfile
                    {
                        SharedSecret = "123",
                    }

                });

            mockClient.ReceivedBody.Should().BeEquivalentTo("{\"factorProfileId\":\"fpr20l2mDyaUGWGCa0g4\",\"profile\":{\"sharedSecret\":\"123\"},\"factorType\":\"token:hotp\",\"provider\":\"CUSTOM\"}");
            enrollFactorResponse.FactorType.Should().Be(FactorType.Tokenhotp);
            enrollFactorResponse.Provider.Should().Be(FactorProvider.CUSTOM);
        }

        [Fact]
        public async Task VerifyWebAuthnFactor()
        {
            var response = @"{
                              ""factorResult"":""SUCCESS"",
                              ""profile"":{
                                ""credentialId"":""l3Br0n-7H3g047NqESqJynFtIgf3Ix9OfaRoNwLoloso99Xl2zS_O7EXUkmPeAIzTVtEL4dYjicJWBz7NpqhGA"",
                                ""authenticatorName"":""MacBook Touch ID""
                              },
                              ""test"":true
                            }";

            var mockClient = new MockAsyncClient(response, HttpStatusCode.OK);
            var userFactorApi = new UserFactorApi(mockClient, new Configuration { BasePath = "https://foo.com" });

            var verifyFactorRequest = new VerifyFactorRequest
            {
                ClientData = "foo",
                AuthenticatorData = "bar",
                SignatureData = "baz",
            };

            var verifyResponse = await userFactorApi.VerifyFactorAsync("bax", "pcm", body: verifyFactorRequest);
            mockClient.ReceivedBody.Should().BeEquivalentTo("{\"clientData\":\"foo\",\"authenticatorData\":\"bar\",\"signatureData\":\"baz\"}");
            verifyResponse.FactorResult.Should().Be(VerifyUserFactorResult.SUCCESS);
            var profile = (JObject)verifyResponse.AdditionalProperties["profile"];
            profile["credentialId"].ToString().Should().Be("l3Br0n-7H3g047NqESqJynFtIgf3Ix9OfaRoNwLoloso99Xl2zS_O7EXUkmPeAIzTVtEL4dYjicJWBz7NpqhGA");
            profile["authenticatorName"].ToString().Should().Be("MacBook Touch ID");
        }
    }
}
