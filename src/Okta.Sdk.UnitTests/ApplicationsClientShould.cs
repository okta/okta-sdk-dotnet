// <copyright file="ApplicationsClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ApplicationsClientShould
    {
        [Fact]
        public void NotFailIfSignOnIsUnknown()
        {
            var rawResponse = @"{
                ""id"": ""0oafxqCAJWWGELFTYASJ"",
                ""name"": ""bookmark"",
                ""label"": ""Sample Bookmark App"",
                ""status"": ""ACTIVE"",
                ""lastUpdated"": ""2013-10-01T04:22:31.000Z"",
                ""created"": ""2013-10-01T04:22:27.000Z"",
                ""accessibility"": {
                    ""selfService"": false,
                    ""errorRedirectUrl"": null
                },
                ""visibility"": {
                    ""autoSubmitToolbar"": false,
                    ""hide"": {
                        ""iOS"": false,
                        ""web"": false
                    },
                    ""appLinks"": {
                        ""login"": true
                    }
                },
                ""features"":""[]"",
                ""signOnMode"": ""SOME_UNKNOWN_SIGN_ON_MODE"",
                ""credentials"": {
                    ""userNameTemplate"": {
                        ""template"": ""${source.login}"",
                        ""type"": ""BUILT_IN""
                    }
                },
                ""settings"": {
                    ""app"": {
                        ""requestIntegration"": false,
                        ""url"": ""https://example.com/bookmark.htm""
                    }
                },
            }";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = client.Applications.GetApplicationAsync<IApplication>("foo").Result;

            app.SignOnMode.Should().Be(new ApplicationSignOnMode("SOME_UNKNOWN_SIGN_ON_MODE"));
        }

        [Fact]
        public void NotReturnNullWhenFeaturesHasNoData()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetBookmarkApplicationStubResponse(features: "[]"));
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = client.Applications.GetApplicationAsync<IBookmarkApplication>("foo").Result;

            app.Features.Any().Should().BeFalse();
        }

        [Fact]
        public void ReturnEmptyListWhenFeaturesIsNullInTheResponse()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetBookmarkApplicationStubResponse());
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = client.Applications.GetApplicationAsync<IBookmarkApplication>("foo").Result;

            app.Features.Any().Should().BeFalse();
        }

        [Fact]
        public void AddCustomFeaturesToAnEmptyFeaturesList()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetBookmarkApplicationStubResponse(features: "[]"));
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = client.Applications.GetApplicationAsync<IBookmarkApplication>("foo").Result;
            app.Features.Any().Should().BeFalse();

            app.Features.Add("custom_feature");
            app.Features.Any().Should().BeTrue();
        }

        [Fact]
        public void AddCustomFeaturesToANonEmptyFeaturesList()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetBookmarkApplicationStubResponse(features: "[\"custom_feature1\"]"));
            var client = new TestableOktaClient(mockRequestExecutor);

            var app = client.Applications.GetApplicationAsync<IBookmarkApplication>("foo").Result;
            app.Features.Any().Should().BeTrue();

            app.Features.Add("custom_feature2");
            app.Features.Should().HaveCount(2);
        }

        [Fact]
        public async Task ListOAuthTokens()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetListOAuthTokensStubResponse());
            var client = new TestableOktaClient(mockRequestExecutor);

            var tokens = await client.Applications.ListOAuth2TokensForApplication("foo").ToListAsync();
            // Default limit
            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/foo/tokens?limit=20");

            tokens.Should().NotBeNullOrEmpty();
            tokens.FirstOrDefault().Id.Should().Be("oar579Mcp7OUsNTlo0g3");
            tokens.FirstOrDefault().Status.Should().Be("ACTIVE");
            tokens.FirstOrDefault().Created.Value.Date.Should().Be(new DateTime(2018, 3, 9));
            tokens.FirstOrDefault().LastUpdated.Value.Date.Should().Be(new DateTime(2018, 3, 9));
            tokens.FirstOrDefault().ExpiresAt.Value.Date.Should().Be(new DateTime(2018, 3, 16));
            tokens.FirstOrDefault().Issuer.Should().Be("https://${yourOktaDomain}/oauth2/ausain6z9zIedDCxB0h7");
            tokens.FirstOrDefault().ClientId.Should().Be("0oabskvc6442nkvQO0h7");
            tokens.FirstOrDefault().UserId.Should().Be("00u5t60iloOHN9pBi0h7");
            tokens.FirstOrDefault().Scopes.Should().Contain("offline_access");
            tokens.FirstOrDefault().Scopes.Should().Contain("car:drive");
        }

        [Fact]
        public async Task GetOAuthToken()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(GetOAuthTokenStubResponse());
            var client = new TestableOktaClient(mockRequestExecutor);

            var token = await client.Applications.GetOAuth2TokenForApplicationAsync("foo", "oar579Mcp7OUsNTlo0g3");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/apps/foo/tokens/oar579Mcp7OUsNTlo0g3");

            token.Should().NotBeNull();
            token.Id.Should().Be("oar579Mcp7OUsNTlo0g3");
            token.Status.Should().Be("ACTIVE");
            token.Created.Value.Date.Should().Be(new DateTime(2018, 3, 9));
            token.LastUpdated.Value.Date.Should().Be(new DateTime(2018, 3, 9));
            token.ExpiresAt.Value.Date.Should().Be(new DateTime(2018, 3, 16));
            token.Issuer.Should().Be("https://${yourOktaDomain}/oauth2/ausain6z9zIedDCxB0h7");
            token.ClientId.Should().Be("0oabskvc6442nkvQO0h7");
            token.UserId.Should().Be("00u5t60iloOHN9pBi0h7");
            token.Scopes.Should().Contain("offline_access");
            token.Scopes.Should().Contain("car:drive");
        }

        [Fact]
        public async Task BuildRevokeTokenRequest()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Applications.RevokeOAuth2TokenForApplicationAsync("foo", "bar");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/apps/foo/tokens/bar");
        }

        [Fact]
        public async Task BuildRevokeTokensRequest()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Applications.RevokeOAuth2TokensForApplicationAsync("foo");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/apps/foo/tokens");
        }

        [Fact]
        public async Task BuildPublishCerCertRequest()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Applications.PublishCerCertAsync("fakeBase64EncodedCertificate", "testAppId", "testCertificateSigningRequestId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/testAppId/credentials/csrs/testCertificateSigningRequestId/lifecycle/publish");
        }

        [Fact]
        public async Task BuildPublishBinaryCerCertRequest()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Applications.PublishBinaryCerCertAsync(Encoding.UTF8.GetBytes("fakeBase64EncodedCertificate"), "testAppId", "testCertificateSigningRequestId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/testAppId/credentials/csrs/testCertificateSigningRequestId/lifecycle/publish");
        }

        [Fact]
        public async Task BuildPublishDerCertRequest()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            var fakeCertificate = Convert.ToBase64String(Encoding.UTF8.GetBytes("fakeDerCertificate"));
            await client.Applications.PublishDerCertAsync(fakeCertificate, "testAppId", "testCertificateSigningRequestId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/testAppId/credentials/csrs/testCertificateSigningRequestId/lifecycle/publish");
        }

        [Fact]
        public async Task BuildPublishBinaryDerCertRequest()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Applications.PublishBinaryDerCertAsync(Encoding.UTF8.GetBytes("certificateByteDataFromFile"), "testAppId", "testCertificateSigningRequestId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/testAppId/credentials/csrs/testCertificateSigningRequestId/lifecycle/publish");
        }

        [Fact]
        public async Task BuildPublishBinaryPemCertRequest()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Applications.PublishBinaryPemCertAsync(Encoding.UTF8.GetBytes("certificateByteDataFromFile"), "testAppId", "testCertificateSigningRequestId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/testAppId/credentials/csrs/testCertificateSigningRequestId/lifecycle/publish");
        }

        //[Fact]
        //public async Task SetDefaultConnection()
        //{
        //    var rawResponse = @"{
        //                            ""authScheme"": ""TOKEN"",
        //                            ""status"": ""ENABLED"",
        //                            ""_links"": {
        //                                ""self"": {
        //                                    ""href"": ""https://${yourOktaDomain}/api/v1/apps/${applicationId}/connections/default"",
        //                                    ""hints"": {
        //                                        ""allow"": [
        //                                            ""POST"",
        //                                            ""GET""
        //                                        ]
        //                                    }
        //                                },
        //                                ""deactivate"": {
        //                                    ""href"": ""https://${yourOktaDomain}/api/v1/apps/${applicationId}/connections/default/lifecycle/deactivate"",
        //                                    ""hints"": {
        //                                        ""allow"": [
        //                                            ""POST""
        //                                        ]
        //                                    }
        //                                }
        //                            }
        //                        }";
        //    var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
        //    var client = new TestableOktaClient(mockRequestExecutor);
        //    var connectionProfile = new ProvisioningConnectionRequest
        //    {
        //        Profile = new ProvisioningConnectionProfile
        //        {
        //            Token = "foo",
        //            AuthScheme = ProvisioningConnectionAuthScheme.Token,
        //        },
        //    };

        //    var response = await client.Applications.SetDefaultProvisioningConnectionForApplicationAsync(connectionProfile, "bar", true);

        //    mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/bar/connections/default?activate=true");

        //    var expectedBody = @"{""profile"":{""token"":""foo"",""authScheme"":""TOKEN""}}";
        //    mockRequestExecutor.ReceivedBody.Should().Be(expectedBody);
        //    response.Status.Should().Be(ProvisioningConnectionStatus.Enabled);
        //    response.AuthScheme.Should().Be(ProvisioningConnectionAuthScheme.Token);
        //}

        //[Fact]
        //public async Task ActivateDefaultConnection()
        //{
        //    var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
        //    var client = new TestableOktaClient(mockRequestExecutor);

        //    await client.Applications.ActivateDefaultProvisioningConnectionForApplicationAsync("foo");

        //    mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/foo/connections/default/lifecycle/activate");
        //}

        //[Fact]
        //public async Task DeactivateDefaultConnection()
        //{
        //    var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
        //    var client = new TestableOktaClient(mockRequestExecutor);

        //    await client.Applications.DeactivateDefaultProvisioningConnectionForApplicationAsync("foo");

        //    mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/foo/connections/default/lifecycle/deactivate");
        //}

        //[Fact]
        //public async Task ListFeatures()
        //{
        //    var rawResponse = @"[
        //                            {
        //                                ""name"": ""USER_PROVISIONING"",
        //                                ""status"": ""ENABLED"",
        //                                ""description"": ""User provisioning settings from Okta to a downstream application"",
        //                                ""capabilities"": {
        //                                    ""create"": {
        //                                        ""lifecycleCreate"": {
        //                                            ""status"": ""DISABLED""
        //                                        }
        //                                    },
        //                                    ""update"": {
        //                                        ""profile"": {
        //                                            ""status"": ""DISABLED""
        //                                        },
        //                                        ""lifecycleDeactivate"": {
        //                                            ""status"": ""DISABLED""
        //                                        },
        //                                        ""password"": {
        //                                            ""status"": ""DISABLED"",
        //                                            ""seed"": ""RANDOM"",
        //                                            ""change"": ""KEEP_EXISTING""
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        ]";
        //    var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
        //    var client = new TestableOktaClient(mockRequestExecutor);

        //    var features = await client.Applications.ListFeaturesForApplication("foo").ToListAsync();

        //    mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/foo/features");
        //    features.Should().NotBeNullOrEmpty();
        //    var feature = features.FirstOrDefault(x => x.Name == "USER_PROVISIONING");
        //    feature.Should().NotBeNull();
        //    feature.Status.Should().Be(EnabledStatus.Enabled);
        //}

        //[Fact]
        //public async Task GetFeature()
        //{
        //    var rawResponse = @"{
        //                                ""name"": ""USER_PROVISIONING"",
        //                                ""status"": ""ENABLED"",
        //                                ""description"": ""User provisioning settings from Okta to a downstream application"",
        //                                ""capabilities"": {
        //                                    ""create"": {
        //                                        ""lifecycleCreate"": {
        //                                            ""status"": ""DISABLED""
        //                                        }
        //                                    },
        //                                    ""update"": {
        //                                        ""profile"": {
        //                                            ""status"": ""DISABLED""
        //                                        },
        //                                        ""lifecycleDeactivate"": {
        //                                            ""status"": ""DISABLED""
        //                                        },
        //                                        ""password"": {
        //                                            ""status"": ""DISABLED"",
        //                                            ""seed"": ""RANDOM"",
        //                                            ""change"": ""KEEP_EXISTING""
        //                                        }
        //                                    }
        //                                }
        //                            }";
        //    var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
        //    var client = new TestableOktaClient(mockRequestExecutor);

        //    var feature = await client.Applications.GetFeatureForApplicationAsync("foo", "bar");

        //    mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/foo/features/bar");
        //    feature.Should().NotBeNull();
        //    feature.Status.Should().Be(EnabledStatus.Enabled);
        //    feature.Name.Should().Be("USER_PROVISIONING");
        //}

        //[Fact]
        //public async Task UpdateFeature()
        //{
        //    var rawResponse = @"{
        //                                ""name"": ""USER_PROVISIONING"",
        //                                ""status"": ""ENABLED"",
        //                                ""description"": ""User provisioning settings from Okta to a downstream application"",
        //                                ""capabilities"": {
        //                                    ""create"": {
        //                                        ""lifecycleCreate"": {
        //                                            ""status"": ""DISABLED""
        //                                        }
        //                                    },
        //                                    ""update"": {
        //                                        ""profile"": {
        //                                            ""status"": ""DISABLED""
        //                                        },
        //                                        ""lifecycleDeactivate"": {
        //                                            ""status"": ""DISABLED""
        //                                        },
        //                                        ""password"": {
        //                                            ""status"": ""DISABLED"",
        //                                            ""seed"": ""RANDOM"",
        //                                            ""change"": ""KEEP_EXISTING""
        //                                        }
        //                                    }
        //                                }
        //                            }";
        //    var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
        //    var client = new TestableOktaClient(mockRequestExecutor);

        //    var capabilitiesObj = new CapabilitiesObject
        //    {
        //        Create = new CapabilitiesCreateObject
        //        {
        //            LifecycleCreate = new LifecycleCreateSettingObject
        //            {
        //                Status = EnabledStatus.Disabled,
        //            },
        //        },
        //    };

        //    var feature = await client.Applications.UpdateFeatureForApplicationAsync(capabilitiesObj, "foo", "bar");

        //    mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/apps/foo/features/bar");

        //    var expectedBody = @"{""create"":{""lifecycleCreate"":{""status"":""DISABLED""}}}";
        //    mockRequestExecutor.ReceivedBody.Should().Be(expectedBody);

        //    feature.Should().NotBeNull();
        //    feature.Status.Should().Be(EnabledStatus.Enabled);
        //    feature.Name.Should().Be("USER_PROVISIONING");
        //    feature.Capabilities.Create.LifecycleCreate.Status.Should().Be(EnabledStatus.Disabled);
        //}

        //[Fact]
        //public async Task CallDataStorePostAsync()
        //{
        //    var mockDataStore = Substitute.For<IDataStore>();
        //    var client = new TestableOktaClient(mockDataStore);
        //    var testRequest = new HttpRequest();
        //    await client.PostAsync(testRequest, CancellationToken.None);
        //    await mockDataStore
        //        .Received(1)
        //        .PostAsync<Resource>(Arg.Is(testRequest), Arg.Any<RequestContext>(), Arg.Any<CancellationToken>());
        //}

        private string GetBookmarkApplicationStubResponse(string features = "null")
        {
            #region Bookmark Application Stub

            var rawResponse = @"{
                ""id"": ""0oafxqCAJWWGELFTYASJ"",
                ""name"": ""bookmark"",
                ""label"": ""Sample Bookmark App"",
                ""status"": ""ACTIVE"",
                ""lastUpdated"": ""2013-10-01T04:22:31.000Z"",
                ""created"": ""2013-10-01T04:22:27.000Z"",
                ""accessibility"": {
                    ""selfService"": false,
                    ""errorRedirectUrl"": null
                },
                ""visibility"": {
                    ""autoSubmitToolbar"": false,
                    ""hide"": {
                        ""iOS"": false,
                        ""web"": false
                    },
                    ""appLinks"": {
                        ""login"": true
                    }
                },
                ""features"":" + features + @",
                ""signOnMode"": ""BOOKMARK"",
                ""credentials"": {
                    ""userNameTemplate"": {
                        ""template"": ""${source.login}"",
                        ""type"": ""BUILT_IN""
                    }
                },
                ""settings"": {
                    ""app"": {
                        ""requestIntegration"": false,
                        ""url"": ""https://example.com/bookmark.htm""
                    }
                },
            }";
            #endregion

            return rawResponse;
        }

        private string GetListOAuthTokensStubResponse()
        {
            var rawResponse = @"
                                [
                                  {
                                    ""id"": ""oar579Mcp7OUsNTlo0g3"",
                                    ""status"": ""ACTIVE"",
                                    ""created"": ""2018-03-09T03:18:06.000Z"",
                                    ""lastUpdated"": ""2018-03-09T03:18:06.000Z"",
                                    ""expiresAt"": ""2018-03-16T03:18:06.000Z"",
                                    ""issuer"": ""https://${yourOktaDomain}/oauth2/ausain6z9zIedDCxB0h7"",
                                    ""clientId"": ""0oabskvc6442nkvQO0h7"",
                                    ""userId"": ""00u5t60iloOHN9pBi0h7"",
                                    ""scopes"": [
                                      ""offline_access"",
                                      ""car:drive""
                                    ],
                                    ""_links"": {
                                      ""app"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oabskvc6442nkvQO0h7"",
                                        ""title"": ""Native""
                                      },
                                      ""self"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3""
                                      },
                                      ""revoke"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3"",
                                        ""hints"": {
                                          ""allow"": [
                                            ""DELETE""
                                          ]
                                        }
                                      },
                                      ""client"": {
                                        ""href"": ""https://${yourOktaDomain}/oauth2/v1/clients/0oabskvc6442nkvQO0h7"",
                                        ""title"": ""Example Client App""
                                      },
                                      ""user"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/users/00upcgi9dyWEOeCwM0g3"",
                                        ""title"": ""Saml Jackson""
                                      },
                                      ""authorizationServer"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/authorizationServers/ausain6z9zIedDCxB0h7"",
                                        ""title"": ""Example Authorization Server""
                                      }
                                    }
                                  }
                                ]";

            return rawResponse;
        }

        private string GetOAuthTokenStubResponse()
        {
            var rawResponse = @"
                                {
                                  ""id"": ""oar579Mcp7OUsNTlo0g3"",
                                  ""status"": ""ACTIVE"",
                                  ""created"": ""2018-03-09T03:18:06.000Z"",
                                  ""lastUpdated"": ""2018-03-09T03:18:06.000Z"",
                                  ""expiresAt"": ""2018-03-16T03:18:06.000Z"",
                                  ""issuer"": ""https://${yourOktaDomain}/oauth2/ausain6z9zIedDCxB0h7"",
                                  ""clientId"": ""0oabskvc6442nkvQO0h7"",
                                  ""userId"": ""00u5t60iloOHN9pBi0h7"",
                                  ""scopes"": [
                                    ""offline_access"",
                                    ""car:drive""
                                  ],
                                  ""_links"": {
                                    ""app"": {
                                      ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oabskvc6442nkvQO0h7"",
                                      ""title"": ""Native""
                                    },
                                    ""self"": {
                                      ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3""
                                    },
                                    ""revoke"": {
                                      ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3"",
                                      ""hints"": {
                                        ""allow"": [
                                          ""DELETE""
                                        ]
                                      }
                                    },
                                    ""client"": {
                                      ""href"": ""https://${yourOktaDomain}/oauth2/v1/clients/0oabskvc6442nkvQO0h7"",
                                      ""title"": ""Example Client App""
                                    },
                                    ""user"": {
                                      ""href"": ""https://${yourOktaDomain}/api/v1/users/00upcgi9dyWEOeCwM0g3"",
                                      ""title"": ""Saml Jackson""
                                    },
                                    ""authorizationServer"": {
                                      ""href"": ""https://${yourOktaDomain}/api/v1/authorizationServers/ausain6z9zIedDCxB0h7"",
                                      ""title"": ""Example Authorization Server""
                                    }
                                  }
                                }";

            return rawResponse;
        }
    }
}
