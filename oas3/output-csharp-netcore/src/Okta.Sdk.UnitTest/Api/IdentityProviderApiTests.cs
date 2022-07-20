/*
 * Okta API
 *
 * Allows customers to easily access the Okta API
 *
 * The version of the OpenAPI document: 2.10.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

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

// uncomment below to import models
//using Org.OpenAPITools.Model;

namespace Okta.Sdk.UnitTest
{
    /// <summary>
    ///  Class for testing IdentityProviderApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class IdentityProviderApiTests
    {
        [Fact]
        public async Task ListIdentityProviderApplicationUsers()
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

            var mockClient = new MockAsyncClient(rawResponse, HttpStatusCode.OK);
            var idpApi = new IdentityProviderApi(new ApiClient(), mockClient, new Configuration { BasePath = "https://foo.com"});

            var users = await idpApi.ListIdentityProviderApplicationUsersAsync("0oa4lb6lbtmH355Hx0h7").ToListAsync();

          

            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}/users");
            mockClient.ReceivedPathParams.Keys.Contains("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain("0oa4lb6lbtmH355Hx0h7");

            users.Should().HaveCount(1);
            users.First().Id.Should().Be("00u5cl9lo7nMjHjPr0h7");
            users.First().ExternalId.Should().Be("109912936038778");
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


            var mockClient = new MockAsyncClient(rawResponse, HttpStatusCode.OK);
            var idpApi = new IdentityProviderApi(new ApiClient(), mockClient, new Configuration { BasePath = "https://foo.com" });

            var user = await idpApi.GetIdentityProviderApplicationUserAsync("0oa62bfdiumsUndnZ0h7", "00u5t60iloOHN9pBi0h7");
            
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}/users/{userId}");
            mockClient.ReceivedPathParams.Keys.Contains("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain("0oa62bfdiumsUndnZ0h7");

            mockClient.ReceivedPathParams.Keys.Contains("userId");
            mockClient.ReceivedPathParams["userId"].Should().Contain("00u5t60iloOHN9pBi0h7");

            user.Should().NotBeNull();
            user.Id.Should().Be("00u5t60iloOHN9pBi0h7");
            user.ExternalId.Should().Be("externalId");
        }

        [Fact]
        public async Task LinkUserToIdentityProvider()
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

            var mockClient = new MockAsyncClient(rawResponse, HttpStatusCode.OK);
            var idpApi = new IdentityProviderApi(new ApiClient(), mockClient, new Configuration { BasePath = "https://foo.com" });

            var user = await idpApi.LinkUserToIdentityProviderAsync("0oa62b57p7c8PaGpU0h7",
                "00ub0oNGTSWTBKOLGLNR", new UserIdentityProviderLinkRequest() { ExternalId = "121749775026145" });

            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}/users/{userId}");
            mockClient.ReceivedPathParams["idpId"].Should().Be("0oa62b57p7c8PaGpU0h7");
            mockClient.ReceivedPathParams["userId"].Should().Be("00ub0oNGTSWTBKOLGLNR");
            user.Should().NotBeNull();
            user.Id.Should().Be("00ub0oNGTSWTBKOLGLNR");
            user.ExternalId.Should().Be("121749775026145");
        }

        [Fact]
        public async Task UnlinkUserFromIdentityProvider()
        {
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var idpApi = new IdentityProviderApi(new ApiClient(), mockClient, new Configuration { BasePath = "https://foo.com" });
            
            await idpApi.UnlinkUserFromIdentityProviderAsync("0oa4lb6lbtmH355Hx0h7", "00u5cl9lo7nMjHjPr0h7");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}/users/{userId}");
            mockClient.ReceivedPathParams["idpId"].Should().Be("0oa4lb6lbtmH355Hx0h7");
            mockClient.ReceivedPathParams["userId"].Should().Be("00u5cl9lo7nMjHjPr0h7");
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

            var mockClient = new MockAsyncClient(rawResponse, HttpStatusCode.OK);
            var idpApi = new IdentityProviderApi(new ApiClient(), mockClient, new Configuration { BasePath = "https://foo.com" });

            var tokens = await idpApi.ListSocialAuthTokensAsync("0oa62b57p7c8PaGpU0h7", "00ub0oNGTSWTBKOLGLNR").ToListAsync();

            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}/users/{userId}/credentials/tokens");
            mockClient.ReceivedPathParams["idpId"].Should().Be("0oa62b57p7c8PaGpU0h7");
            mockClient.ReceivedPathParams["userId"].Should().Be("00ub0oNGTSWTBKOLGLNR");

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

            var mockClient = new MockAsyncClient(rawResponse, HttpStatusCode.OK);
            var idpApi = new IdentityProviderApi(new ApiClient(), mockClient, new Configuration { BasePath = "https://foo.com" });


            var idp = new IdentityProvider()
            {
                Type = "CUSTOM TYPE IDP",
                Name = $"dotnet-sdk:Custom Idp",
            };

            var createdIdp = await idpApi.CreateIdentityProviderAsync(idp);

            var expectedBody = $"{{\"name\":\"dotnet-sdk:Custom Idp\",\"type\":\"CUSTOM TYPE IDP\"}}";
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps");
            mockClient.ReceivedBody.Should().Be(expectedBody);
        }
    }
}
