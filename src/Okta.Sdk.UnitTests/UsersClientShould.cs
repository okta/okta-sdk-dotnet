// <copyright file="UsersClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class UsersClientShould
    {
        [Fact]
        public async Task ListApplicationTargetsForApplicationAdministratorRoleForUser()
        {
            var rawResponse = @"[
                                  {
                                    ""name"": ""salesforce"",
                                    ""displayName"": ""Salesforce.com"",
                                    ""description"": ""Salesforce"",
                                    ""status"": ""ACTIVE"",
                                    ""lastUpdated"": ""2014-06-03T16:17:13.000Z"",
                                    ""category"": ""CRM"",
                                    ""verificationStatus"": ""OKTA_VERIFIED"",
                                    ""website"": ""http://www.salesforce.com"",
                                    ""signOnModes"": [
                                      ""SAML_2_0""
                                    ],
                                    ""features"": [
                                      ""IMPORT_NEW_USERS"",
                                    ],
                                    ""_links"": {
                                      ""logo"": [
                                        {
                                          ""name"": ""medium"",
                                          ""href"": ""https://${yourOktaDomain}/img/logos/salesforce_logo.png"",
                                          ""type"": ""image/png""
                                        }
                                      ],
                                      ""self"": {
                                          ""href"": ""https://${yourOktaDomain}/api/v1/catalog/apps/salesforce""
                                      }
                                    }
                                  },
                                  {
                                    ""name"": ""Facebook (Toronto)"",
                                    ""status"": ""ACTIVE"",
                                    ""id"": ""0obdfgrQ5dv29pqyQo0f5"",
                                    ""_links"": {
                                       ""self"": {
                                           ""href"": ""https://${yourOktaDomain}/api/v1/apps/0obdfgrQ5dv29pqyQo0f5""
                                       }
                                    }
                                  }
                                ]";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var apps = await client.Users.ListApplicationTargetsForApplicationAdministratorRoleForUser("foo", "bar").ToListAsync();

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps");

            apps.Should().NotBeNullOrEmpty();
            apps.Should().HaveCount(2);
            apps.FirstOrDefault().Name.Should().Be("salesforce");
            apps.FirstOrDefault().Status.Should().Be(CatalogApplicationStatus.Active);
            apps.FirstOrDefault().Id.Should().BeNullOrEmpty();
            apps.FirstOrDefault().GetProperty<string>("description").Should().Be("Salesforce");
            apps.FirstOrDefault().GetProperty<string>("displayName").Should().Be("Salesforce.com");
            apps.FirstOrDefault().GetProperty<string>("category").Should().Be("CRM");
            apps.FirstOrDefault().GetProperty<string>("verificationStatus").Should().Be("OKTA_VERIFIED");
            apps.FirstOrDefault().GetProperty<string>("website").Should().Be("http://www.salesforce.com");
            apps.FirstOrDefault().Features.Should().Contain("IMPORT_NEW_USERS");

            apps[1].Name.Should().Be("Facebook (Toronto)");
            apps[1].Status.Should().Be(CatalogApplicationStatus.Active);
            apps[1].Id.Should().Be("0obdfgrQ5dv29pqyQo0f5");
        }

        [Fact]
        public async Task AddApplicationTargetForAdministratorRole()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Users.AddApplicationTargetToAdminRoleForUserAsync("foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps/baz");
        }

        [Fact]
        public async Task AddApplicationTargetToAppAdminRoleForUser()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Users.AddApplicationTargetToAppAdminRoleForUserAsync("foo", "bar", "baz", "bax");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps/baz/bax");
        }

        [Fact]
        public async Task RemoveApplicationTargetFromAdministratorRoleForUser()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Users.RemoveApplicationTargetFromAdministratorRoleForUserAsync("foo", "bar", "baz", "bax");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps/baz/bax");
        }

        [Fact]
        public async Task RemoveApplicationTargetFromApplicationAdministratorRoleForUser()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Users.RemoveApplicationTargetFromApplicationAdministratorRoleForUserAsync("foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps/baz");
        }

        [Fact]
        public async Task ListUserClients()
        {
            var rawResponse = @"[
                                    {
                                        ""client_id"": ""0oabskvc6442nkvQO0h7"",
                                        ""client_name"": ""My App"",
                                        ""client_uri"": null,
                                        ""logo_uri"": null,
                                        ""_links"": {
                                            ""grants"": {
                                                ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7/clients/0oabskvc6442nkvQO0h7/grants""
                                            },
                                            ""tokens"": {
                                                ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7/clients/0oabskvc6442nkvQO0h7/tokens""
                                            }
                                        }
                                    }
                                ]";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var userClients = await client.Users.ListUserClients("foo").ToListAsync();
            userClients.Should().NotBeNull();
            userClients.Count.Should().Be(1);
            userClients[0].ClientId.Should().Be("0oabskvc6442nkvQO0h7");
            userClients[0].ClientName.Should().Be("My App");
            userClients[0].ClientUri.Should().BeNullOrEmpty();
            userClients[0].LogoUri.Should().BeNullOrEmpty();

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/clients");
        }

        [Fact]
        public async Task RevokeGrantsForUserAndClient()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Users.RevokeGrantsForUserAndClientAsync("foo", "bar");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/clients/bar/grants");
        }

        [Fact]
        public async Task ListGrantsForUserAndClient()
        {
            var rawResponse = @"[
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
                                        ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7/clients/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3""
                                      },
                                      ""revoke"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7/clients/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3"",
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
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Users.ListGrantsForUserAndClient("foo", "bar").ToListAsync();

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/clients/bar/grants?limit=20");
        }

        [Fact]
        public async Task RevokeTokenForUserAndClient()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Users.RevokeTokenForUserAndClientAsync("foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/clients/bar/tokens/baz");
        }

        [Fact]
        public async Task ListRefreshTokensForUserAndClient()
        {
            var rawResponse = @"[
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
                                        ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7/clients/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3""
                                      },
                                      ""revoke"": {
                                        ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7/clients/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3"",
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
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var refreshTokens = await client.Users.ListRefreshTokensForUserAndClient("foo", "bar").ToListAsync();
            refreshTokens.Should().NotBeNull();
            refreshTokens.Count.Should().Be(1);
            refreshTokens[0].Id.Should().Be("oar579Mcp7OUsNTlo0g3");
            refreshTokens[0].Status.Should().Be("ACTIVE");
            refreshTokens[0].Issuer.Should().Be("https://${yourOktaDomain}/oauth2/ausain6z9zIedDCxB0h7");
            refreshTokens[0].ClientId.Should().Be("0oabskvc6442nkvQO0h7");
            refreshTokens[0].UserId.Should().Be("00u5t60iloOHN9pBi0h7");
            refreshTokens[0].Scopes.Should().NotBeNull();
            refreshTokens[0].Scopes.Count.Should().Be(2);
            refreshTokens[0].Scopes[0].Should().Be("offline_access");
            refreshTokens[0].Scopes[1].Should().Be("car:drive");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/clients/bar/tokens?limit=20");
        }

        [Fact]
        public async Task ListUserGrants()
        {
            var rawResponse = @"[
                                    {
                                        ""id"": ""oag3ih1zrm1cBFOiq0h6"",
                                        ""status"": ""ACTIVE"",
                                        ""created"": ""2017-10-30T22:06:53.000Z"",
                                        ""lastUpdated"": ""2017-10-30T22:06:53.000Z"",
                                        ""issuer"": ""https://${yourOktaDomain}/oauth2/ausain6z9zIedDCxB0h7"",
                                        ""clientId"": ""0oabskvc6442nkvQO0h7"",
                                        ""userId"": ""00u5t60iloOHN9pBi0h7"",
                                        ""scopeId"": ""scpCmCCV1DpxVkCaye2X"",
                                        ""_links"": {
                                            ""app"": {
                                                ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oabskvc6442nkvQO0h7"",
                                                ""title"": ""My App""
                                            },
                                            ""scope"": {
                                                ""href"": ""https://${yourOktaDomain}/api/v1/authorizationServers/ausain6z9zIedDCxB0h7/scopes/scpCmCCV1DpxVkCaye2X"",
                                                ""title"": ""My phone""
                                            },
                                            ""client"": {
                                                ""href"": ""https://${yourOktaDomain}/oauth2/v1/clients/0oabskvc6442nkvQO0h7"",
                                                ""title"": ""My App""
                                            },
                                            ""self"": {
                                                ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7/grants/oag3ih1zrm1cBFOiq0h6"",
                                                ""hints"": {
                                                    ""allow"": [
                                                        ""GET"",
                                                        ""DELETE""
                                                    ]
                                                }
                                            },
                                            ""user"": {
                                                ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7"",
                                                ""title"": ""SAML Jackson""
                                            },
                                            ""authorizationServer"": {
                                                ""href"": ""https://${yourOktaDomain}/api/v1/authorizationServers/ausain6z9zIedDCxB0h7"",
                                                ""title"": ""Example Authorization Server""
                                            }
                                        }
                                    }
                                ]";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var grants = await client.Users.ListUserGrants("foo").ToListAsync();
            grants.Should().NotBeNull();
            grants.Count.Should().Be(1);
            grants[0].Id.Should().Be("oag3ih1zrm1cBFOiq0h6");
            grants[0].Status.Should().Be(OAuth2ScopeConsentGrantStatus.Active);
            grants[0].Issuer.Should().Be("https://${yourOktaDomain}/oauth2/ausain6z9zIedDCxB0h7");
            grants[0].ClientId.Should().Be("0oabskvc6442nkvQO0h7");
            grants[0].UserId.Should().Be("00u5t60iloOHN9pBi0h7");
            grants[0].ScopeId.Should().Be("scpCmCCV1DpxVkCaye2X");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/grants?limit=20");
        }

        [Fact]
        public async Task ListUserIdentityProviders()
        {
            var rawResponse = @"[{
                                  ""id"": ""0oa62b57p7c8PaGpU0h7"",
                                  ""type"": ""FACEBOOK"",
                                  ""name"": ""Facebook"",
                                  ""status"": ""ACTIVE"",
                                  ""created"": ""2016-03-24T23:18:27.000Z"",
                                  ""lastUpdated"": ""2016-03-24T23:18:27.000Z"",
                                  ""protocol"": {
                                    ""type"": ""OAUTH2"",
                                    ""endpoints"": {
                                      ""authorization"": {
                                        ""url"": ""https://www.facebook.com/dialog/oauth"",
                                        ""binding"": ""HTTP-REDIRECT""
                                      },
                                      ""token"": {
                                        ""url"": ""https://graph.facebook.com/v2.5/oauth/access_token"",
                                        ""binding"": ""HTTP-POST""
                                      }
                                    },
                                    ""scopes"": [
                                      ""public_profile"",
                                      ""email""
                                    ],
                                    ""credentials"": {
                                      ""client"": {
                                        ""client_id"": ""your-client-id"",
                                        ""client_secret"": ""your-client-secret""
                                      }
                                    }
                                  },
                                  ""policy"": {
                                    ""provisioning"": {
                                      ""action"": ""AUTO"",
                                      ""profileMaster"": true,
                                      ""groups"": {
                                        ""action"": ""NONE""
                                      },
                                      ""conditions"": {
                                        ""deprovisioned"": {
                                          ""action"": ""NONE""
                                        },
                                        ""suspended"": {
                                          ""action"": ""NONE""
                                        }
                                      }
                                    },
                                    ""accountLink"": {
                                      ""filter"": null,
                                      ""action"": ""AUTO""
                                    },
                                    ""subject"": {
                                      ""userNameTemplate"": {
                                        ""template"": ""idpuser.userPrincipalName""
                                      },
                                      ""filter"": null,
                                      ""matchType"": ""USERNAME""
                                    },
                                    ""maxClockSkew"": 0
                                  },
                                  ""_links"": {
                                    ""authorize"": {
                                      ""href"": ""https://${yourOktaDomain}/oauth2/v1/authorize?idp=0oa62b57p7c8PaGpU0h7&
                                          client_id={clientId}&response_type={responseType}&response_mode={responseMode}&
                                          scope={scopes}&redirect_uri={redirectUri}&state={state}"",
                                      ""templated"": true,
                                      ""hints"": {
                                        ""allow"": [
                                          ""GET""
                                        ]
                                      }
                                    },
                                    ""clientRedirectUri"": {
                                      ""href"": ""https://${yourOktaDomain}/oauth2/v1/authorize/callback"",
                                      ""hints"": {
                                        ""allow"": [
                                          ""POST""
                                        ]
                                      }
                                    },
                                    ""idpUser"": {
                                        ""href"": ""https://${yourOktaDomain}/idps/0oa62b57p7c8PaGpU0h7/users/00ub0oNGTSWTBKOLGLNR"",
                                        ""hints"": {
                                          ""allow"": [
                                            ""GET"",
                                            ""DELETE""
                                          ]
                                        }
                                      }
                                  }
                                }]";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var identityProviders = await client.Users.ListUserIdentityProviders("foo").ToListAsync();

            identityProviders.Should().NotBeNull();
            identityProviders.Count.Should().Be(1);
            identityProviders[0].Id.Should().Be("0oa62b57p7c8PaGpU0h7");
            identityProviders[0].Type.Should().Be("FACEBOOK");
            identityProviders[0].Name.Should().Be("Facebook");
            identityProviders[0].Status.Should().Be("ACTIVE");
            identityProviders[0].Protocol.Should().NotBeNull();
            identityProviders[0].Protocol.Type.Should().Be("OAUTH2");
            identityProviders[0].Protocol.Endpoints.Should().NotBeNull();
            identityProviders[0].Protocol.Endpoints.Authorization.Should().NotBeNull();
            identityProviders[0].Protocol.Endpoints.Authorization.Url.Should().Be("https://www.facebook.com/dialog/oauth");
            identityProviders[0].Protocol.Endpoints.Authorization.Binding.Should().Be("HTTP-REDIRECT");
            identityProviders[0].Protocol.Endpoints.Token.Url.Should().Be("https://graph.facebook.com/v2.5/oauth/access_token");
            identityProviders[0].Protocol.Endpoints.Token.Binding.Should().Be("HTTP-POST");
            identityProviders[0].Protocol.Scopes.Should().NotBeNull();
            identityProviders[0].Protocol.Scopes.Count.Should().Be(2);
            identityProviders[0].Protocol.Scopes[0].Should().Be("public_profile");
            identityProviders[0].Protocol.Scopes[1].Should().Be("email");
            identityProviders[0].Protocol.Credentials.Should().NotBeNull();
            identityProviders[0].Protocol.Credentials.Client.Should().NotBeNull();
            identityProviders[0].Protocol.Credentials.Client.ClientId.Should().Be("your-client-id");
            identityProviders[0].Protocol.Credentials.Client.ClientSecret.Should().Be("your-client-secret");
            identityProviders[0].Policy.Should().NotBeNull();
            identityProviders[0].Policy.Provisioning.Should().NotBeNull();
            identityProviders[0].Policy.Provisioning.Action.Should().Be("AUTO");
            identityProviders[0].Policy.Provisioning.ProfileMaster.Should().Be(true);
            identityProviders[0].Policy.Provisioning.Groups.Should().NotBeNull();
            identityProviders[0].Policy.Provisioning.Groups.Action.Should().Be("NONE");
            identityProviders[0].Policy.Provisioning.Conditions.Should().NotBeNull();
            identityProviders[0].Policy.Provisioning.Conditions.Suspended.Should().NotBeNull();
            identityProviders[0].Policy.Provisioning.Conditions.Suspended.Action.Should().Be("NONE");
            identityProviders[0].Policy.AccountLink.Should().NotBeNull();
            identityProviders[0].Policy.AccountLink.Action.Should().Be("AUTO");
            identityProviders[0].Policy.Subject.Should().NotBeNull();
            identityProviders[0].Policy.Subject.UserNameTemplate.Should().NotBeNull();
            identityProviders[0].Policy.Subject.UserNameTemplate.Template.Should().Be("idpuser.userPrincipalName");
            identityProviders[0].Policy.Subject.Filter.Should().BeNull();
            identityProviders[0].Policy.Subject.MatchType.Should().Be(PolicySubjectMatchType.Username);
            identityProviders[0].Policy.MaxClockSkew.Should().Be(0);
            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/idps");
        }

        [Fact]
        public async Task AddAllAppsAsTargetToRole()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Users.AddAllAppsAsTargetToRoleAsync("foo", "bar");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/roles/bar/targets/catalog/apps");
        }

        [Fact]
        public async Task ClearUserSessions()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Users.ClearUserSessionsAsync("foo");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/sessions?oauthTokens=false");
        }

        [Fact]
        public async Task ResetFactors()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Users.ResetFactorsAsync("foo");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/lifecycle/reset_factors");
        }

        [Fact]
        public async Task ClearUserOAuthSessions()
        {
          var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
          var client = new TestableOktaClient(mockRequestExecutor);
          await client.Users.ClearUserSessionsAsync("foo", true);

          mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/sessions?oauthTokens=true");
        }

        [Fact]
        public async Task GetRefreshTokenForUserAndClient()
        {
            var rawResponse = @"{
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
                                  ""_embedded"": {
                                    ""scopes"": [
                                      {
                                        ""id"": ""scppb56cIl4GvGxy70g3"",
                                        ""name"": ""offline_access"",
                                        ""description"": ""Requests a refresh token by default, used to obtain more access tokens without re-prompting the user for authentication."",
                                        ""_links"": {
                                          ""scope"": {
                                            ""href"": ""https://${yourOktaDomain}/api/v1/authorizationServers/ausain6z9zIedDCxB0h7/scopes/scppb56cIl4GvGxy70g3"",
                                            ""title"": ""offline_access""
                                          }
                                        }
                                      },
                                      {
                                        ""id"": ""scp142iq2J8IGRUCS0g4"",
                                        ""name"": ""car:drive"",
                                        ""displayName"": ""Drive car"",
                                        ""description"": ""Allows the user to drive a car."",
                                        ""_links"": {
                                          ""scope"": {
                                            ""href"": ""https://${yourOktaDomain}/api/v1/authorizationServers/ausain6z9zIedDCxB0h7/scopes/scp142iq2J8IGRUCS0g4"",
                                            ""title"": ""Drive car""
                                          }
                                        }
                                      }
                                    ]
                                  },
                                  ""_links"": {
                                    ""app"": {
                                      ""href"": ""https://${yourOktaDomain}/api/v1/apps/0oabskvc6442nkvQO0h7"",
                                      ""title"": ""Native""
                                    },
                                    ""self"": {
                                      ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7/clients/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3""
                                    },
                                    ""revoke"": {
                                      ""href"": ""https://${yourOktaDomain}/api/v1/users/00u5t60iloOHN9pBi0h7/clients/0oabskvc6442nkvQO0h7/tokens/oar579Mcp7OUsNTlo0g3"",
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
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var oauth2RefreshToken = await client.Users.GetRefreshTokenForUserAndClientAsync("foo", "bar", "baz");

            oauth2RefreshToken.Should().NotBeNull();
            oauth2RefreshToken.Id.Should().Be("oar579Mcp7OUsNTlo0g3");
            oauth2RefreshToken.Issuer.Should().Be("https://${yourOktaDomain}/oauth2/ausain6z9zIedDCxB0h7");
            oauth2RefreshToken.ClientId.Should().Be("0oabskvc6442nkvQO0h7");
            oauth2RefreshToken.UserId.Should().Be("00u5t60iloOHN9pBi0h7");
            oauth2RefreshToken.Scopes.Count.Should().Be(2);
            oauth2RefreshToken.Scopes[0].Should().Be("offline_access");
            oauth2RefreshToken.Scopes[1].Should().Be("car:drive");
            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/clients/bar/tokens/baz?limit=20");
        }

        [Fact]
        public async Task RevokeUserGrants()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Users.RevokeUserGrantsAsync("foo");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/grants");
        }

        [Fact]
        public async Task GetUserGrant()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Users.GetUserGrantAsync("foo", "bar");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/grants/bar?");
        }

        [Fact]
        public async Task ReactivateUser() // Difficult to create a user with "PROVISIONED" status; core api requires user in a "PROVISIONED" status in order to reactivate. 
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Users.ReactivateUserAsync("foo");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/lifecycle/reactivate?sendEmail=false");
        }

        [Fact]
        public async Task SubscribeUserToNotification()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Subscriptions.SubscribeUserSubscriptionByNotificationTypeAsync("foo", NotificationType.IwaAgent);

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/subscriptions/IWA_AGENT/subscribe");
        }

        [Fact]
        public async Task UnsubscribeUserToNotification()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);
            await client.Subscriptions.UnsubscribeUserSubscriptionByNotificationTypeAsync("foo", NotificationType.IwaAgent);

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/subscriptions/IWA_AGENT/unsubscribe");
        }

        [Fact]
        public async Task ListUserSubscriptions()
        {
            var rawResponse = @"[
                                    {
                                        ""notificationType"": ""CONNECTOR_AGENT"",
                                        ""channels"": [
                                            ""email""
                                        ],
                                        ""status"": ""subscribed"",
                                        ""_links"": {
                                            ""unsubscribe"": {
                                                ""href"": ""https://${yourOktaDomain}/api/v1/users/00uuk0UVgUXjkIbPL0g3/subscriptions/CONNECTOR_AGENT/unsubscribe"",
                                                ""hints"": {
                                                    ""allow"": [
                                                        ""POST""
                                                    ]
                                                }
                                            },
                                            ""self"": {
                                                ""href"": ""https://${yourOktaDomain}/api/v1/users/00uuk0UVgUXjkIbPL0g3/subscriptions/CONNECTOR_AGENT""
                                            }
                                        }
                                    }
                                ]";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var subscriptions = await client.Users.ListUserSubscriptions("foo").ToListAsync();

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/users/foo/subscriptions");
            subscriptions.Should().NotBeNullOrEmpty();
            var subscription = subscriptions.FirstOrDefault();
            subscription.NotificationType.Should().Be(NotificationType.ConnectorAgent);
            subscription.Status.Should().Be(SubscriptionStatus.Subscribed);
            subscription.Channels.Should().Contain("email");
        }
    }
}
