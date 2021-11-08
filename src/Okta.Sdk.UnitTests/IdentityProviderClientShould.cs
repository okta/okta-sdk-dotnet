// <copyright file="IdentityProviderClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class IdentityProviderClientShould
    {
        [Fact]
        public async Task ListUsers()
        {
            var rawResponse = @"[
                                  {
                                      ""id"": ""00u5cl9lo7nMjHjPr0h7"",
                                      ""externalId"": ""109912936038778"",
                                      ""created"": ""2015-11-03T19:10:11.000Z"",
                                      ""lastUpdated"": ""2015-11-03T19:11:49.000Z"",
                                      ""profile"": {
                                          ""firstName"": ""Carol"",
                                          ""middleName"": ""Lee"",
                                          ""lastName"": ""Johnson"",
                                          ""email"": ""carol_johnson@tfbnw.net"",
                                          ""displayName"": ""Carol Johnson"",
                                          ""profile"": ""https://www.facebook.com/app_scoped_user_id/109912936038778/""
                                      },
                                      ""_links"": {
                                        ""self"": {
                                          ""href"": ""https://${yourOktaDomain}/api/v1/idps/0oa4lb6lbtmH355Hx0h7/users/00u5cl9lo7nMjHjPr0h7"",
                                          ""hints"": {
                                              ""allow"": [
                                                  ""GET"",
                                                  ""DELETE""
                                                ]
                                          }
                                        },
                                        ""idp"": {
                                            ""href"": ""https://${yourOktaDomain}/api/v1/idps/0oa4lb6lbtmH355Hx0h7""
                                        },
                                        ""user"": {
                                            ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5cl9lo7nMjHjPr0h7""
                                        }
                                     }
                                  }
                                ]";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var users = await client.IdentityProviders.ListIdentityProviderApplicationUsers("0oa4lb6lbtmH355Hx0h7").ToListAsync();

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/idps/0oa4lb6lbtmH355Hx0h7/users");

            users.Should().HaveCount(1);
            users.FirstOrDefault().Id.Should().Be("00u5cl9lo7nMjHjPr0h7");
            users.FirstOrDefault().ExternalId.Should().Be("109912936038778");
        }

        [Fact]
        public async Task GetIdentityProviderApplicationUser()
        {
            var rawResponse = @"{
                                ""id"": ""00u5t60iloOHN9pBi0h7"",
                                ""externalId"": ""externalId"",
                                ""created"": ""2017-12-19T17:30:16.000Z"",
                                ""lastUpdated"": ""2017-12-19T17:30:16.000Z"",
                                ""profile"": {
                                    ""profileUrl"": null,
                                    ""firstName"": null,
                                    ""lastName"": null,
                                    ""honorificSuffix"": null,
                                    ""displayName"": null,
                                    ""honorificPrefix"": null,
                                    ""middleName"": null,
                                    ""email"": null
                                },
                                ""_links"": {
                                    ""idp"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/idps/0oa62bfdiumsUndnZ0h7""
                                    },
                                    ""self"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/idps/0oa62bfdiumsUndnZ0h7/users/00u5t60iloOHN9pBi0h7"",
                                        ""hints"": {
                                            ""allow"": [
                                                ""GET"",
                                                ""DELETE""
                                            ]
                                        }
                                    },
                                    ""user"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7""
                                    }
                                }
                            }";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var user = await client.IdentityProviders.GetIdentityProviderApplicationUserAsync("0oa62bfdiumsUndnZ0h7", "00u5t60iloOHN9pBi0h7");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/idps/0oa62bfdiumsUndnZ0h7/users/00u5t60iloOHN9pBi0h7");

            user.Should().NotBeNull();
            user.Id.Should().Be("00u5t60iloOHN9pBi0h7");
            user.ExternalId.Should().Be("externalId");
        }

        [Fact]
        public async Task LinkUser()
        {
            var rawResponse = @"{
                                ""id"": ""00ub0oNGTSWTBKOLGLNR"",
                                ""externalId"": ""121749775026145"",
                                ""created"": ""2017-03-30T02:19:51.000Z"",
                                ""lastUpdated"": ""2017-03-30T02:19:51.000Z"",
                                ""_links"": {
                                ""self"": {
                                    ""href"": ""https://${yourOktaDomain}/api/v1/idps/0oa62b57p7c8PaGpU0h7/users/00ub0oNGTSWTBKOLGLNR"",
                                    ""hints"": {
                                    ""allow"": [
                                        ""GET"",
                                        ""DELETE""
                                    ]
                                    }
                                },
                                ""idp"": {
                                    ""href"": ""https://${yourOktaDomain}/api/v1/idps/0oa62b57p7c8PaGpU0h7""
                                },
                                ""user"": {
                                    ""href"": ""https://${yourOktaDomain}/api/v1/users/00ub0oNGTSWTBKOLGLNR""
                                }
                                }
                            }";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var user = await client.IdentityProviders.LinkUserToIdentityProviderAsync(
                new UserIdentityProviderLinkRequest() { ExternalId = "121749775026145" },
                "0oa62b57p7c8PaGpU0h7",
                "00ub0oNGTSWTBKOLGLNR");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/idps/0oa62b57p7c8PaGpU0h7/users/00ub0oNGTSWTBKOLGLNR");

            user.Should().NotBeNull();
            user.Id.Should().Be("00ub0oNGTSWTBKOLGLNR");
            user.ExternalId.Should().Be("121749775026145");
        }

        [Fact]
        public async Task UnlinkUser()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.IdentityProviders.UnlinkUserFromIdentityProviderAsync("0oa4lb6lbtmH355Hx0h7", "00u5cl9lo7nMjHjPr0h7");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/idps/0oa4lb6lbtmH355Hx0h7/users/00u5cl9lo7nMjHjPr0h7");
        }

        [Fact]
        public async Task ListSocialAuthTokens()
        {
            var rawResponse = @"[{
                                  ""id"": ""dsasdfe"",
                                  ""token"": ""JBTWGV22G4ZGKV3N"",
                                  ""tokenType"" : ""urn:ietf:params:oauth:token-type:access_token"",
                                  ""tokenAuthScheme"": ""Bearer"",
                                  ""expiresAt"" : ""2014-08-06T16:56:31.000Z"",
                                  ""scopes""     : [ ""openid"", ""foo"" ]
                                }]";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var tokens = await client.IdentityProviders.ListSocialAuthTokens("0oa62b57p7c8PaGpU0h7", "00ub0oNGTSWTBKOLGLNR").ToListAsync();

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/idps/0oa62b57p7c8PaGpU0h7/users/00ub0oNGTSWTBKOLGLNR/credentials/tokens");

            tokens.Should().HaveCount(1);
            tokens.FirstOrDefault().Id.Should().Be("dsasdfe");
            tokens.FirstOrDefault().Token.Should().Be("JBTWGV22G4ZGKV3N");
            tokens.FirstOrDefault().TokenType.Should().Be("urn:ietf:params:oauth:token-type:access_token");
            tokens.FirstOrDefault().TokenAuthScheme.Should().Be("Bearer");
            tokens.FirstOrDefault().Scopes.Should().ContainInOrder("openid", "foo");
        }

        [Fact]
        public async Task CreateCustomIdp()
        {
            var rawResponse = @"{
                                  ""id"": ""foo"",
                                  ""issuerMode"": ""ORG_URL"",
                                  ""name"": ""dotnet-sdk:AddGeneric2021-10-20 3:37:36 PM"",
                                  ""status"": ""INACTIVE"",
                                  ""created"": ""2021-10-20T15:37:37.000Z"",
                                  ""lastUpdated"": ""2021-10-20T15:37:37.000Z"",
                                }";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var idp = new IdentityProvider()
            {
                Type = "CUSTOM TYPE IDP",
                Name = $"dotnet-sdk:Custom Idp",
            };

            var createdIdp = await client.IdentityProviders.CreateIdentityProviderAsync(idp);

            var expectedBody = $"{{\"type\":\"CUSTOM TYPE IDP\",\"name\":\"dotnet-sdk:Custom Idp\"}}";
            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/idps");
            mockRequestExecutor.ReceivedBody.Should().Be(expectedBody);
        }
    }
}
